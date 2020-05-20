using System.Web.Mvc;

namespace SII.Areas.planyourstay.Controllers
{
    //  [WhitespaceFilter]
    //    [CompressContent]
    public class dosanddontsController : Controller
    {
        // GET: planyourstay/dosanddonts
       // 
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}