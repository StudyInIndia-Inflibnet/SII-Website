using System.Web.Mvc;

namespace SII.Controllers
{

   // [CompressContent]
    public class faqsController : Controller
    {
        // GET: faqs
     //   
        //[OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}