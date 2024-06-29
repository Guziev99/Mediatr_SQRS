using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Services
{
    public interface IOrderService
    {
        Task<ICollection<AllOrdersVM>> GetAllOrdersAsyncService(PaginationVM paginationVM);
        Task<AllOrdersVM> GetOrderByIdAsyncService(int id);
        Task AddOrderAsyncService(AllOrdersVM category);
        Task<bool> UpdateOrderAsyncService(AllOrdersVM categoryVM);
        Task DeleteOrderAsyncService(int id);
    }
}
