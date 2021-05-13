using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Room
{
    public class RoomListItem
    {
        public int Id { get; set; }

        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }

        [Display(Name = "Number Of Beds")]
        public int NumOfBeds { get; set; }

        public bool Available { get; set; }
    }
}
