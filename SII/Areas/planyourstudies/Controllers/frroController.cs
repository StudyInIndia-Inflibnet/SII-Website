using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    // [WhitespaceFilter]
 //   [CompressContent]
    public class frroController : Controller
    {
        // GET: planyourstudies/frro
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]

        public ActionResult Index()
        {
            return View();
        }
    }
}