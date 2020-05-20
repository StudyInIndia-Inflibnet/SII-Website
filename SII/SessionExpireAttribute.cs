using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class SessionExpireAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["studentid"] == null)
            {
                filterContext.Result = new RedirectResult("~/admission/Logout");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}