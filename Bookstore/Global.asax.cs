using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Bookstore.Models;
using Bookstore.ViewModels;
using System.Runtime.InteropServices;
using Bookstore.App_Start;
using System.Web.Http;

namespace Bookstore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalConfiguration.Configure(WebAPIConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomapperConfig.init();
        }
    }
}
