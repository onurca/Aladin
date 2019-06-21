using Framework;
using Framework.Model.Logger;
using Aladin.Controllers;
using System;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class LogController : AuthenticatedController
    {
        IRepository<Log> _logRepo;

        public LogController()
        {
            _logRepo = _unitOfWork.GetRepository<Log>();
        }

        public ActionResult Display(Guid id)
        {
            var model = _logRepo.GetById(id);

            return View(model);
        }

        public ActionResult List()
        {
            return View();
        }
    }
}