using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class InstituteClosesCheck : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DateTime _dt = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["InstitutePortalClose"].ToString());
            
            if (DateTime.Now >= _dt)
            {
                filterContext.Result = new RedirectResult("~/Institute/Closed");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}