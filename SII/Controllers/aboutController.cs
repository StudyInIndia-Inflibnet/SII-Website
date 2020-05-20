using System.Web.Mvc;

namespace SII.Controllers
{
    // [WhitespaceFilter]
    public class aboutController : Controller
    {
        // GET: about
        //[CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")] //cached for 300 seconds  
        public ActionResult Index()
        {
           // ViewBag.MetaKeywords = "Universities in India,Best University,Education in India";
         //   ViewBag.MetaDescription = "Official Government of India website to find everything you need to know about studying and living in India. Simply sign up and apply to thetop colleges of India offering quality education at affordable costs. Know about courses, colleges, fee waivers, admission fees, visa requirements for Studying in India.";
            return View();
        }
    }
}