using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelHell_Data;

namespace HotelHell_Models.Hotel
{
    public class HotelDetail
    {
        public int Id { get; set; }

        [Display(Name = "Hotel Name")]
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

        [Display(Name = "Any Vacancies?")]
        public bool AnyVacancies { get; set; }

        [Display(Name = "Created At")]
        public DateTimeOffset CreatedAt { get; set; }

        [Display(Name = "Modified At")]
        public DateTimeOffset? ModifiedAt { get; set; }

        public virtual ICollection<HotelHell_Data.Room> Rooms { get; set; }
    }
}
