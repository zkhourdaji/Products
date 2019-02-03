using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();

        // GET: Products
        public ActionResult Index(string search = "", string sortColumn = "ProductName", string sortDirection = "asc", int pageNumber = 1)
        {
            List<Product> products = db.Products.Where(product => product.ProductName.Contains(search)).ToList();
            int rowsPerPage = 8;
            int pageCount = (int)Math.Ceiling(products.Count / (double)rowsPerPage);
            ViewBag.search = search;
            ViewBag.sortColumn = sortColumn;
            ViewBag.pageCount = pageCount;
            ViewBag.sortDirection = sortDirection;
            int rowsToSkip = (pageNumber - 1) * rowsPerPage;
            ViewBag.currentPage = pageNumber;
            if (ViewBag.sortColumn == "ProductID")
            {
                if (ViewBag.sortDirection == "asc")
                {
                    products = products.Skip(rowsToSkip).Take(rowsPerPage).OrderBy(product => product.ProductID).ToList();
                }
                else if (ViewBag.sortDirection == "desc")
                {
                    products = products.Skip(rowsToSkip).Take(rowsPerPage).OrderByDescending(product => product.ProductID).ToList();
                }
            }
            else if (ViewBag.sortColumn == "ProductName")
            {
                if (ViewBag.sortDirection == "asc")
                {
                    products = products.Skip(rowsToSkip).Take(rowsPerPage).OrderBy(product => product.ProductName).ToList();
                }
                else if (ViewBag.sortDirection == "desc")
                {
                    products = products.Skip(rowsToSkip).Take(rowsPerPage).OrderByDescending(product => product.ProductName).ToList();

                }
            }
            return View(products);
        }

        public ActionResult Details(long id)
        {
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        /// <summary>
        /// Form to create a product
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            List<Brand> brands = db.Brands.ToList();
            List<Category> categories = db.Categories.ToList();
            ViewBag.brands = brands;
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                // get all the files that were submitted from the browser
                // only works if the form enctype is multipart/form-data
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    Debug.WriteLine("length of image bytes: " + imgBytes.Length);
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    Debug.WriteLine("length of base 64 string: " + base64String.Length);
                    p.Photo = base64String;
                }

                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Invalid model state, go back");
                //return View();
            }
        }

        public ActionResult Edit(long id)
        {
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product existingProduct = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.DateOfPurchase = product.DateOfPurchase;
            existingProduct.BrandID = product.BrandID;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.AvailabilityStatus = product.AvailabilityStatus;
            existingProduct.Active = product.Active;
            //TODO: grab the photo from the form and update it in the database
            db.SaveChanges();
            return RedirectToAction("index", "Products");
        }

        public ActionResult Delete(long id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        // Product is just a dummy variable becuase we cannot have same method heading twice
        public ActionResult Delete(long id, Product temp)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product p = db.Products.Where(product => product.ProductID == id).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}