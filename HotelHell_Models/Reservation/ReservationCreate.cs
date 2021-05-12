using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Reservation
{
    public class ReservationCreate
    {
        [Required]
        [Display(Name = "Room Id")]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
    }
}
