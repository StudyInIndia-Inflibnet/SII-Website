using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class SessionExpiregov:System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["Gov_User_id"] == null)
            {
                filterContext.Result = new RedirectResult("~/GovernmentSchemeAdmission/Logoutgov");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}