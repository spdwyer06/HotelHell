using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Data
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int NumOfRoomsAvail { get; set; }

        public bool AnyVacancies
        {
            get
            {
                return NumOfRoomsAvail > 0;
            }
        }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
