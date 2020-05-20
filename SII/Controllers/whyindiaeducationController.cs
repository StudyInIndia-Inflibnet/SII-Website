using System.Web.Mvc;

namespace SII.Controllers
{
    //[WhitespaceFilter]
  //   [CompressContent]
    public class whyindiaeducationController : Controller
    {
        // GET: whyindiaeducation
        //[CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}