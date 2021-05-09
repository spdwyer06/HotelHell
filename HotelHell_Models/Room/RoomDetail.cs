using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Room
{
    public class RoomDetail
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Number Of Beds")]
        public int NumOfBeds { get; set; }

        [Display(Name = "Created At")]
        public DateTimeOffset CreatedAt { get; set; }

        [Display(Name = "Modified At")]
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
