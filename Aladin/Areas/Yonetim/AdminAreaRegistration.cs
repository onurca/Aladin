using System.Web.Mvc;

namespace Aladin.Areas.Yonetim
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, area = AreaName },
                new[] { "Aladin.Areas.Yonetim.Controllers" }
            );
        }
    }
}