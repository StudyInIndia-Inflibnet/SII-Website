using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class ViewInstituteGlanceController : Controller
    {
        // GET: Admin/ViewInstituteGlance
        public ActionResult Index()
        {
            DashboardRepository _objRepository = new DashboardRepository();
            DataSet _ds = _objRepository.Select_Admin_Dashboard_Institute_SeatMatrix_Counts();
            ViewBag.DS = _ds;
            int TotalSeats = 0;
            int TotalG1 = 0;
            int TotalG2 = 0;
            int TotalG3 = 0;
            int TotalG4 = 0;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow _dr in _ds.Tables[0].Rows)
                    {
                        TotalSeats = TotalSeats + Convert.ToInt32(_dr["SeatForForeignStudent"].ToString());
                        TotalG1 = TotalG1 + Convert.ToInt32(_dr["G1SeatWaiver"].ToString());
                        TotalG2 = TotalG2 + Convert.ToInt32(_dr["G2SeatWaiver"].ToString());
                        TotalG3 = TotalG3 + Convert.ToInt32(_dr["G3SeatWaiver"].ToString());
                        TotalG4 = TotalG4 + Convert.ToInt32(_dr["G4SeatWaiver"].ToString());
                    }
                }
            }
            ViewBag.TotalSeats = TotalSeats;
            ViewBag.TotalG1 = TotalG1;
            ViewBag.TotalG2 = TotalG2;
            ViewBag.TotalG3 = TotalG3;
            ViewBag.TotalG4 = TotalG4;
            return View();
        }
        public ActionResult Institutes(string ID = "")
        {
            ViewBag.InstituteID = ID;
            return View();
        }
        public ActionResult Course(string ID = "")
        {
            ViewBag.InstituteCourseID = ID;
            return View();
        }
    }
}