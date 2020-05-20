using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Admin/MockRound
        #region Phase - 1
        [SessionExpireAdmin]
        public ActionResult Index()
        {
            if ((@Session["Name"].ToString()) != "" && (@Session["Name"]) != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }

        [SessionExpireAdmin]
        public ActionResult ViewDetails(string For = "", string PrgId = null, string Prgname = null, string Discipline_Id = null, string Discipline = null, string StudentId = null, string ReportFor = null, string CountFor = null, string InstituteID = null)
        {
            if ((@Session["Name"].ToString()) != "" && (@Session["Name"]) != null)
            {

                TempData.Keep("InstituteID");
                TempData.Keep("InstituteName");
                TempData["For"] = For;
                TempData["ProgramlevelId"] = PrgId;
                TempData["ProgramleveName"] = Prgname;
                TempData["Discipline_Id"] = Discipline_Id;
                TempData["Discipline"] = Discipline;
                TempData["StudentId"] = StudentId;
                TempData["ReportFor"] = ReportFor;
                TempData["CountFor"] = CountFor;
                TempData["InstituteID"] = InstituteID; 
                ViewBag.For = For;
                ViewBag.ProgramlevelId = PrgId;
                ViewBag.ProgramleveName = Prgname;
                ViewBag.Discipline_Id = Discipline_Id;
                ViewBag.Discipline = Discipline;
                ViewBag.StudentId = StudentId;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }
        #endregion

        #region Phase - 2
        [SessionExpireAdmin]
        public ActionResult Phase2()
        {
            return View();
        }
        [SessionExpireAdmin]
        public ActionResult ViewDetailsPhase2(string For = "", string PrgId = null, string Prgname = null, string Discipline_Id = null, string Discipline = null, string StudentId = null, string ReportFor = null, string CountFor = null, string InstituteID = null)
        {
            if ((@Session["Name"].ToString()) != "" && (@Session["Name"]) != null)
            {

                TempData.Keep("InstituteID");
                TempData.Keep("InstituteName");
                TempData["For"] = For;
                TempData["ProgramlevelId"] = PrgId;
                TempData["ProgramleveName"] = Prgname;
                TempData["Discipline_Id"] = Discipline_Id;
                TempData["Discipline"] = Discipline;
                TempData["StudentId"] = StudentId;
                TempData["ReportFor"] = ReportFor;
                TempData["CountFor"] = CountFor;
                TempData["InstituteID"] = InstituteID;
                ViewBag.For = For;
                ViewBag.ProgramlevelId = PrgId;
                ViewBag.ProgramleveName = Prgname;
                ViewBag.Discipline_Id = Discipline_Id;
                ViewBag.Discipline = Discipline;
                ViewBag.StudentId = StudentId;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }
        #endregion
    }
}