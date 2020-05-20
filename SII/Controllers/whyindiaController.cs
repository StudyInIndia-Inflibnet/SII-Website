using System.Web.Mvc;

namespace SII.Controllers
{
    // [WhitespaceFilter]
  //   [CompressContent]
    public class whyindiaController : Controller
    {
        // GET: whyindia
       // 
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}