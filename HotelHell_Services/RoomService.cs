using HotelHell_Data;
using HotelHell_Interfaces;
using HotelHell_Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Services
{
    public class RoomService : IRoomService
    {
        private readonly Guid _userId;

        public RoomService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateRoomAsync(RoomCreate model)
        {
            var room = new Room
            {
                HotelId = model.HotelId,
                RoomNumber = model.RoomNumber,
                NumOfBeds = model.NumOfBeds,
                CreatedAt = DateTimeOffset.UtcNow
            };

            using (var db = new ApplicationDbContext())
            {
                //var hotel = db.Hotels.Single(h => h.Name == )

                db.Rooms.Add(room);

                return await db.SaveChangesAsync() == 1;
            }
        }

        public IEnumerable<RoomListItem> GetAllRooms()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Rooms.Select(room => new RoomListItem
                {
                    Id = room.Id,
                    HotelName = room.Hotel.Name,
                    NumOfBeds = room.NumOfBeds
                });

                return query.ToArray();
            }
        }

        public async Task<RoomDetail> GetRoomByIdAsync(int roomId)
        {
            using (var db = new ApplicationDbContext())
            {
                var room = await db.Rooms.FindAsync(roomId);

                if (room is null)
                    return null;

                return new RoomDetail
                {
                    Id = room.Id,
                    HotelId = room.HotelId,
                    RoomNumber = room.RoomNumber,
                    NumOfBeds = room.NumOfBeds,
                    CreatedAt = room.CreatedAt,
                    ModifiedAt = room.ModifiedAt
                };
            }
        }

        public async Task<bool> UpdateRoomAsync(RoomEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var room = await db.Rooms.FindAsync(model.Id);

                if (room is null)
                    return false;

                room.HotelId = model.HotelId;
                room.RoomNumber = model.RoomNumber;
                room.NumOfBeds = model.NumOfBeds;
                room.ModifiedAt = DateTimeOffset.UtcNow;

                return await db.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            using (var db = new ApplicationDbContext())
            {
                var room = await db.Rooms.FindAsync(roomId);

                if (room is null)
                    return false;

                db.Rooms.Remove(room);

                return await db.SaveChangesAsync() == 1;
            }
        }
    }
}
