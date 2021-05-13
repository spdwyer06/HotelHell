using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int NumOfBeds { get; set; }

        public bool Available { get; set; } = true;

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
