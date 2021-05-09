using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Room
{
    public class RoomCreate
    {
        [Required]
        public int HotelId { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required]
        [Display(Name = "Number Of Beds")]
        public int NumOfBeds { get; set; }
    }
}
