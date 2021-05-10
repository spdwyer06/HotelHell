using HotelHell_Models.Customer;
using HotelHell_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelHell_Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int customerId)
        {
            var service = CreateCustomerService();
            var model = await service.GetCustomerByIdAsync(customerId);

            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var service = CreateCustomerService();

                if (!await service.CreateCustomerAsync(model))
                {
                    ModelState.AddModelError("", "Customer could not be created.");

                    return View(model);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int customerId)
        {
            var service = CreateCustomerService();
            var customer = await service.GetCustomerByIdAsync(customerId);
            var model = new CustomerEdit
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };

            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int customerId, CustomerEdit model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Id != customerId)
                {
                    ModelState.AddModelError("", "Id mismatch.");

                    return View(model);
                }

                var service = CreateCustomerService();

                if (!await service.UpdateCustomerAsync(model))
                {
                    ModelState.AddModelError("", "Could not update customer.");

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int customerId)
        {
            var service = CreateCustomerService();
            var model = await service.DeleteCustomerAsync(customerId);

            return View(model);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteHotel(int customerId)
        {
            try
            {
                var service = CreateCustomerService();

                await service.DeleteCustomerAsync(customerId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new CustomerService(userId);
        }
    }
}
