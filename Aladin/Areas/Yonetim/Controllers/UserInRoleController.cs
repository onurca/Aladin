using Framework;
using Framework.Core.Extensions;
using Framework.Model.Authentication;
using Framework.ViewModel;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class UserInRoleController : AuthenticatedController
    {
        IRepository<User> _userRepo;
        IRepository<Role> _roleRepo;
        IRepository<UserInRole> _userInRoleRepo;

        public UserInRoleController()
        {
            _userRepo = _unitOfWork.GetRepository<User>();
            _roleRepo = _unitOfWork.GetRepository<Role>();
            _userInRoleRepo = _unitOfWork.GetRepository<UserInRole>();

        }
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            if (!id.HasValue) throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);

            var _user = _userRepo.GetById(id.Value);

            if (_user == null) throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);

            var _userRoles = (from rr in _roleRepo.GetAll()
                              join uir in _userInRoleRepo.GetAll(x => x.UserId == id) on rr.ID equals uir.RoleId into luir
                              from uir in luir.DefaultIfEmpty()
                              select new SelectListItem
                              {
                                  Text = rr.Name,
                                  Value = rr.ID.ToString(),
                                  Selected = uir.ID != null
                              }).ToList();

            var result = new UserInRoleViewModel(id.Value, string.Format("{0} {1}", _user.FirstName, _user.LastName), _userRoles);

            return View(result);
        }
    }
}