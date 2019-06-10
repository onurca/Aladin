using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Framework.Core.Caching
{
    public class CacheKey
    {
        private readonly string _format = "{0}";
        protected string _generatedKey;

        public CacheKey()
        {

        }

        public CacheKey(string[] args)
        {
            _generatedKey = string.Format(_format, string.Join("-", args));
        }

        public static CacheKey New(string[] args)
        {
            return new CacheKey(args);
        }

        public override string ToString()
        {
            return _generatedKey;
        }

        internal static string New(object entity)
        {
            return entity.GetType().Name;
        }
    }

    public class CacheKey<T> : CacheKey
    {
        public CacheKey()
        {
        }

        public static string New()
        {
            return typeof(T).Name;
        }

        public static string New<T>(IQueryable<T> query)
        {
            return string.Concat(query.ToString(), "nr", typeof(T).AssemblyQualifiedName);
        }
    }
}
