using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class SearchStudentController : Controller
    {
        // GET: GovernmentSchemeAdmission/SearchStudent
        public ActionResult Index()
        {
            return View();
        }
    }
}