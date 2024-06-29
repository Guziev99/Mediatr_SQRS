using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Delete
{
    public  class DeleteCategoryCommandRequest :IRequest<DeleteCategoryCommandResponce>
    { 
        public int Id { get; set; }
    }
}
