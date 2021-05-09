using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHell_Models.Customer
{
    public class CustomerDetail
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Account Created At")]
        public DateTimeOffset AccountCreatedAt { get; set; }

        [Display(Name = "Account Modified At")]
        public DateTimeOffset? AccountModifiedAt { get; set; }
    }
}
