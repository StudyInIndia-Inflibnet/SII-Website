using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    //  [WhitespaceFilter]
  //  [CompressContent]
    public class visaregulationsController : Controller
    {
        // GET: planyourstudies/visaregulations
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}