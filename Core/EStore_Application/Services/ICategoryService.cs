using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Services
{
    public  interface ICategoryService
    {
        Task <ICollection<AllCategoryVM>> GetAllCategoryAsyncService(PaginationVM paginationVM);
        Task <AllCategoryVM> GetCategoryByIdAsyncService(int id);
        Task AddCategoryAsyncService(CategoryVM category);
        Task<bool> UpdateCategoryAsyncService(int id, CategoryVM categoryVM);
        Task<bool> DeleteCategoryAsyncService(int id);
    }
}
