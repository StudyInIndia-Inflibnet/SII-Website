using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class CourseDataController : Controller
    {
        // GET: Admin/CourseData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Phase2()
        {
            return View();
        }

        public PartialViewResult _Phase2NicheCourse()
        {
            return PartialView();
        }

    }
}