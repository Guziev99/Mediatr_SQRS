using EStore_Application.Services;
using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        public Task AddCustomerAsyncService(AllCustomerVM customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsyncService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AllCustomerVM>> GetAllCustomersAsyncService()
        {
            throw new NotImplementedException();
        }

        public Task<AllCustomerVM> GetCustomerByIdAsyncService()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerAsyncService(AllCustomerVM customer)
        {
            throw new NotImplementedException();
        }
    }
}
