using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class AdmittedStudentSecondRoundController : Controller
    {
        // GET: Institute/AdmittedStudentSecondRound
        public ActionResult Index()
        {
            return View();
        }
    }
}