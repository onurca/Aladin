using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aladin.Helpers
{
    public static class DatePickerHelpers
    {
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            return html.TextBoxFor(expression, new { data_datepicker_active = true ,@class="form-control"});
        }
    }
}