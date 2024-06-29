using EStore_Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetAll
{
    public  class GetAllCategoriesQueryRequest : IRequest<GetAllCategoriesQueryResponce>
    {
        public PaginationVM paginationVM { get; set; }
    }
}
