using Aladin.Helpers.Html;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Aladin.Helpers
{
    public static class AutocompleteHelpers
    {
        public static MvcHtmlString AutocompleteFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, string url,string selectedValue="",
            object htmlAttributes = null)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            attributes.Add("Value", selectedValue);
            attributes.Add("data-autocomplete-url", url);
            attributes.Add("class", "form-control");
            attributes.Add("Name", string.Format("{0}{1}", html.Lookup(expression), "autocomplete"));

            return html.TextBoxFor(expression, attributes).Concat(html.HiddenFor(expression));
        }

        public static MvcHtmlString Concat(this MvcHtmlString first, params MvcHtmlString[] strings)
        {
            return MvcHtmlString.Create(first.ToString() + string.Concat(strings.Select(s => s.ToString())));
        }
    }
}