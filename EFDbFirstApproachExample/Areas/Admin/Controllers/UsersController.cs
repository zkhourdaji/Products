using EFDbFirstApproachExample.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        ApplicationDbContext usersDb = new ApplicationDbContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            List<ApplicationUser> users = usersDb.Users.ToList();
            return View(users);
        }
    }
}