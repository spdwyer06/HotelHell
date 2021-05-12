using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Reservation
{
    public class ReservationListItem
    {
        public int Id { get; set; }

        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Customer First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }
    }
}
