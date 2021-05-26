using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelHell_Web.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        public string RoleList => string.Join(", ", Roles.Select(r => r.Value));
    }
}