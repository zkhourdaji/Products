using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Admin.Models
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();

        // GET: Brands
        public ActionResult Index(string search = "")
        {
            List<Brand> brands = db.Brands.Where(brand => brand.BrandName.Contains(search)).ToList();
            return View(brands);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            Brand brand = db.Brands.Where(b => b.BrandID == id).FirstOrDefault();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            Brand existingBrand = db.Brands.Where(b => b.BrandID == brand.BrandID).FirstOrDefault();
            existingBrand.BrandName = brand.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            Brand brand = db.Brands.Where(b => b.BrandID == id).FirstOrDefault();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Delete(Brand brand)
        {
            Brand existingBrand =
                db.Brands.Where(b => b.BrandID == brand.BrandID).FirstOrDefault();
            db.Brands.Remove(existingBrand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}