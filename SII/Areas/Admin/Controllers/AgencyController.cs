using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]    
    public class AgencyController : Controller
    {
        // GET: Admin/Agency
        public ActionResult Index()
        {
            return View();
        }
    }
}