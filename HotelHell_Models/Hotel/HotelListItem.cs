using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Hotel
{
    public class HotelListItem
    {
        public int Id { get; set; }

        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Display(Name = "Number Of Rooms Available")]
        public int NumOfRoomsAvail { get; set; }

        [Display(Name = "Any Vacancies?")]
        public bool AnyVacancies { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Liked?")]
        public bool IsFavorite { get; set; }
    }
}
