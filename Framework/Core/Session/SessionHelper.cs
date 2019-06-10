using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Framework.Core.Session
{

    public static class SessionHelper
    {
        public static T Get<T>(string key)
        {
            object sessionObject = HttpContext.Current.Session[key];
            if (sessionObject == null)
            {
                return default(T);
            }
            return (T)HttpContext.Current.Session[key];
        }

        public static T Get<T>(string key, T defaultValue)
        {
            try
            {
                object sessionObject = HttpContext.Current.Session[key];
                if (sessionObject == null)
                {
                    HttpContext.Current.Session[key] = defaultValue;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }

            return (T)HttpContext.Current.Session[key];
        }

        public static void Save<T>(string key, T entity)
        {
            HttpContext.Current.Session[key] = entity;
        }

        public static void Save<T>(string key, T entity, TimeSpan timeout)
        {
            HttpContext.Current.Session.AddWithTimeout(key, entity, timeout);
        }

        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public static void AddWithTimeout(this HttpSessionState session, string name, object value, TimeSpan expireAfter)
        {
            lock (session)
            {
                session[name] = value;
            }

            //add cleanup task that will run after "expire"
            Task.Delay(expireAfter).ContinueWith((task) =>
            {
                lock (session)
                {
                    session.Remove(name);
                }
            });
        }
    }
}
