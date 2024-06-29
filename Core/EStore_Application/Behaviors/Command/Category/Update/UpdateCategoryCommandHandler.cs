using EStore_Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Command.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponce>
    {
        private ICategoryService _categoryService;
        public UpdateCategoryCommandHandler(ICategoryService catservice)
        {
            _categoryService = catservice;
        }
        public async Task<UpdateCategoryCommandResponce> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var isUpdated = await _categoryService.UpdateCategoryAsyncService(request.Id, request.categoryVM!);
            return isUpdated ? new UpdateCategoryCommandResponce() { IsUpdated = true} : new UpdateCategoryCommandResponce() { IsUpdated = false};
        }
    }
}
