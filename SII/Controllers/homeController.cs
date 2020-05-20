using System.Web.Mvc;

namespace SII.Controllers
{
 //   [CompressContent]
    public class homeController : Controller
    {
        // GET: Home
        //[OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            // ViewBag.Metatitle = "Study in India | Explore Higher Education Courses | Plan Your Stay";
            //  ViewBag.MetaDescription = "Official Government of India website to find everything you need to know about studying and living in India. Simply sign up and apply to thetop colleges of India offering quality education at affordable costs. Know about courses, colleges, fee waivers, admission fees, visa requirements for Studying in India.";
            return View();
        }
    }
}