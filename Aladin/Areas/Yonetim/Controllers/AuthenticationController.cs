using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class AuthenticationController : BaseController
    {
        public ActionResult Login(string returnUrl)
        {
            if (IsAuthenticated)
            {
                returnUrl = returnUrl ?? "/Admin/Main";

                return Redirect(returnUrl);
            }
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}