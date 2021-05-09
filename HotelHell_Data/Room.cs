using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int NumOfBeds { get; set; }
    }
}
