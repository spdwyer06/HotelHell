using HotelHell_Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Interfaces
{
    public interface IHotelService
    {
        Task<bool> CreateHotelAsync(HotelCreate model);

        IEnumerable<HotelListItem> GetAllHotels();

        Task<HotelDetail> GetHotelByIdAsync(int hotelId);

        Task<bool> UpdateHotelAsync(HotelEdit model);

        Task<bool> DeleteHotelAsync(int hotelId);
    }
}
