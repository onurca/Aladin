namespace Framework.Core.Caching
{
    public abstract class CacheProvider
    {
        public static int CacheDuration = 60;
        public static CacheProvider Instance { get; set; }

        public abstract object Get(string key);
        public abstract void Set(string key, object value);
        public abstract bool IsExist(string key);
        public abstract void Remove(string key);
    }
}
