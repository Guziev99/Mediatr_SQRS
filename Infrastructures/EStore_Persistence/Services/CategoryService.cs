using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Services;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;
using EStore_Persistence.Repositories.CategoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IReadCategoryRepository _readCategoryRepo;
        private readonly IWriteCategoryRepository _writeCategoryRepo;

        public CategoryService(IReadCategoryRepository readrepo, IWriteCategoryRepository writerepo)
        {
            _readCategoryRepo = readrepo; 
            _writeCategoryRepo = writerepo;
        }
        public async Task AddCategoryAsyncService(CategoryVM category)
        {
            var newcategory = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };
            await _writeCategoryRepo.AddAsync(newcategory);
            await _writeCategoryRepo.SaveChangeAsync();
        }

        public async Task<bool> DeleteCategoryAsyncService(int id)
        {
            var category = await _readCategoryRepo.GetByIdAsync(id);
            if (category == default) return false;

            await _writeCategoryRepo.DeleteAsync(id);
            await _writeCategoryRepo.SaveChangeAsync();
            return true;
        }

        public async Task<ICollection<AllCategoryVM>> GetAllCategoryAsyncService(PaginationVM paginationVM)
        {
            var categories = await _readCategoryRepo.GetAllAsync();
            
                var paginatedCategories =  categories.ToList().Paginate<Category>(paginationVM);


            var categoryVMs = paginatedCategories.Select(c =>
            new AllCategoryVM()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,

            }).ToList();


            return categoryVMs ;
            
        }

        public async Task<AllCategoryVM> GetCategoryByIdAsyncService(int id)
        {
            var category =await _readCategoryRepo.GetByIdAsync(id);

            var categoryVM = new AllCategoryVM()
            {
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };

            return categoryVM;
        }

        public async Task<bool> UpdateCategoryAsyncService(int id, CategoryVM categoryVM)
        {
            var category = await _readCategoryRepo.GetByIdAsync(id);
            if (category is null) return false;

            category.Name = categoryVM.Name;
            category.Description = categoryVM.Description;

            await _writeCategoryRepo.UpdateAsync(category);
            await _writeCategoryRepo.SaveChangeAsync();
            return true;
        }
    }
}
