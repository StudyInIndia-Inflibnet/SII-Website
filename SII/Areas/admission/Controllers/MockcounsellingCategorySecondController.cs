using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class MockcounsellingCategorySecondController : Controller
    {
        // GET: admission/MockcounsellingCategorySecond
        public ActionResult Index()
        {
            return View();
        }
    }
}