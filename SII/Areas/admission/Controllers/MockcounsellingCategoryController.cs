using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class MockcounsellingCategoryController : Controller
    {
        // GET: admission/MockcounsellingCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}