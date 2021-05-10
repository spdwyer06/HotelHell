using HotelHell_Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerCreate model);

        IEnumerable<CustomerListItem> GetAllCustomers();

        Task<CustomerDetail> GetCustomerByIdAsync(int customerId);

        Task<bool> UpdateCustomerAsync(CustomerEdit model);

        Task<bool> DeleteCustomerAsync(int customerId);
    }
}
