using System.Web.Mvc;

namespace SII.Areas.planyourstay.Controllers
{
    // [WhitespaceFilter]
    //   [CompressContent]
    public class moneycostsController : Controller
    {
        // GET: planyourstay/moneycosts
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}