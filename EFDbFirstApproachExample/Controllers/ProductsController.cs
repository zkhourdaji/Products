using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;
using EFDbFirstApproachExample.ViewModels;
using EFDbFirstApproachExample.Filters;
using EFDbFirstApproachExample.IRepository;

namespace EFDbFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        //IProductsRepository iProductsRepository;

        //public ProductsController(IProductsRepository iProductsRepository)
        //{
        //    this.iProductsRepository = iProductsRepository;
        //}

        CompanyDbContext db = new CompanyDbContext();

        [MyAuthenticationFilter]
        [CustomerAuthorization]
        // GET: Products
        public ActionResult Index(string search = "", string sortColumn = "ProductName", string sortDirection = "asc", int pageNumber =1)
        {
            //List<Product> products = iProductsRepository.GetProducts();
            List<Product> products = db.Products.ToList();
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
            ProductsViewModel productsViewModel = new ProductsViewModel(products);
            return View(productsViewModel);
        }

        public ActionResult Details(long id)
        {
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }
    }
}