using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class SessionExpireInstitute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["InstituteID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Institute/Logout");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}