using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class AgencyChoiceFillingListController : Controller
    {
        // GET: GovernmentSchemeAdmission/AgencyChoiceFillingList
        public ActionResult Index()
        {
            Session["submitChoiceFill"] = "false";
            return View();
        }
    }
}