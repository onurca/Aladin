using Aladin.Helpers;
using Framework.Core.Caching;
using Kooperatif.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aladin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutofacConfig.ConfigureContainer();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CacheProvider.Instance = new Cache();
        }

        protected void Application_Error()
        {
            ErrorHandler.Configure(Context, Server);
        }
    }
}
