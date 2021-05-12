using HotelHell_Data;
using HotelHell_Interfaces;
using HotelHell_Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Services
{
    public class ReservationService : IReservationService
    {
        private readonly Guid _userId;

        public ReservationService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateReservationAsync(ReservationCreate model)
        {
            var reservation = new Reservation
            {
                CustomerId = model.CustomerId,
                RoomId = model.RoomId
            };

            using (var db = new ApplicationDbContext())
            {
                db.Reservations.Add(reservation);

                return await db.SaveChangesAsync() == 1;
            }
        }

        public IEnumerable<ReservationListItem> GetAllReservations()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Reservations.Select(reservation => new ReservationListItem
                {
                    Id = reservation.Id,
                    HotelName = reservation.Room.Hotel.Name,
                    RoomNumber = reservation.Room.RoomNumber,
                    CustomerFirstName = reservation.Customer.FirstName,
                    CustomerLastName = reservation.Customer.LastName
                });

                return query.ToArray();
            }
        }

        public async Task<ReservationDetail> GetReservationByIdAsync(int reservationId)
        {
            using (var db = new ApplicationDbContext())
            {
                var reservation = await db.Reservations.FindAsync(reservationId);

                if (reservation is null)
                    return null;

                return new ReservationDetail
                {
                    Id = reservation.Id,
                    HotelName = reservation.Room.Hotel.Name,
                    RoomId = reservation.RoomId,
                    RoomNumber = reservation.Room.RoomNumber,
                    CustomerId = reservation.CustomerId,
                    CustomerFirstName = reservation.Customer.FirstName,
                    CustomerLastName = reservation.Customer.LastName
                };
            }
        }

        public async Task<bool> UpdateReservationAsync(ReservationEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var reservation = await db.Reservations.FindAsync(model.Id);

                if (reservation is null)
                    return false;

                reservation.CustomerId = model.CustomerId;
                reservation.RoomId = model.RoomId;

                return await db.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            using (var db = new ApplicationDbContext())
            {
                var reservation = await db.Reservations.FindAsync(reservationId);

                if (reservation is null)
                    return false;

                db.Reservations.Remove(reservation);

                return await db.SaveChangesAsync() == 1;
            }
        }
    }
}
