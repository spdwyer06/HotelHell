using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Hotel
{
    public class HotelCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Enter at least 2 characters for this field")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Building Number")]
        public int BuildingNumber { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Enter the 2 character state code.")]
        [MaxLength(2, ErrorMessage = "Enter the 2 character state code.")]
        public string State { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Enter the 5 digit zip code.")]
        [MaxLength(5, ErrorMessage = "Enter the 5 digit zip code.")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "Number Of Rooms Available")]
        public int NumOfRoomsAvail { get; set; }
    }
}
