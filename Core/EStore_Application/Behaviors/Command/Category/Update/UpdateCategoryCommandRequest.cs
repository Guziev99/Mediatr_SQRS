using EStore_Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Update
{
    public  class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponce>
    {
        public int Id { get; set; }
        public CategoryVM ? categoryVM { get; set; }
    }
}
