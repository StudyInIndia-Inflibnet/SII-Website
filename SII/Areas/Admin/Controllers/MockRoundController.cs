using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class MockRoundController : Controller
    {
        // GET: Admin/MockRound
        [SessionExpireAdmin]
        public ActionResult Index()
        {
            if (@Session["Name"] != null)
            {
                if ((@Session["Name"].ToString()) != "")
                    return View();
                else
                    return RedirectToAction("Index", "login", new { Area = "Admin" });
            }

            else
            {
                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }

        [SessionExpireAdmin]
        public ActionResult ViewDetails(string For = "", string PrgId = null, string Prgname = null, string Discipline_Id = null, string Discipline = null, string StudentId = null, string ReportFor = null, string InstituteAction = null)
        {
            if (@Session["Name"] != null)
            {
                if ((@Session["Name"].ToString()) != "")
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
                    TempData["InstituteAction"] = InstituteAction;

                    ViewBag.For = For;
                    ViewBag.ProgramlevelId = PrgId;
                    ViewBag.ProgramleveName = Prgname;
                    ViewBag.Discipline_Id = Discipline_Id;
                    ViewBag.Discipline = Discipline;
                    ViewBag.StudentId = StudentId;
                    ViewBag.InstituteAction = InstituteAction;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "login", new { Area = "Admin" });
                }
            }
            else
            {
                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }

        public ActionResult ViewAcadamic(string For = "", string StudentId = null, string ReportFor = null, string StudentName = null)
        {
            if (@Session["Name"] != null)
            {
                if ((@Session["Name"].ToString()) != "")
                {
                    TempData["StudentId"] = StudentId;
                    TempData["ReportFor"] = ReportFor;
                    ViewBag.For = For;
                    ViewBag.StudentId = StudentId;
                    TempData["studentid"] = StudentId;
                    return RedirectToAction("ViewDetails", "PreviewStudent", new { Area = "Admin", d = "AcademicInformation", ID = StudentId, Name = StudentName });
                }
                else return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
            else
            {

                return RedirectToAction("Index", "login", new { Area = "Admin" });
            }
        }



    }
}