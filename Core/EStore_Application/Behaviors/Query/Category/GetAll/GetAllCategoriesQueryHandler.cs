using EStore_Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponce>
    {
        private ICategoryService _categoryService;
        public GetAllCategoriesQueryHandler(ICategoryService categoryService) { _categoryService = categoryService; }
            
        public async Task<GetAllCategoriesQueryResponce> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
           var allPaginatedCategoriesVM = await _categoryService.GetAllCategoryAsyncService(request.paginationVM);

            return new GetAllCategoriesQueryResponce()
            {
                AllCategories = allPaginatedCategoriesVM,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
