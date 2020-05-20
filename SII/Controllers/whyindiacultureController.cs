using System.Web.Mvc;

namespace SII.Controllers
{
    //[WhitespaceFilter]
      // [CompressContent]
    public class whyindiacultureController : Controller
    {
        // GET: whyindiaculture
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}