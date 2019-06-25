using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Aladin.Helpers
{
    public static class TextBoxForHelper
    {
        public static MvcHtmlString DisableIf(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (expression.Invoke())
            {
                var html = htmlString.ToString();
                const string disabled = "\"disabled\"";
                html = html.Insert(html.IndexOf(">", StringComparison.Ordinal), " disabled= " + disabled);
                return new MvcHtmlString(html);
            }
            return htmlString;
        }

        public static MvcHtmlString BootstrapTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null,
            bool displayPlaceHolder = false)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            attributes.Add("class", "form-control");

            MvcHtmlString displayName = new MvcHtmlString("");

            if (displayPlaceHolder)
            {
                displayName = html.DisplayNameFor(expression);
                attributes.Add("@placeholder", displayName);
            }
            return html.TextBoxFor(expression, attributes);
        }

        public static MvcHtmlString BootstrapTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null,
           bool displayPlaceHolder = false)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            attributes.Add("class", "form-control");

            MvcHtmlString displayName = new MvcHtmlString("");

            if (displayPlaceHolder)
            {
                displayName = html.DisplayNameFor(expression);
                attributes.Add("@placeholder", displayName);
            }
            return html.TextAreaFor(expression, attributes);
        }


        public static MvcHtmlString BootstrapPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, bool displayPlaceHolder = false)
        {
            MvcHtmlString displayName = new MvcHtmlString("");

            if (displayPlaceHolder)
            {
                displayName = html.DisplayNameFor(expression);
            }

            return html.TextBoxFor(expression, new { @class = "form-control", @type = "password", @placeholder = displayName });
        }
    }
}