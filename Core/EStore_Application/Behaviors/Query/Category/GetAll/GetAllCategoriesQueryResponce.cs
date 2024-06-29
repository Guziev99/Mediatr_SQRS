using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetAll
{
    public  class GetAllCategoriesQueryResponce
    {
        public ICollection<AllCategoryVM >? AllCategories { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
    }
}
