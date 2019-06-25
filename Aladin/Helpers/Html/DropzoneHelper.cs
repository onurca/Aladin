using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Aladin.Helpers
{
    public static class DropzoneHelper
    {
        public static HtmlString Dropzone(this HtmlHelper html)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<div class='jumbotron'>");
            builder.Append(string.Format("<form method='POST' enctype='multipart/form-data' class='dropzone' id='dropzone'>"));
            builder.Append("<div class='fallback'>");
            builder.Append("<input name='file' type='file' multiple/></div></form></div>");

            return new HtmlString(builder.ToString());
        }
    }
}