using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Identity;
using EFDbFirstApproachExample.ViewModels;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace EFDbFirstApproachExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext appDbContext = new ApplicationDbContext();
                ApplicationUserStore appUserStore = new ApplicationUserStore(appDbContext);
                ApplicationUserManager appUserManager = new ApplicationUserManager(appUserStore);
                string passwordHash = Crypto.HashPassword(registerViewModel.Password);
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerViewModel.Username,
                    PasswordHash = passwordHash,
                    Email = registerViewModel.Email,
                    City = registerViewModel.City,
                    Country = registerViewModel.Country,
                    Birthday = registerViewModel.DateOfBirth,
                    Address = registerViewModel.Address,
                    PhoneNumber = registerViewModel.Mobile
                };
                IdentityResult result = appUserManager.Create(user);
                if (result.Succeeded)
                {
                    // add user to customer role
                    appUserManager.AddToRole(user.Id, "Customer");
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity userIdentity = appUserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(userIdentity);
                    
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // this will go in the validation summary
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                ApplicationUserStore store = new ApplicationUserStore(context);
                ApplicationUserManager manager = new ApplicationUserManager(store);
                ApplicationUser user = manager.Find(loginViewModel.Username, loginViewModel.Password);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(userIdentity);
                    if (manager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (manager.IsInRole(user.Id, "Manager"))
                    {
                        return RedirectToAction("Index", "Products", new { area = "Manager" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("My Error", "Invalid Username or Password");
                    return View();
                }
            }
         
            return Content("this shouldnt return here");
        }

        public ActionResult Logout()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ApplicationUserStore store = new ApplicationUserStore(context);
            ApplicationUserManager manager = new ApplicationUserManager(store);
            ApplicationUser user = manager.FindById(User.Identity.GetUserId());
            return View(user);
        }
    }
}