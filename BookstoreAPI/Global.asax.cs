using BookstoreAPI.App_Start;
using System.Web.Http;

namespace BookstoreAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutomapperConfig.init();
        }
    }
}
