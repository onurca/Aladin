using Framework.Core.Caching;
using Framework.Core.Extensions;
using Framework.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Service.Authentication
{
    public interface IRoleService
    {
        Guid[] Get(string area, string controller, string action);
        Guid[] GetUserRoles(Guid userId);
    }

    public class RoleService : Service, IRoleService
    {

        public Guid[] Get(string area, string controller, string action)
        {
            var _viewInRoles = UnitOfWork.GetRepository<ViewInRole>().GetAll().GetFromCache();

            var retVal = _viewInRoles.Where(x => x.Action == action && x.Controller == controller && x.Area == area);
            return (from vrp in retVal
                    select vrp.RoleId).ToArray();
        }

        public Guid[] GetUserRoles(Guid userId)
        {
            var _userInRoles = UnitOfWork.GetRepository<UserInRole>().GetAll().GetFromCache();

            var retVal = _userInRoles.Where(x => x.UserId == userId);

            return (from uir in retVal
                    select uir.RoleId).ToArray();
        }
    }
}
