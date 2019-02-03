using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace EFDbFirstApproachExample.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.numberOfVistors = 50;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.numberOfVistors = 70;
        }

     
    }
}