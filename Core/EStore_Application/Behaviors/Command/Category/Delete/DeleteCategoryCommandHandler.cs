using EStore_Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponce>
    {
        private ICategoryService _categoryService;
        public DeleteCategoryCommandHandler(ICategoryService service)
        {
            _categoryService = service;
        }
        public async Task<DeleteCategoryCommandResponce> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool check = await _categoryService.DeleteCategoryAsyncService(request.Id);
            return check ?  new DeleteCategoryCommandResponce() { IsDeleted = true} : new DeleteCategoryCommandResponce() { IsDeleted = false};
        }
    }
}
