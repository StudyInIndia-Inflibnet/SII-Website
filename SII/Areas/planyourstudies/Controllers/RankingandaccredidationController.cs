using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    //  [WhitespaceFilter]
  //  [CompressContent]
    public class RankingandaccredidationController : Controller
    {
        // GET: planyourstudies/Rankingandaccredidation
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]

        public ActionResult Index()
        {
            return View();
        }
    }
}