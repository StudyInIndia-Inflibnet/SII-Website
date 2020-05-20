using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    public class LogoutgovController : Controller
    {
        // GET: GovernmentSchemeAdmission/Logoutgov
        public ActionResult Index()
        {
            this.Session.Abandon();
            return RedirectToAction("Index", "login", new { Area = "GovernmentSchemeAdmission" });
            //return Redirect("~/Login");
        }
    }
}