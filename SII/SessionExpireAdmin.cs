using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class SessionExpireAdmin : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["User_Name"] == null)
            {
                filterContext.Result = new RedirectResult("~/admin/Logout");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}