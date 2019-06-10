using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;

namespace Framework.Core.Caching
{
    public class Cache : CacheProvider
    {
        private ObjectCache _cache = null;
        private CacheItemPolicy _policy = null;

        public Cache()
        {
            Trace.WriteLine("Cache Initialize");

            _cache = MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                RemovedCallback = new CacheEntryRemovedCallback(CacheRemovedCallback),
                SlidingExpiration = TimeSpan.FromHours(12)
            };
        }

        private static void CacheRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            Trace.WriteLine("----------Cache Expire----------");
            Trace.WriteLine("Key : " + arguments.CacheItem.Key);
            Trace.WriteLine("Value : " + arguments.CacheItem.Value.ToString());
            Trace.WriteLine("RemovedReason : " + arguments.RemovedReason);
            Trace.WriteLine("-------------------------------------");
        }

        public override object Get(string key)
        {
            object retVal = null;

            try
            {
                retVal = _cache.Get(key);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception : CacheProvider.Get()\n" + e.Message);
                throw new Exception("Cache Get Exception", e);
            }

            return retVal;
        }

        public override void Set(string key, object value)
        {
            try
            {
                Trace.WriteLine("Cache Set Key : " + key);
                _cache.Set(key.ToString(), value, _policy);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception : CacheProvider.Set()\n" + e.Message);
                throw new Exception("Cache Set Exception", e);
            }
        }

        public override bool IsExist(string key)
        {
            return _cache.Any(q => q.Key == key);
        }

        public override void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
