using HotelHell_Data;
using HotelHell_Models.Reservation;
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
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Reservation
        public ActionResult Index()
        {
            var service = CreateReservationService();
            var model = service.GetAllReservations();

            return View(model);
        }

        // GET: Reservation/Details/5
        public async Task<ActionResult> Details(int reservationId)
        {
            var service = CreateReservationService();
            var model = await service.GetReservationByIdAsync(reservationId);

            return View(model);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            //ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Id");
            //ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id");

            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var service = CreateReservationService();

                if (!await service.CreateReservationAsync(model))
                {
                    ModelState.AddModelError("", "Reservation could not be created.");

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Reservation/Edit/5
        public async Task<ActionResult> Edit(int reservationId)
        {
            var service = CreateReservationService();
            var reservation = await service.GetReservationByIdAsync(reservationId);
            var model = new ReservationEdit
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RoomId = reservation.RoomId
            };


            return View(model);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int reservationId, ReservationEdit model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Id != reservationId)
                {
                    ModelState.AddModelError("", "Id mismatch.");

                    return View(model);
                }

                var service = CreateReservationService();

                if (!await service.UpdateReservationAsync(model))
                {
                    ModelState.AddModelError("", "Could not update reservation.");

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public async Task<ActionResult> Delete(int reservationId)
        {
            var service = CreateReservationService();
            var model = await service.GetReservationByIdAsync(reservationId);

            return View(model);
        }

        // POST: Reservation/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int reservationId, ReservationDetail model)
        //{
        //    try
        //    {
        //        if (model.Id != reservationId)
        //        {
        //            ModelState.AddModelError("", "Id mismatch.");

        //            return View(model);
        //        }

        //        var service = CreateReservationService();

        //        await service.DeleteReservationAsync(reservationId);

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteReservation(int reservationId)
        {
            try
            {
                var service = CreateReservationService();

                await service.DeleteReservationAsync(reservationId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private ReservationService CreateReservationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new ReservationService(userId);
        }
    }
}
