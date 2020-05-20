using System.Web.Mvc;

namespace SII.Controllers
{
    //[WhitespaceFilter]
    public class institutesController : Controller
    {
        // GET: institutes
     //   [CompressContent]
        public ActionResult Index()
        {
            return View();
        }
    }
}