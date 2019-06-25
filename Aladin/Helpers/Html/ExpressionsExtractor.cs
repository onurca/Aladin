using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Aladin.Helpers.Html
{
    public static class ExpressionsExtractor
    {
        public static string Lookup<T, TProp>(this HtmlHelper<T> html, Expression<Func<T, TProp>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                return null;

            return memberExpression.Member.Name;
        }
    }
}