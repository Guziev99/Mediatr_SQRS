using EStore_Application.Services;
using EStore_Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Product.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private IProductService _productService;
        public GetAllProductQueryHandler(IProductService prodservice)
        {
            _productService = prodservice;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productsPaginated = await  _productService.GetAllProductAsyncService(new PaginationVM() { Page = request.Page, PageSize = request.PageSize });


            return new GetAllProductQueryResponse()
            {
                products = productsPaginated,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
             
        }
    }
}
