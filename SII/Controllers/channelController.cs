using System.Web.Mvc;

namespace SII.Controllers
{
    //  [WhitespaceFilter]
    public class channelController : Controller
    {
        // GET: channel
       // [CompressContent]
        [OutputCache(Duration = 300, VaryByParam = "none")] //cached for 300 seconds  
        public ActionResult Index()
        {
            return View();
        }
    }
}