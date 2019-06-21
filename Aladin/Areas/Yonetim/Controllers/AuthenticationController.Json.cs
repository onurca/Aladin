using Framework.Core.Extensions;
using Framework.Core.Session;
using Framework.Model.Authentication;
using Framework.Model.Logger.Enum;
using Framework.Service.Authentication;
using Framework.ViewModel;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aladin.Model;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class AuthenticationController : BaseController
    {
        IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        public JsonResult Logout()
        {
            SessionManager.User.Clear();

            return Result(new Result(Definition.Message.Logout.Successful, Definition.Url.Main));
        }

        [HttpPost]
        public JsonResult Login(Login model)
        {
            var user = _userService.Get(model.IdentificationNumber, model.Password);

            var result = new Result();

            if (user != null)
            {
                SessionManager.User = user;

                #region Roles
                var roles = _roleService.GetUserRoles(user.ID);
                SessionManager.User.Roles = roles;
                #endregion

                result = new Result(Definition.Message.Authentication.Successful, model.returnUrl);

                _logger.Info(InfoType.Login, "Login başarılı", "AuthenticationController.Login");
            }
            else
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Authentication.NotFound);
            }

            return Result(result);
        }


        [HttpPost]
        public JsonResult PasswordUpdate(SettingsViewModel model)
        {
            var _userRepo = _unitOfWork.GetRepository<User>();

            var entity = _userRepo.GetById(SessionManager.User.ID);

            entity.Password = model.Password;

            _userRepo.Update(entity);
            _unitOfWork.SaveChanges();

            SessionManager.User.Password = model.Password;

            var result = new Result(Definition.Message.Updated, Definition.Url.Admin.Main);

            return Result(result);
        }
    }
}