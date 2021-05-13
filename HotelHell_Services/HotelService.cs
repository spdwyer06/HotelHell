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
        private readonly Guid _userId;

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
            //var hotelName = char.ToUpper(model.Name[0]) + model.Name.Substring(1);
            var hotelName = CapitalizeHotelName(model.Name);

            var hotel = new Hotel
            {
                Name = hotelName,
                BuildingNumber = model.BuildingNumber,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
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
                var query = db.Hotels.ToList().Select(hotel => new HotelListItem
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    //AnyVacancies = hotel.NumRooms > 0
                    //NumOfRoomsAvail = hotel.NumOfRoomsAvail
                    AnyVacancies = hotel.AnyVacancies
                    //AnyVacancies = hotel.NumOfRoomsAvail > 0
                });
                //.ToList().Where(hotel => hotel.AnyVacancies == true);

                return query.ToArray();
            }
        }

        public IEnumerable<HotelListItem> GetAllHotelsWithVacancies()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Hotels.Where(hotel => hotel.AnyVacancies)
                                     .Select(hotel => new HotelListItem
                                     {
                                         Id = hotel.Id,
                                         Name = hotel.Name,
                                         NumOfRoomsAvail = hotel.NumOfRoomsAvail
                                         //AnyVacancies = hotel.AnyVacancies
                                         //AnyVacancies = hotel.NumOfRoomsAvail > 0
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



        private string CapitalizeHotelName(string hotelName)
        {
            var baseName = hotelName.ToLower();
            var words = baseName.Split(' ');
            var capName = "";

            foreach (var word in words)
                capName += char.ToUpper(word[0]) + word.Substring(1) + " ";
            //{
            //    capName += char.ToUpper(word[0]) + word.Substring(1) + " ";
            //}

            return capName.Trim();
        }
    }
}
