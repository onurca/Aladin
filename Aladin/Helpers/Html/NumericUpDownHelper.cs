using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aladin.Helpers
{
    public static class NumericUpDownHelper
    {
        public static MvcHtmlString NumericUpDownFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, int minValue = int.MinValue, int maxValue = int.MaxValue, int step = 1)
        {
            return html.TextBoxFor(expression, new { @type = "number", @class = "form-control", @min = minValue, @max = maxValue, @step = step });
        }
    }
}