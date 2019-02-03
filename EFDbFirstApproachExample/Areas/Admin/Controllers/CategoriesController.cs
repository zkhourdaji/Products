using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();

        // GET: Categories
        public ActionResult Index(string search = "")
        {
            List<Category> categories = db.Categories
                .Where(category => category.CategoryName.Contains(search)).ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long id)
        {
            Category category = db.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category existingCategory = db.Categories.Where(c => c.CategoryID == category.CategoryID).FirstOrDefault();
            existingCategory.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}