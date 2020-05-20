using System.Web.Mvc;

namespace SII.Controllers
{
    public class newsboardController : Controller
    {
        // GET: newsboard
      //  [CompressContent]
        public ActionResult Index()
        {
            return View();
        }
    }
}