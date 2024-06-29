using EStore_Application.Services;
using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public  class OrderService : IOrderService
    {
        public Task AddOrderAsyncService(AllOrdersVM category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsyncService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AllOrdersVM>> GetAllOrdersAsyncService(PaginationVM paginationVM)
        {
            throw new NotImplementedException();
        }

        public Task<AllOrdersVM> GetOrderByIdAsyncService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsyncService(AllOrdersVM categoryVM)
        {
            throw new NotImplementedException();
        }
    }
}
