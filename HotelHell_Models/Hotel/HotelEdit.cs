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

        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Display(Name = "Building Number")]
        public int BuildingNumber { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        [MinLength(2, ErrorMessage = "Enter the 2 character state code.")]
        [MaxLength(2, ErrorMessage = "Enter the 2 character state code.")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Range(10000, 99999, ErrorMessage = "Enter a 5 digit zip code.")]
        [DataType(DataType.PostalCode, ErrorMessage = "Enter 5 digit zip code")]
        public int ZipCode { get; set; }

        [Display(Name = "Number Of Rooms Available")]
        public int NumOfRoomsAvail { get; set; }
    }
}
