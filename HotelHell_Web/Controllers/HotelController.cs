using HotelHell_Models.Hotel;
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
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            var service = CreateHotelService();
            var model = service.GetAllHotels();

            return View(model);
        }

        // GET ALL HOTELS WITH VACANCIES
        //public ActionResult Index()
        //{
        //    var service = CreateHotelService();
        //    var model = service.GetAllHotelsWithVacancies();

        //    return View(model);
        //}

        // GET: Hotel/Details/5
        public async Task<ActionResult> Details(int hotelId)
        {
            var service = CreateHotelService();
            var model = await service.GetHotelByIdAsync(hotelId);

            return View(model);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(HotelCreate model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    var service = CreateHotelService();

        //    if (!service.CreateHotel(model))
        //    {
        //        ModelState.AddModelError("", "Hotel could not be created.");

        //        return View(model);
        //    }


        //    return RedirectToAction("Index");
        //}

        // POST: Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HotelCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var service = CreateHotelService();

                if (!await service.CreateHotelAsync(model))
                {
                    ModelState.AddModelError("", "Hotel could not be created.");

                    return View(model);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Hotel/Edit/5
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> Edit(int hotelId)
        {
            var service = CreateHotelService();
            var hotel = await service.GetHotelByIdAsync(hotelId);
            var model = new HotelEdit
            {
                Id = hotel.Id,
                Name = hotel.Name,
                BuildingNumber = hotel.BuildingNumber,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                ZipCode = hotel.ZipCode,
            };

            return View(model);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int hotelId, HotelEdit model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Id != hotelId)
                {
                    ModelState.AddModelError("", "Id mismatch.");

                    return View(model);
                }

                var service = CreateHotelService();

                if (!await service.UpdateHotelAsync(model))
                {
                    ModelState.AddModelError("", "Could not update hotel.");

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Hotel/Delete/5
        public async Task<ActionResult> Delete(int hotelId)
        {
            var service = CreateHotelService();
            var model = await service.GetHotelByIdAsync(hotelId);

            return View(model);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteHotel(int hotelId)
        {
            try
            {
                var service = CreateHotelService();

                await service.DeleteHotelAsync(hotelId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RedirectToRoomCreate(int hotelId)
        {
            return RedirectToAction("Create", "Room", new { hotelId });
        }

        public ActionResult RedirectToHotelRooms(int hotelId, string hotelName)
        {
            return RedirectToAction("HotelRoomsIndex", "Room", new { hotelId, hotelName });
        }


        private HotelService CreateHotelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new HotelService(userId);
        }
    }
}
