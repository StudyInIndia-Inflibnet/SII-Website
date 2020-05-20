using System;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SII
{
    public static class HtmlHelpers
    {
        public static IHtmlString reCaptcha(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            string publickey = WebConfigurationManager.AppSettings["RecaptchaPublicKey"];
            sb.AppendLine("<script type=\"text/javascript\" src='https://www.google.com/recaptcha/api.js' async defer></script>");
            sb.AppendLine("");
            sb.AppendLine("<div class=\"g-recaptcha\" data-sitekey=\"" + publickey + "\"></div>");
            return MvcHtmlString.Create(sb.ToString());

        }
    }
}