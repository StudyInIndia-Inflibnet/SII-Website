using System.Web.Mvc;

namespace SII.Areas.scholarships.Controllers
{
    //[WhitespaceFilter]
   // [CompressContent]
    public class FeeWaiversandConcessionsController : Controller
    {
        // GET: scholarships/FeeWaiversandConcessions
        // [CompressContent]
        //[OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Scholarship()
        {
            return View();
        }
        public ActionResult FeeWaiver()
        {
            return View();
        }
        public ActionResult IndSAT()
        {
            return View();
        }
    }
}