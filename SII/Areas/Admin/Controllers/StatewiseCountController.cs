using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class StatewiseCountController : Controller
    {
        // GET: Admin/StatewiseCount
        public ActionResult Index()
        {
            return View();
        }
    }
}