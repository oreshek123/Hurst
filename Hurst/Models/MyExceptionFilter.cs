using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hurst.Models
{
    public class MyExceptionFilter:  FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                action = "Error404",
                controller = "Home"
            }));
            //filterContext.Result = new RedirectResult("/Home/Error404.html");
            filterContext.ExceptionHandled = true;

        }
    }
}