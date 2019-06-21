using Framework.Model.Authentication;
using Framework.Service.Authentication;
using Framework.ViewModel;
using Aladin.Areas.Yonetim.Models;
using Aladin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Aladin.Core.Filter;
using Framework.Model.Authentication.Enum;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class ViewInRoleController : AuthenticatedController
    {
        public JsonResult Update(ViewInRoleViewModel model)
        {
            var _viewInRoleRepo = _unitOfWork.GetRepository<ViewInRole>();

            _viewInRoleRepo.Delete(x => x.RoleId == model.RoleId);

            foreach (var item in model.ViewNames)
            {
                var areaControllerAction = item.ToLowerInvariant().Split('.');
                var area = areaControllerAction[0];
                var controller = areaControllerAction[1];
                var action = areaControllerAction[2];
                _viewInRoleRepo.Create(new ViewInRole(model.RoleId, area, controller, action));
            }

            _unitOfWork.SaveChanges();

            return Result(new Result(Definition.Message.Updated));
        }

        private List<SelectListItem> GetViews()
        {
            var _assembly = Assembly.GetExecutingAssembly();

            var groupList = _assembly.GetTypes()
                   .Where(type => type.GetCustomAttributes(true).OfType<CustomAuthenticationAttribute>().Any(x => x.AuthenticationType == AuthenticationType.Secure))
                   .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                   .Where(type => !type.GetCustomAttributes().OfType<CustomAuthenticationAttribute>().Any())
                   .Select(x => new SelectListGroup
                   {
                       Name = string.Format("{0}.{1}", x.DeclaringType.Namespace.Split('.').Reverse().Skip(1).First(), x.DeclaringType.Name.Replace("Controller", "")),
                   })
                   .ToList();

            var actionList = _assembly.GetTypes()
                   .Where(type => type.GetCustomAttributes(true).OfType<CustomAuthenticationAttribute>().Any(x => x.AuthenticationType == AuthenticationType.Secure))
                   .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                   .Where(type => !type.GetCustomAttributes().OfType<CustomAuthenticationAttribute>().Any())
                   .Select(x => new SelectListItem
                   {
                       Text = x.Name,
                       Value = string.Format("{0}.{1}.{2}", x.DeclaringType.Namespace.Split('.').Reverse().Skip(1).First(), x.DeclaringType.Name.Replace("Controller", ""), x.Name),
                   })
                    .ToList();

            foreach (var item in actionList)
            {
                var groupName = string.Join(".", item.Value.Split('.').Take(2));
                item.Group = groupList.FirstOrDefault(x => groupName.ToLowerInvariant() == x.Name.ToLowerInvariant());
            }

            return actionList;
        }
    }
}