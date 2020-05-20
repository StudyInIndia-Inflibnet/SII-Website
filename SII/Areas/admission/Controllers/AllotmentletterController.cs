using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class AllotmentletterController : Controller
    {
        // GET: admission/Allotmentletter
        [SessionExpireStudent]
        public ActionResult Index()
        {
            return View();
        }
    }
}