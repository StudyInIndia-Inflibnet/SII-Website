using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireAttribute]
    [NoDirectAccessLearner]
    public class ChoiceFillingNewController : Controller
    {
        // GET: admission/ChoiceFillingNew
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Dashboard", new { area = "admission" });
        }
    }
}