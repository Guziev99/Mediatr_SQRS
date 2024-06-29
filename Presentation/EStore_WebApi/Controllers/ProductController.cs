using EStore_Application.Behaviors.Command.Product.GetAll;
using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Repositories.ProductRepos;
using EStore_Application.Services;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using EStore_Persistence.Repositories.ProductRepo;
using EStore_Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IReadProductRepository _readProductRepo;
        private IWriteProductRepository _writeProductRepo;
        private IReadCategoryRepository _readCategoryRepo;

        private IProductService _productService;


        private IMediator _mediatr;
        public ProductController(IReadProductRepository _repo, IWriteProductRepository _writeRepo, IReadCategoryRepository catReadRepo,

            IProductService productService,
            IMediator mediatr
            )
        {
            _readProductRepo = _repo;
            _writeProductRepo = _writeRepo;
            _readCategoryRepo = catReadRepo;

            _productService = productService;

            _mediatr = mediatr;
        }




        //[HttpGet("GetAllProducts")]
        //public async Task<IActionResult>   GetAll ([FromQuery]PaginationVM paginationVM)
        //{

        //    var productVMs = await _productService.GetAllProductAsyncService(paginationVM);
        //    return Ok(productVMs);
        //}


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest paginationVM)
        {
            GetAllProductQueryResponse? responce = await _mediatr.Send(paginationVM);

            if(responce.StatusCode == System.Net.HttpStatusCode.NotFound) { return NotFound("Hech bir product tapilmadi"); }

            return responce.products.Count() == 0 ? NotFound("Product bulunamadi ") : Ok(responce.products);
             
        }


        [HttpPost("[action]")]
        public async Task <IActionResult> AddProduct([FromBody]ProductVM productVm)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            //var product = new Product()
            //{
            //    Name = productVm.Name,
            //    Description = productVm.Description,
            //    Stoke = productVm.Stoke,
            //    Price = productVm.Price,
            //    CategoryId = productVm.CategoryId,
            //};
            //await _writeProductRepo.AddAsync(product);
            //await _writeProductRepo.SaveChangeAsync();

            await _productService.AddProductAsyncService(productVm);

            return StatusCode(201);
        }


        [HttpGet("GetProductById/{id}")]
        public async Task <IActionResult> GetById([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest(id);

            var productVM = await  _productService.GetByIdAsyncService(id);

            return Ok(productVM);
        }

        [HttpGet("GetProductByExpression")]  ///   Example uchun yazdim ki, sonra gerektiyinde yaratdigimi xatirlayam.
        public async Task <IActionResult> GetByExpression()
        {
            var product = await _readProductRepo.GetByExpressionAsync(p => p.Id == 3);

            return Ok(product);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task <IActionResult> UpdateProduct(int id, [FromBody] ProductVM productVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //var product = await _readProductRepo.GetByIdAsync(id);

            //if (product == null) return NotFound($"{id} id'sinde Product bulunamadi !!");

            //var category = await _readCategoryRepo.GetByIdAsync(productVM.CategoryId);
            //if (category == null) return NotFound("Bu id ile Category Bulunamadi !!");


            //product.Name = productVM.Name;
            //product.Description = productVM.Description;
            //product.Price = productVM.Price;
            //product.Stoke = productVM.Stoke;
            //product.CategoryId = productVM.CategoryId;


            //await  _writeProductRepo.UpdateAsync(product);
            //await _writeProductRepo.SaveChangeAsync();

            bool check = await _productService.UpdateProductAsyncService(id, productVM);

            return check ? Ok("Ugurla update edildi") : BadRequest("Id ve ya CategoryId yalnishdir !!!");
        }

        [HttpPut("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _productService.DeleteProductAsyncService(id);

            return Ok("Product Has deleted");
        }








        [HttpGet("GetAllProductsAtThisCategory")]
        public async Task<IActionResult> GetProductInCategory([FromQuery] string categoryName)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var products = await _readProductRepo.GetByExpressionAsync(c => c.Category.Name == categoryName);

            return Ok(products);





        }



    }
}
