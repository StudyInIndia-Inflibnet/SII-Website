using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    // [WhitespaceFilter]
    //[CompressContent]
    public class DetailsofIndianEducationsController : Controller
    {
        // GET: planyourstudies/DetailsofIndianEducations
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}