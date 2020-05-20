using System.Web.Mvc;

namespace SII.Controllers
{
    //[WhitespaceFilter]
 //   [CompressContent]
    public class whyindiaexperiencesController : Controller
    {
        // GET: whyindiaexperiences
      //  [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}