using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bookstore.App_Start;

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
            //AutomapperConfig.init();
        }
    }
}
