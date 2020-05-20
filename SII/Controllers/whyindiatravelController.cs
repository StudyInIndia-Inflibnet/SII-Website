using System.Web.Mvc;

namespace SII.Controllers
{
    //  [WhitespaceFilter]
   // [CompressContent]
    public class whyindiatravelController : Controller
    {
        // GET: whyindiatravel
        //[CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}