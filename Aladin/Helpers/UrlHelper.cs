using System.Reflection;
using System.Web.Mvc;

namespace Aladin.Helpers
{
    public static class UrlHelperExtension
    {
        public static string Version(this UrlHelper self, string contentPath)
        {
            string versionedContentPath = contentPath + "?v=" + Assembly.GetAssembly(typeof(UrlHelperExtension)).GetName().Version.ToString();
            return self.Content(versionedContentPath);
        }
    }

    public static class SystemVersion
    {
        public static string Get()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}