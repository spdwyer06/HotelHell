using HotelHell_Data;
using HotelHell_Interfaces;
using HotelHell_Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<bool> CreateCustomerAsync(CustomerCreate model)
        {
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                AccountCreatedAt = DateTimeOffset.UtcNow
            };

            using (var db = new ApplicationDbContext())
            {
                db.Customers.Add(customer);

                return await db.SaveChangesAsync() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetAllCustomers()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Customers.Select(customer => new CustomerListItem
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                });

                return query.ToArray();
            }
        }

        public async Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
        {
            using (var db = new ApplicationDbContext())
            {
                var customer = await db.Customers.FindAsync(customerId);

                if (customer is null)
                    return null;

                return new CustomerDetail
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    AccountCreatedAt = customer.AccountCreatedAt,
                    AccountModifiedAt = customer.AccountModifiedAt
                };
            }
        }

        public async Task<bool> UpdateCustomerAsync(CustomerEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var customer = await db.Customers.FindAsync(model.Id);

                if (customer is null)
                    return false;

                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Email = model.Email;
                customer.AccountModifiedAt = DateTimeOffset.UtcNow;

                return await db.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            using (var db = new ApplicationDbContext())
            {
                var customer = await db.Customers.FindAsync(customerId);

                if (customer is null)
                    return false;

                db.Customers.Remove(customer);

                return await db.SaveChangesAsync() == 1;
            }
        }
    }
}
