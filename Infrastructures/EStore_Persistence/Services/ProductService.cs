using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Repositories.ProductRepos;
using EStore_Application.Services;
using EStore_Domain.Concretes;
using EStore_Domain.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public class ProductService : IProductService
    {

        private IReadProductRepository _readProductRepo;
        private IWriteProductRepository _writeProductRepo;
        private IReadCategoryRepository _readCategoryRepo;
        public ProductService(IReadProductRepository _repo, IWriteProductRepository _writeRepo, IReadCategoryRepository catReadRepo)
        {
            _readProductRepo = _repo;
            _writeProductRepo = _writeRepo;
            _readCategoryRepo = catReadRepo;
        }



        public async Task AddProductAsyncService(ProductVM productVm)
        {
            var product = new Product()
            {
                Name = productVm.Name,
                Description = productVm.Description,
                Stoke = productVm.Stoke,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId,
            };
            await _writeProductRepo.AddAsync(product);
            await _writeProductRepo.SaveChangeAsync();
        }

        public async Task DeleteProductAsyncService(int id)
        {
            await _writeProductRepo.DeleteAsync(id);
            await _writeProductRepo.SaveChangeAsync();
        }

        public async Task<ICollection<AllProductVM>> GetAllProductAsyncService(PaginationVM paginationVM)
        {
           
            var products = await _readProductRepo.GetAllAsync();
            var paginatedProducts =  products.ToList().Paginate<Product>( paginationVM);

            var productVMs = paginatedProducts.Select(product =>
                new AllProductVM()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stoke = product.Stoke,
                    CategoryName = product.Category.Name,
                }).ToList();
            return productVMs;
        }

        public async Task<AllProductVM> GetByIdAsyncService(int id)
        {
            var product = await _readProductRepo.GetByIdAsync(id);

            var productVM = new AllProductVM()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stoke = product.Stoke,
                CategoryName = product?.Category.Name
            };

            return productVM;
        }

        public async Task <bool> UpdateProductAsyncService(int id, ProductVM productVM)
        {
            var product = await _readProductRepo .GetByIdAsync(id);

            if (product == null) return false;

            var category = await _readCategoryRepo.GetByIdAsync(productVM.CategoryId);
            if (category == null) return false;


            product.Name = productVM.Name;
            product.Description = productVM.Description;
            product.Price = productVM.Price;
            product.Stoke = productVM.Stoke;
            product.CategoryId = productVM.CategoryId;


            await _writeProductRepo.UpdateAsync(product);
            await _writeProductRepo.SaveChangeAsync();
            return true;
        }
    }
}
