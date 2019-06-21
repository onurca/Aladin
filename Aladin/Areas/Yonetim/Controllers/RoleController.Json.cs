using Framework.Core;
using Framework.Model.Authentication;
using Framework.ViewModel;
using Aladin.Controllers;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class RoleController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            var list = _roleRepo.GetAll().FullTextSearch(settings.Keyword);
            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings);

            return Result(new GridResult<IQueryable<Role>>(retVal, list.Count()));
        }

        [HttpPost]
        public JsonResult Create(Role role)
        {
            _roleRepo.Create(role);
            _unitOfWork.SaveChanges();

            return Result(new Result<Role>(role, Definition.Message.Created));
        }

        [HttpPost]
        public JsonResult Update(Role role)
        {
            _roleRepo.Update(role);
            _unitOfWork.SaveChanges();

            return Result(new Result(Definition.Message.Updated));
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _roleRepo.Delete(id);
            _unitOfWork.SaveChanges();

            return Result(new Result(Definition.Message.Deleted));
        }
    }
}