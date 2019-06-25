using Framework.Core.Extensions;
using Framework.Core.Logger;
using Framework.ViewModel;
using Kooperatif.Models;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aladin.Helpers
{
    public class ErrorHandler
    {
        public static void Configure(HttpContext httpContext, HttpServerUtility server)
        {
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            var ex = server.GetLastError();

            #region Current Route
            var location = GetCurrentRoute(httpContext);
            #endregion

            #region Log
            var _logger = DependencyResolver.Current.GetService<ILogger>();
            #endregion

            #region HttpException
            int httpStatusCode = HttpStatusCode.InternalServerError.ToInt();
            Guid correlationId = Guid.Empty;

            if (ex is HttpException)
            {
                var httpException = ex as HttpException;
                httpStatusCode = httpException.GetHttpCode();
                correlationId = _logger.Warning(ex, location);
            }
            else
            {
                correlationId= _logger.Fatal(ex, location);
            }
            #endregion

            #region Clear HttpContext
            httpContext.ClearError();
            httpContext.Response.Clear();
            #endregion

            #region Controller Factory
            ControllerContext controllerContext = new ControllerContext();
            CreateControllerContext(requestContext, httpContext, ref controllerContext);
            #endregion

            if (requestContext.HttpContext.Request.IsAjaxRequest())
            {
                var jsonResult = new JsonResult
                {
                    Data = new Result(ex is HttpException ? ex.Message : Definition.Message.Error, "", correlationId,
                           (HttpStatusCode)httpStatusCode).Json(),

                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                jsonResult.ExecuteResult(controllerContext);
            }
            else
            {
                var message = Definition.Message.Get(httpStatusCode);

                var viewResult = new ViewResult
                {
                    ViewName = "~/Views/Shared/_Error.cshtml",

                    ViewData = new ViewDataDictionary(new ErrorInfo(ex, correlationId, message, httpStatusCode, GetCurrentController(currentRouteData), GetCurrentAction(currentRouteData)))
                };

                viewResult.ExecuteResult(controllerContext);
            }

            httpContext.Response.End();
        }


        protected static void CreateControllerContext(RequestContext requestContext, HttpContext httpContext, ref ControllerContext controllerContext)
        {
            IControllerFactory factory;
            IController controller;
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            factory = ControllerBuilder.Current.GetControllerFactory();
            requestContext.RouteData.DataTokens["Area"] = "Admin";

            try
            {
                controller = factory.CreateController(requestContext, GetCurrentController(currentRouteData));
                controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);
            }
            catch (Exception)
            {
                controller = factory.CreateController(requestContext, "Main");
                controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);
            }
        }

        protected static string GetCurrentRoute(HttpContext httpContext)
        {
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = GetCurrentController(currentRouteData);
            var currentAction = GetCurrentAction(currentRouteData);
            return string.Format("{0}\\{1}", currentController, currentAction);
        }

        protected static string GetCurrentAction(RouteData currentRouteData)
        {
            var currentAction = " ";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["action"] != null && !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            return currentAction;
        }

        protected static string GetCurrentController(RouteData currentRouteData)
        {
            var currentController = " ";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentRouteData.Values["controller"].ToString();
                }
            }

            return currentController;
        }
    }
}