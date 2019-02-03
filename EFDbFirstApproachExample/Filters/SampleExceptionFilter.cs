using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace EFDbFirstApproachExample.Filters
{
    public class SampleExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Debug.WriteLine("On Exception Method called!!!!!");
        }
    }
}