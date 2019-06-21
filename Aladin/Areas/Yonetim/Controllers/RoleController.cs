using Framework;
using Framework.Core.Extensions;
using Framework.Model.Authentication;
using Framework.ViewModel;
using Aladin.Controllers;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class RoleController : AuthenticatedController
    {
        IRepository<Role> _roleRepo;
        Role _role;

        public RoleController()
        {
            _roleRepo = _unitOfWork.GetRepository<Role>();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            _role = id.HasValue ? _roleRepo.GetById(id.Value) : new Role();

            if (_role == null)
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);
            }

            return View(_role);
        }
    }
}