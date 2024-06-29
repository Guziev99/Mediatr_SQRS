using EStore_Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Product.GetAll
{
    public  class GetAllProductQueryRequest : IRequest <GetAllProductQueryResponse>
    {
        // public PaginationVM PaginationVM { get; set; } = new PaginationVM() { Page = 0, PageSize = 10 };
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
