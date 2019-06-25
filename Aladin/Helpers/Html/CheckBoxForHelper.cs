using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aladin.Helpers
{
    public static class CheckBoxForHelper
    {
        public static MvcHtmlString BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            return html.CheckBoxFor(expression, new { @class = "form-control" });
        }
    }
}