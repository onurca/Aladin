using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aladin.Helpers
{
    public static class DropDownListHelper
    {
        public static MvcHtmlString BootstrapEnumFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            return html.EnumDropDownListFor(expression, new { @class = "form-control" });
        }
    }
}