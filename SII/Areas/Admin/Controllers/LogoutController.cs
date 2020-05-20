using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Index()
        {
            this.Session.Abandon();
            return RedirectToAction("Index", "login", new { Area = "Admin" });
           // return View();
        }
    }
}