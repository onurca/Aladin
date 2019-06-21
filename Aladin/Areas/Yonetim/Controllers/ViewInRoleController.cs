using Framework.Core.Extensions;
using Framework.Model.Authentication;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class ViewInRoleController : AuthenticatedController
    {
        public ActionResult Item(Guid ID)
        {
            var roles = _unitOfWork.GetRepository<Role>().GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString(),
            }).ToList();

            var result = new ViewInRoleViewModel();
            result.RoleId = ID;
            result.Roles = roles;

            return View(result);
        }

        public PartialViewResult Actions(Guid RoleId)
        {
            var _roleRepo = _unitOfWork.GetRepository<Role>();
            var _viewInRoleRepo = _unitOfWork.GetRepository<ViewInRole>();

            var selectedViews = _viewInRoleRepo.GetAll(x => x.RoleId == RoleId).ToList();
            var viewsWithControllerGroup = GetViews();


            foreach (var item in viewsWithControllerGroup)
            {
                var areaControllerAction = item.Value.ToLowerInvariant().Split('.');
                var area = areaControllerAction[0];
                var controller = areaControllerAction[1];
                var action = areaControllerAction[2];

                item.Selected = selectedViews.Any(x => x.Area == area && x.Controller == controller && x.Action == action);
            }

            var result = new ViewInRoleViewModel(RoleId, viewsWithControllerGroup);

            return PartialView(result);
        }
    }
}