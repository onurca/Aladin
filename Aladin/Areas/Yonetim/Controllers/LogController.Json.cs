using Framework.Core;
using Framework.Model.Logger;
using Framework.ViewModel;
using Aladin.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class LogController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            var list = _logRepo.GetAll().FullTextSearch(settings.Keyword);
            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings);

            return Result(new GridResult<IQueryable<Log>>(retVal, list.Count()));
        }
    }
}