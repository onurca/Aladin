using System;
using System.Net;
using System.Web.Mvc;

namespace Aladin.Models
{
    public class ErrorInfo : HandleErrorInfo
    {
        public Guid CorrelationId { get; set; }
        public int HttpStatusCode { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public ErrorInfo(Exception exception, Guid correlationId, string controllerName, string actionName) : base(exception, controllerName, actionName)
        {
            CorrelationId = correlationId;
        }

        public ErrorInfo(Exception exception, Guid correlationId,string message, int httpStatusCode, string controllerName, string actionName) 
            : base(exception, controllerName, actionName)
        {
            CorrelationId = correlationId;
            Message = message;
            Title = ((HttpStatusCode)httpStatusCode).ToString();
            HttpStatusCode = httpStatusCode;
        }
    }
}