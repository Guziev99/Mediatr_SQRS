using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Services;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using EStore_Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using EStore_Application.Behaviors.Query.Category.GetCategoryById;
using EStore_Application.Behaviors.Query.Category.GetAll;
using EStore_Application.Behaviors.Command.Category.Update;
using EStore_Application.Behaviors.Command.Category.Add;
using EStore_Application.Behaviors.Command.Category.Delete;

namespace EStore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IWriteCategoryRepository _writeCategoryRepository;
        private IReadCategoryRepository _readCategoryRepository;

        private ICategoryService _categoryservice;

        private IMediator _mediator;
        public CategoryController( IWriteCategoryRepository repoWrite, IReadCategoryRepository readCategoryRepository,  ICategoryService catService, IMediator mediatr)
        {
            _writeCategoryRepository = repoWrite;
            _readCategoryRepository = readCategoryRepository;
            _categoryservice = catService;

            _mediator = mediatr;    


        }


        // Addcategory
        [HttpPost("[action]")]
        public async Task <IActionResult> AddCategory([FromBody]AddCategoryCommandRequest categoryVM) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            //await _categoryservice.AddCategoryAsyncService(categoryVM);
            AddCategoryCommandResponce check = await _mediator.Send(categoryVM);

            return (check.StatusCode == System.Net.HttpStatusCode.Created) ?  StatusCode(201) : BadRequest("Hata olustu..");
        }

        //GetAll
        [HttpPost("GetAllCategories")]
        public async Task < IActionResult> GetAll([FromBody] GetAllCategoriesQueryRequest paginationVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            GetAllCategoriesQueryResponce response = await _mediator.Send(paginationVM);
            return (response.StatusCode == System.Net.HttpStatusCode.NotFound) ?
                NotFound("Category Not found") : Ok(response.AllCategories);
                
            //var categoryVmPages = await _categoryservice.GetAllCategoryAsyncService(paginationVM);
            //return Ok(categoryVmPages );
        }

        //GetById
        [HttpPost("GetCategoryById")]
        public async Task <IActionResult> GetById(GetCategoryByIdQueryRequest id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //var category = await _categoryservice.GetCategoryByIdAsyncService(id);
            GetCategoryByIdQueryResponce response = await _mediator.Send(id);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound) { return NotFound($"{id.Id}  -sinde Category Tapilmadi"); }
            return Ok( response.category);
           
        }


        //Update  
        [HttpPut("UpdateCategory")]
        public async Task <IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //bool check = await _categoryservice.UpdateCategoryAsyncService(id, categoryVM);
            UpdateCategoryCommandResponce  check = await _mediator.Send(request);
            return check.IsUpdated ? Ok(" Category has Updated") :  NotFound("Edilmedi");
        }

        //Delete
        [HttpDelete("DeleteCategory")]
        public async Task <IActionResult> DeleteById(DeleteCategoryCommandRequest id)
        {
            DeleteCategoryCommandResponce responce = await _mediator.Send(id);

            return responce.IsDeleted ? Ok("Category has deleted") : NotFound("Bu id ile category bulunamadi..");
            // bool check = await _categoryservice.DeleteCategoryAsyncService(id);
            // return check ? Ok("Deleted Category") : NotFound("Bu id ile category bulunamadi");
        }



         
        [HttpGet("GetAllProdsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProdsByCat(int categoryId)
        {
            var products = await _readCategoryRepository.GetAllProductsWithCategoryId(categoryId);
            if (products == null) return NotFound("Hech bir product tapilmadi");

            var AllProdsVm = products.Select(c => new AllProductVM()
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                Stoke = c.Stoke,
                CategoryName = c.Category.Name,
                ImageUrl = c.ImageUrl,

            }).ToList();


            return Ok(AllProdsVm);
        }






    }

}
