using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class CourseSelectedController : Controller
    {
        // GET: Institute/CourseSelected
        public ActionResult Index()
        {
            if (Session["InstituteType"] != null)
            {
                if (Session["InstituteType"].ToString().ToLower() != "public")
                {
                    return Redirect("~/Institute/Dashboard");
                }
            }
            return View();
        }
        public ActionResult StudentData(string id = "")
        {
            if (Session["InstituteType"] != null)
            {
                if (Session["InstituteType"].ToString().ToLower() != "public")
                {
                    return Redirect("~/Institute/Dashboard");
                }
            }
            if (id == "")
            {
                return Redirect("~/Institute/CourseSelected");
            }
            ViewBag.studentid = id;
            return View();
        }
    }
}