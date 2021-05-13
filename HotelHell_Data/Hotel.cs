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
        public int BuildingNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public int NumOfRoomsAvail { get; set; }

        public bool AnyVacancies => NumOfRoomsAvail > 0;

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }


        public int NumRoomsAvail
        {
            get
            {
                var availableRooms = new List<Room>();

                foreach (var room in Rooms)
                {
                    if (room.Available)
                        availableRooms.Add(room);
                }

                return availableRooms.Count;
            }
        }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
