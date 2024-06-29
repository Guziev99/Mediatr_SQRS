using EStore_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Services
{
    public  interface ICustomerService
    {
        Task <ICollection<AllCustomerVM>> GetAllCustomersAsyncService();
        Task <AllCustomerVM> GetCustomerByIdAsyncService ();
        Task AddCustomerAsyncService(AllCustomerVM customer);
        Task <bool> UpdateCustomerAsyncService(AllCustomerVM customer);
        Task DeleteCustomerAsyncService(int id);
    }
}
