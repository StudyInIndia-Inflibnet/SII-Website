﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII
{
    public class CloseStudentChoiceFillingJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if(HttpContext.Current.Session["submitChoiceFill"]!= null)
            //{
            //    if (HttpContext.Current.Session["submitChoiceFill"].ToString().ToLower() == "true")
            //    {
            //        filterContext.Result = new RedirectResult("~/admission/StudentChoiceFilling/SubmittedJson");
            //        return;
            //    }
            //}


            if (HttpContext.Current.Session["OpenChoiceFilling_"] != null)
            {
                if (HttpContext.Current.Session["OpenChoiceFilling_"].ToString().ToLower() == "true")
                {
                    filterContext.Result = new RedirectResult("~/admission/StudentChoiceFilling/SubmittedJson");
                    return;
                }
            }
            if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["StudentChoiceFillingDateTime"].ToString()) && HttpContext.Current.Session["isTestStudent"].ToString().ToLower() != "true")
            {
                filterContext.Result = new RedirectResult("~/admission/StudentChoiceFilling/CloseJson");
                return;
            }

            //if (HttpContext.Current.Session["IndividualOpenChoiceFilling_"] != null)
            //{
            //    if (HttpContext.Current.Session["IndividualOpenChoiceFilling_"].ToString().ToLower() == "false")
            //    {
            //        if (HttpContext.Current.Session["OpenChoiceFilling_"] != null)
            //        {
            //            if (HttpContext.Current.Session["OpenChoiceFilling_"].ToString().ToLower() == "true")
            //            {
            //                filterContext.Result = new RedirectResult("~/admission/StudentChoiceFilling/SubmittedJson");
            //                return;
            //            }
            //        }
            //        if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["StudentChoiceFillingDateTime"].ToString()))
            //        {
            //            filterContext.Result = new RedirectResult("~/admission/StudentChoiceFilling/CloseJson");
            //            return;
            //        }
            //    }
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}