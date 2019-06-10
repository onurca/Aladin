using Framework.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Framework.Core
{
    public static partial class LinqExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, GridSettings settings) where T : AuditableEntity
        {
            return query.Skip((settings.CurrentPage - 1) * settings.PageCount)
                        .Take(settings.PageCount);
        }

        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey, string[] searchOn)
        {
            return FullTextSearch<T>(queryable, searchKey, false, searchOn);
        }

        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey)
        {
            return FullTextSearch<T>(queryable, searchKey, false, new string[] { });
        }

        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey, bool exactMatch, string[] searchOn)
        {

            if (string.IsNullOrEmpty(searchKey)) return queryable;

            ParameterExpression parameter = Expression.Parameter(typeof(T), "c");
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            // MethodInfo toStringMethod = typeof (object).GetMethod("ToString", new Type[] {});


            var publicProperties =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          .Where(p => p.PropertyType == typeof(string) && ((searchOn.Length > 0 && searchOn.Contains(p.Name)) || (searchOn.Length == 0)));
            Expression orExpressions = null;
            string[] searchKeyParts;

            if (searchKey == null)
            {
                searchKey = "0";
            }
            searchKeyParts = !exactMatch ? searchKey.Split(' ') : new[] { searchKey };


            foreach (MethodCallExpression callContainsMethod in from property in publicProperties
                                                                select Expression.Property(parameter, property) into nameProperty
                                                                from searchKeyPart in searchKeyParts

                                                                let searchKeyExpression = Expression.Constant(searchKeyPart)
                                                                let containsParamConverted = Expression.Convert(searchKeyExpression, typeof(string))

                                                                select Expression.Call(nameProperty, containsMethod, (Expression)containsParamConverted))
            {
                if (orExpressions == null)
                {
                    orExpressions = callContainsMethod;
                }
                else
                {
                    orExpressions = Expression.Or(orExpressions, callContainsMethod);
                }
            }


            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryable.ElementType },
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(orExpressions, new ParameterExpression[] { parameter }));

            return queryable.Provider.CreateQuery<T>(whereCallExpression);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string name)
        {
            if (string.IsNullOrEmpty(name)) return query;

            var propInfo = GetPropertyInfo(typeof(T), name);
            var expr = GetOrderExpression(typeof(T), propInfo);

            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
        }

        private static PropertyInfo GetPropertyInfo(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name == name);
            if (matchedProperty == null)
                throw new ArgumentException("name");

            return matchedProperty;
        }

        private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }

        //public static IEnumerable<T> WhereAtLeastOneProperty<T, PropertyType>(this IEnumerable<T> source, Predicate<PropertyType> predicate)
        //{
        //    var properties = typeof(T).GetProperties().Where(prop => prop.CanRead && prop.PropertyType == typeof(PropertyType)).ToArray();
        //    return source.Where(item => properties.Any(prop => PropertySatisfiesPredicate(predicate, item, prop)));
        //}

        //private static bool PropertySatisfiesPredicate<T, PropertyType>(Predicate<PropertyType> predicate, T item, PropertyInfo prop)
        //{
        //    try
        //    {
        //        return predicate((PropertyType)prop.GetValue(item));
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}

