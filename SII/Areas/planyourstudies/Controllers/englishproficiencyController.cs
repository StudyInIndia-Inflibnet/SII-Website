using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    // [WhitespaceFilter]
  //  [CompressContent]
    public class englishproficiencyController : Controller
    {
        // GET: planyourstudies/englishproficiency
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}