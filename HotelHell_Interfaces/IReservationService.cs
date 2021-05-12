using HotelHell_Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Interfaces
{
    public interface IReservationService
    {
        Task<bool> CreateReservationAsync(ReservationCreate model);

        IEnumerable<ReservationListItem> GetAllReservations();

        Task<ReservationDetail> GetReservationByIdAsync(int reservationId);

        Task<bool> UpdateReservationAsync(ReservationEdit model);

        Task<bool> DeleteReservationAsync(int reservationId);
    }
}
