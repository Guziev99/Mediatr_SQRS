using EStore_Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Add
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponce>
    {
        private ICategoryService _categoryService;
        public AddCategoryCommandHandler(ICategoryService service)
        {
            _categoryService = service; 
        }
        public async Task<AddCategoryCommandResponce> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryService.AddCategoryAsyncService(request.categoryVM);
            return new AddCategoryCommandResponce()
            {
                StatusCode = System.Net.HttpStatusCode.Created
            };


            
        }
    }

}
