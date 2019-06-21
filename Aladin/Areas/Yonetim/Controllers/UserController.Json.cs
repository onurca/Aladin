using Framework.Core;
using Framework.Core.Caching;
using Framework.Core.Extensions;
using Framework.Model.Authentication;
using Framework.ViewModel;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class UserController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            var list = _userRepo.GetAll().FullTextSearch(settings.Keyword, new string[] { "FirstName", "LastName" });

            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings).Select(x => new UserViewModel()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName
            });

            return Result(new GridResult<IQueryable<UserViewModel>>(retVal, list.Count()));
        }

        [HttpPost]
        public JsonResult Create(User user)
        {
            user.IdentificationNumber = user.IdentificationNumber;
            user.Password = user.Password;

            _userRepo.Create(user);
            _unitOfWork.SaveChanges();

            var redirectUrl = string.Format("{0}/{1}", Definition.Url.UserInRole.Item, user.ID);

            return Result(new Result(Definition.Message.Created, redirectUrl));
        }

        [HttpPost]
        public JsonResult Update(User user)
        {
            user.IdentificationNumber = user.IdentificationNumber;
            user.Password = user.Password;

            _userRepo.Update(user);
            _unitOfWork.SaveChanges();

            var redirectUrl = string.Format("{0}/{1}", Definition.Url.UserInRole.Item, user.ID);

            return Result(new Result(Definition.Message.Updated, redirectUrl));
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _userRepo.Delete(id);
            _unitOfWork.SaveChanges();

            return Result(new Result(Definition.Message.Deleted));
        }


        [HttpPost]
        public JsonResult GetByName(string keyword)
        {
            keyword = keyword.Replace(" ", "").ToLowerInvariant();

            var _users = _unitOfWork.GetRepository<User>().GetAll().GetFromCache();

            var retVal = _users.Where(x => (x.FirstName + x.LastName).Replace(" ", "").ToLowerInvariant().Contains(keyword)).Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = string.Format("{0} {1}", x.FirstName, x.LastName)
            }).ToList();

            return Result(new Result<List<SelectListItem>>(retVal));
        }
    }
}
