using Framework.Core.Extensions;
using Framework.ViewModel;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aladin.Core.Filter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;

            if (!modelState.IsValid)
            {
                string[] errors = modelState
                                       .Where(d => d.Value.Errors.Count > 0)
                                       .Select(d => d.Value.Errors.First().ErrorMessage)
                                       .ToArray();
                var message = string.Join("<br />", errors);

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new Result(message, "", Guid.Empty, HttpStatusCode.BadRequest),
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    throw new HttpException(HttpStatusCode.BadRequest.ToInt(), message);
                }
            }
        }
    }
}