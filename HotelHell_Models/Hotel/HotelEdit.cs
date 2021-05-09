using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Hotel
{
    public class HotelEdit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Building Number")]
        public int BuildingNumber { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Number Of Rooms Available")]
        public int NumOfRoomsAvail { get; set; }
    }
}
