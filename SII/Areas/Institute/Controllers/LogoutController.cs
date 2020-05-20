using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Institute/Logout
        public ActionResult Index()
        {
            this.Session.Abandon();
            return RedirectToAction("Index", "login", new { Area = "Institute" });
            //return Redirect("~/Login");
            //return View();
        }
    }
}