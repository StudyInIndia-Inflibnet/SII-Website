using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class CloseStudentRegistrationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["StudentRegistrationCloseDateTime"].ToString()))
            {
                filterContext.Result = new RedirectResult("~/admission/login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}