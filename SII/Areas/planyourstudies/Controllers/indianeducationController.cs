using System.Web.Mvc;

namespace SII.Areas.planyourstudies.Controllers
{
    //  [WhitespaceFilter]
   // [CompressContent]
    public class indianeducationController : Controller
    {
        // GET: planyourstudies/indianeducation
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]

        public ActionResult Index()
        {
            return View();
        }
    }
}