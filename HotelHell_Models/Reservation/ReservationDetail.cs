using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Reservation
{
    public class ReservationDetail : ReservationListItem
    {
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Room Id")]
        public int RoomId { get; set; }

        [Display(Name = "Check In Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckInDate { get; set; }

        [Display(Name = "Check Out Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckOutDate { get; set; }
    }
}
