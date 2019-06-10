using Framework.Core.Extensions;
using Framework.Core.Session;
using Framework.Model.Authentication.Enum;
using Framework.Service.Authentication;
using Framework.ViewModel;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aladin.Core.Filter
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomAuthenticationAttribute : ActionFilterAttribute
    {
        public AuthenticationType AuthenticationType;
        IRoleService _roleService;

        public CustomAuthenticationAttribute(AuthenticationType type)
        {
            AuthenticationType = type;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = SessionManager.User;

            if (user.IsAuthenticated && user.Password == user.IdentificationNumber)
            {
                filterContext.Result = new RedirectResult(Definition.Url.Authentication.Settings);
            }
            else
            {

                switch (AuthenticationType)
                {
                    case AuthenticationType.Secure:
                        _roleService = DependencyResolver.Current.GetService<IRoleService>();
                        var controller = filterContext.HttpContext.Request.RequestContext.RouteData.GetRequiredString("controller").ToLowerInvariant();
                        var action = filterContext.HttpContext.Request.RequestContext.RouteData.GetRequiredString("action").ToLowerInvariant();
                        var area = filterContext.HttpContext.Request.RequestContext.RouteData.GetRequiredString("area").ToLowerInvariant();

                        var requiredRoles = _roleService.Get(area, controller, action);


                        if (user.IsAuthenticated)
                        {
                            if (!user.IsInRole(requiredRoles))
                            {
                                throw new HttpException(HttpStatusCode.Unauthorized.ToInt(), Definition.Message.Authentication.Unauthorized);
                            }
                        }
                        else
                        {

                            var returnUrl = filterContext.HttpContext.Request.Path;

                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                            {
                                action = "login",
                                controller = "authentication",
                                //area = "admin",
                                returnUrl
                            }));
                        }
                        break;
                    default:
                        break;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}