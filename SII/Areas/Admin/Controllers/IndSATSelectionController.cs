using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class IndSATSelectionController : Controller
    {
        // GET: Admin/IndSATSelection
        public ActionResult Index()
        {
            return View();
        }
    }
}