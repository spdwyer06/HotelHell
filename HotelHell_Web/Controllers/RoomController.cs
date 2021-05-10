using HotelHell_Models.Room;
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
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        // GET: Room/Details/5
        public async Task<ActionResult> Details(int roomId)
        {
            var service = CreateRoomService();
            var model = await service.GetRoomByIdAsync(roomId);

            return View(model);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoomCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var service = CreateRoomService();

                if (!await service.CreateRoomAsync(model))
                {
                    ModelState.AddModelError("", "Room could not be created.");

                    return View(model);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Room/Edit/5
        public async Task<ActionResult> Edit(int roomId)
        {
            var service = CreateRoomService();
            var room = await service.GetRoomByIdAsync(roomId);
            var model = new RoomEdit
            {
                Id = room.Id,
                HotelId = room.HotelId,
                RoomNumber = room.RoomNumber,
                NumOfBeds = room.NumOfBeds
            };

            return View(model);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int roomId, RoomEdit model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Id != roomId)
                {
                    ModelState.AddModelError("", "Id mismatch.");

                    return View(model);
                }

                var service = CreateRoomService();

                if (!await service.UpdateRoomAsync(model))
                {
                    ModelState.AddModelError("", "Could not update room.");

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Room/Delete/5
        public async Task<ActionResult> Delete(int roomId)
        {
            var service = CreateRoomService();
            var model = await service.DeleteRoomAsync(roomId);

            return View(model);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteHotel(int roomId)
        {
            try
            {
                var service = CreateRoomService();

                await service.DeleteRoomAsync(roomId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private RoomService CreateRoomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new RoomService(userId);
        }
    }
}
