﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Controllers
{
    public class blogsController : Controller
    {
        // GET: blogs
        public ActionResult Index()
        {
            return View();
        }
    }
}