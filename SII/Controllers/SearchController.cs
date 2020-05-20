using System.Web.Mvc;

namespace SII.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string id = "")
        {
            ViewBag.SearchString = id;
            return View();
        }
    }
}