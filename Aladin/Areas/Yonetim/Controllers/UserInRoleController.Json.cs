using Framework.Model.Authentication;
using Framework.Service.Authentication;
using Framework.ViewModel;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class UserInRoleController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Update(UserInRoleViewModel userInRole)
        {
            _userInRoleRepo.Delete(x => x.UserId == userInRole.UserId);

            foreach (var item in userInRole.Roles)
            {
                var _userInRole = new UserInRole
                {
                    UserId = userInRole.UserId,
                    RoleId = new Guid(item)
                };

                _userInRoleRepo.Create(_userInRole);
            }

            _unitOfWork.SaveChanges();

            var redirectUrl = Definition.Url.User.Item;

            return Result(new Result(Definition.Message.Updated, redirectUrl));
        }
    }
}