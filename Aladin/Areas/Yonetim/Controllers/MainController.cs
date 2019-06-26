using Aladin.Controllers;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public class MainController : AuthenticatedController
    {
        // GET: Yonetim/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}