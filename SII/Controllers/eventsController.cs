using System.Web.Mvc;

namespace SII.Controllers
{
    // [WhitespaceFilter]
    public class eventsController : Controller
    {
        // GET: events
     //   [CompressContent]
        //[OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}