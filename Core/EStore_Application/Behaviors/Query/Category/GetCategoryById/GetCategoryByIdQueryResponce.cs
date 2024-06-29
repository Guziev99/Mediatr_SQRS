using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetCategoryById
{
    public  class GetCategoryByIdQueryResponce
    {
        public AllCategoryVM category { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
