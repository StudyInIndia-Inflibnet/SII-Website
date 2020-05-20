using System.Configuration;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            Session["Phase"] = "Phase-1";
            Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
            if (Session["is_doc_verification"].ToString().ToLower() == "true" && Session["is_admin"].ToString().ToLower() == "false")
            {
                return Redirect("~/Admin/VerifyDocuments");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Phase2()
        {
            Session["Phase"] = "Phase-2";
            Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
            if (Session["is_doc_verification"].ToString().ToLower() == "true" && Session["is_admin"].ToString().ToLower() == "false")
            {
                return Redirect("~/Admin/VerifyDocuments");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Phase3()
        {
            Session["Phase"] = "Phase-3";
            Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
            if (Session["is_doc_verification"].ToString().ToLower() == "true" && Session["is_admin"].ToString().ToLower() == "false")
            {
                return Redirect("~/Admin/VerifyDocuments");
            }
            else
            {
                return View();
            }
        }
    }
}