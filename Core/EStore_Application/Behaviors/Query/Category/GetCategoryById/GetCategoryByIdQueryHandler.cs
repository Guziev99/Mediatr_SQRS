using EStore_Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponce>
    {
        private ICategoryService _categoryService;
        public  GetCategoryByIdQueryHandler(ICategoryService service)
        {
            _categoryService = service;
        }
        public async Task<GetCategoryByIdQueryResponce> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsyncService(request.Id);

            if (category == null) return new GetCategoryByIdQueryResponce() { StatusCode = System.Net.HttpStatusCode.NotFound };

            return new GetCategoryByIdQueryResponce()
            {
                category = category,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
