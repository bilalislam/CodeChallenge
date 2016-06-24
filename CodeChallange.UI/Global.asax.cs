using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HttpContextBase = CodeChallange.UI.StartUp.HttpContextBase;

namespace CodeChallange.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpContextBase.Initialize();
        }
    }
}
