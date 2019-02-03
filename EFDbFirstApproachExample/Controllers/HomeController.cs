using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;
using System.Diagnostics;

namespace EFDbFirstApproachExample.Controllers
{
    public class HomeController : Controller
    {
        [MyActionFilter]
        [MyResultFilter]
        [SampleExceptionFilter]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}