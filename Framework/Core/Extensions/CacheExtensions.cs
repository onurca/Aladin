using Framework.Core.Caching;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Extensions
{
    public static class CacheExtension
    {
        public static IEnumerable<T> GetQueryFromCache<T>(this IQueryable<T> query)
        {
            string key = CacheKey<T>.New(query);
            object item;

            if (CacheProvider.Instance.IsExist(key))
            {
                item = CacheProvider.Instance.Get(key);
            }
            else
            {
                item = query.ToList();

                CacheProvider.Instance.Set(key, item);
            }

            foreach (var oneItem in ((List<T>)item))
            {
                yield return oneItem;
            }
        }

        public static IEnumerable<T> GetFromCache<T>(this IQueryable<T> query)
        {
            string key = CacheKey<T>.New();
            object item;

            if (CacheProvider.Instance.IsExist(key))
            {
                item = CacheProvider.Instance.Get(key);
            }
            else
            {
                item = query.ToList();

                CacheProvider.Instance.Set(key, item);
            }

            foreach (var oneItem in ((List<T>)item))
            {
                yield return oneItem;
            }
        }

        public static void RemoveFromCache<T>(this IQueryable<T> query)
        {
            string key = CacheKey<T>.New(query);

            CacheProvider.Instance.Remove(key);
        }
    }
}
