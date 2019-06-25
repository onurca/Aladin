using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aladin.Helpers
{
    public static class MultiSelectHelpers
    {
        public static MvcHtmlString MultiSelectFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression,List<SelectListItem> list)
        {
            return html.DropDownListFor(expression,list, new { @class = "form-control",@multiple ="multiple",@data_multiselect_active=true });
        }
    }
}