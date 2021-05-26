using HotelHell_Data;
using HotelHell_Web.CustomAttributes;
using HotelHell_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHell_Web.Controllers
{
    [Authorize]
    public class UserRoleController : Controller
    {
        // Move this to UserRoleService
        public List<ApplicationUserModel> GetAllUsers()
        {
            var output = new List<ApplicationUserModel>();

            using (var db = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();
                var roles = db.Roles.ToList();

                foreach (var user in users)
                {
                    var model = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Email = user.Email
                    };

                    foreach (var role in user.Roles)
                    {
                        model.Roles.Add(role.RoleId, roles.Where(r => r.Id == role.RoleId).First().Name);
                    }

                    output.Add(model);
                }
            }

            return output;
        }


        [AuthorizeRole(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.UserRoles = GetAllUsers();

            return View();
        }
    }
}