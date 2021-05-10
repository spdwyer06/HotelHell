using HotelHell_Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Interfaces
{
    public interface IRoomService
    {
        Task<bool> CreateRoomAsync(RoomCreate model);

        IEnumerable<RoomListItem> GetAllRooms();

        Task<RoomDetail> GetRoomByIdAsync(int roomId);

        Task<bool> UpdateRoomAsync(RoomEdit model);

        Task<bool> DeleteRoomAsync(int roomId);
    }
}
