using HotelHell_Data;
using HotelHell_Models.UserRole;
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
        // Move methods to UserRoleService
        [Authorize(Roles = "Admin, Manager")]
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

        [Authorize(Roles = "Admin")]
        public Dictionary<string, string> GetAllRoles()
        {
            using (var db = new ApplicationDbContext())
            {
                //var roles = db.Roles.ToList();

                // Creating a dicionary with the Key being the Role Id and the Value being Role Name
                var roles = db.Roles.ToDictionary(role => role.Id, role => role.Name);

                return roles;
            }
        }




        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void AddRole(UserRoleModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.AddToRole(model.UserId, model.RoleName);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void RemoveRole(UserRoleModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.RemoveFromRole(model.UserId, model.RoleName);
            }
        }

        [AuthorizeRole(Roles = "Admin")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.UserRoles = GetAllUsers();

            return View();
        }
    }
}