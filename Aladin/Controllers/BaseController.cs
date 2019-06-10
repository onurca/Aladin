using Framework;
using Framework.Core.Logger;
using Framework.Core.Session;
using Framework.Service.Authentication;
using Framework.ViewModel;
using Aladin.Core.Filter;
using System.Web.Mvc;

namespace Aladin.Controllers
{
    [ValidateModel]
    public class BaseController : Controller
    {
        protected ILogger _logger;
        protected IUnitOfWork _unitOfWork;
        protected IRoleService _roleService;

        protected bool IsAuthenticated
        {
            get
            {
                return SessionManager.User.IsAuthenticated;
            }
        }

        public BaseController()
        {
            _logger = DependencyResolver.Current.GetService<ILogger>();
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            _roleService = DependencyResolver.Current.GetService<IRoleService>();

            if (IsAuthenticated)
            {
                SessionManager.User.Roles = _roleService.GetUserRoles(SessionManager.User.ID);
            }
        }

        protected JsonResult Result(Result data, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return base.Json(data.Json(), behavior);
        }

        protected JsonResult Result<T>(Result<T> data, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet) where T : class
        {
            return base.Json(data.Json(), behavior);
        }
    }
}