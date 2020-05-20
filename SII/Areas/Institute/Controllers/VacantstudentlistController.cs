using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class VacantstudentlistController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Vacantstudentlist
        public ActionResult Index()
        {
            return View();
        }
    }
}