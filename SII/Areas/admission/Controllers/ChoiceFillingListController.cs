using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class ChoiceFillingListController : Controller
    {
        // GET: admission/ChoiceFillingList
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Dashboard", new { area = "admission" });
        }
    }
}