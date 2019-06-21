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
    public partial class UserController : AuthenticatedController
    {
        IRepository<User> _userRepo;
        User _user;

        public UserController()
        {
            _userRepo = _unitOfWork.GetRepository<User>();
        }
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            _user = id.HasValue ? _userRepo.GetById(id.Value) : new User();

            if (_user != null)
            {
                _user.IdentificationNumber = _user.IdentificationNumber;
                _user.Password = _user.Password;
            }
            else
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);
            }

            return View(_user);
        }
    }
}