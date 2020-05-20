using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class InstituteDataController : Controller
    {
        // GET: Admin/InstituteData
        public ActionResult Index(string Mode="")
        {
            if (Mode == "" )
            {
                TempData["Mode"] = "0";
            }
            else
            {
                TempData["Mode"] = Mode;
            }
            TempData.Keep("Mode");
            return View();
        }
    }
}