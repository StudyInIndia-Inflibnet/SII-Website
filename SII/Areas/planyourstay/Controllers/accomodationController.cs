using System.Web.Mvc;

namespace SII.Areas.planyourstay.Controllers
{
    //  [WhitespaceFilter]
    //  [CompressContent]
    public class accomodationController : Controller
    {
        // GET: planyourstay/accomodation
       // 
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}