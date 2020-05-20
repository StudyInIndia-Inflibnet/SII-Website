using System.Web.Mvc;

namespace SII.Controllers
{
    // [WhitespaceFilter]
    public class contactController : Controller
    {
        // GET: contact
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}