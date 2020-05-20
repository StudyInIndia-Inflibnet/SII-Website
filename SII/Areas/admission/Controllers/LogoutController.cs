using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class LogoutController : Controller
    {
        // GET: admission/Logout
        public ActionResult Index()
        {
            this.Session.Abandon();
            return RedirectToAction("Index", "login", new { Area = "admission" });
            //return Redirect("~/Login");
            //return View();
        }
        public JsonResult LogoutJson()
        {
            Session.Abandon();
            string Message = string.Empty, Code = string.Empty;
            Message = "Your session has been expired. Kindly login again.";
            Code = "sessionexpired";
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}