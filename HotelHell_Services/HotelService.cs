using HotelHell_Data;
using HotelHell_Interfaces;
using HotelHell_Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Services
{
    public class HotelService : IHotelService
    {
        public Guid _userId;

        public HotelService(Guid userId)
        {
            _userId = userId;
        }

        //public bool CreateHotel(HotelCreate model)
        //{
        //    var hotel = new Hotel
        //    {
        //        Name = model.Name,
        //        BuildingNumber = model.BuildingNumber,
        //        StreetAddress = model.StreetAddress,
        //        City = model.City,
        //        State = model.State,
        //        ZipCode = model.ZipCode,
        //        NumOfRoomsAvail = model.NumOfRoomsAvail,
        //        CreatedAt = DateTimeOffset.UtcNow
        //    };

        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Hotels.Add(hotel);

        //        return db.SaveChanges() == 1;
        //    }
        //}

        public async Task<bool> CreateHotelAsync(HotelCreate model)
        {
            var hotel = new Hotel
            {
                Name = model.Name,
                BuildingNumber = model.BuildingNumber,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                NumOfRoomsAvail = model.NumOfRoomsAvail,
                CreatedAt = DateTimeOffset.UtcNow
            };

            using (var db = new ApplicationDbContext())
            {
                db.Hotels.Add(hotel);

                return await db.SaveChangesAsync() == 1;
            }
        }

        public IEnumerable<HotelListItem> GetAllHotels()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Hotels.Select(hotel => new HotelListItem
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    AnyVacancies = hotel.NumOfRoomsAvail > 0
                });

                return query.ToArray();
            }
        }

        public async Task<HotelDetail> GetHotelByIdAsync(int hotelId)
        {
            using (var db = new ApplicationDbContext())
            {
                var hotel = await db.Hotels.FindAsync(hotelId);

                if (hotel is null)
                    return null;

                return new HotelDetail
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    BuildingNumber = hotel.BuildingNumber,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State.ToUpper(),
                    ZipCode = hotel.ZipCode,
                    NumOfRoomsAvail = hotel.NumOfRoomsAvail,
                    AnyVacancies = hotel.AnyVacancies,
                    CreatedAt = hotel.CreatedAt,
                    ModifiedAt = hotel.ModifiedAt,
                    Rooms = hotel.Rooms
                };
            }

        }

        public async Task<bool> UpdateHotelAsync(HotelEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var hotel = await db.Hotels.FindAsync(model.Id);

                if (hotel is null)
                    return false;

                hotel.Name = model.Name;
                hotel.BuildingNumber = model.BuildingNumber;
                hotel.StreetAddress = model.StreetAddress;
                hotel.City = model.City;
                hotel.State = model.State;
                hotel.ZipCode = model.ZipCode;
                hotel.NumOfRoomsAvail = model.NumOfRoomsAvail;
                hotel.ModifiedAt = DateTimeOffset.UtcNow;

                return await db.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteHotelAsync(int hotelId)
        {
            using (var db = new ApplicationDbContext())
            {
                var hotel = await db.Hotels.FindAsync(hotelId);

                if (hotel is null)
                    return false;

                db.Hotels.Remove(hotel);

                return await db.SaveChangesAsync() == 1;
            }
        }
    }
}
