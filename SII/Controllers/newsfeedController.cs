using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Controllers
{
    public class newsfeedController : Controller
    {
        // GET: newsfeed
        public ActionResult Index()
        {
            return View();
        }
    }
}