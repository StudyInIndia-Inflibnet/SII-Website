using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class DashboardController : Controller
    {
        // GET: GovernmentSchemeAdmission/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}