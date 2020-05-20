using System.Web.Mvc;

namespace SII.Areas.planyourstay.Controllers
{
    //[WhitespaceFilter]
    //   [CompressContent]
    public class helplinenosController : Controller
    {
        // GET: planyourstay/helplinenos
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}