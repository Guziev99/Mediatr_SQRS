using EStore_Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Add
{
    public  class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponce>
    {
        public  CategoryVM? categoryVM {  get; set; }
    }
}
