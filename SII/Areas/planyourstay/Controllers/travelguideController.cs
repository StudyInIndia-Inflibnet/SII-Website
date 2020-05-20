using System.Web.Mvc;

namespace SII.Areas.planyourstay.Controllers
{
    //  [WhitespaceFilter]
    //   [CompressContent]
    public class travelguideController : Controller
    {
        // GET: planyourstay/travelguide
     //   [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}