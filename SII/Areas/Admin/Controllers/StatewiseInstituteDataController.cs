using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class StatewiseInstituteDataController : Controller
    {
        // GET: Admin/StatewiseInstituteData
        public ActionResult Index(string stateid= "")
        {
            if (stateid == "")
            {
                TempData["stateid"] = "0";
            }
            else
            {
                TempData["stateid"] = stateid;
            }
            TempData.Keep("stateid");
            return View();
        }
    }
}