using SIIModel.Admin;
using SIIRepository.Adminservice;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class StudentDataController : Controller
    {
        // GET: Admin/StudentData
        public ActionResult Index(string CountryToStay = "0", string IsPartiallySubmitted = "0")
        {

            TempData["CountryToStay"] = CountryToStay;
            TempData.Keep("CountryToStay");

            TempData["IsPartiallySubmitted"] = IsPartiallySubmitted;
            TempData.Keep("IsPartiallySubmitted");
            return View();
        }

        public ActionResult Phase2(string CountryToStay = "0", string IsPartiallySubmitted = "0")
        {

            TempData["CountryToStay"] = CountryToStay;
            TempData.Keep("CountryToStay");

            TempData["IsPartiallySubmitted"] = IsPartiallySubmitted;
            TempData.Keep("IsPartiallySubmitted");
            return View();
        }

        public ActionResult Phase3(string CountryToStay = "0", string IsPartiallySubmitted = "0")
        {

            TempData["CountryToStay"] = CountryToStay;
            TempData.Keep("CountryToStay");

            TempData["IsPartiallySubmitted"] = IsPartiallySubmitted;
            TempData.Keep("IsPartiallySubmitted");
            return View();
        }

        public ActionResult Phase2Test(string CountryToStay = "0", string IsPartiallySubmitted = "0")
        {

            TempData["CountryToStay"] = CountryToStay;
            TempData.Keep("CountryToStay");

            TempData["IsPartiallySubmitted"] = IsPartiallySubmitted;
            TempData.Keep("IsPartiallySubmitted");
            return View();
        }

        public JsonResult FillData()
        {
            string CountryToStay = TempData.Peek("CountryToStay").ToString();
            TempData.Keep("CountryToStay");
            string IsPartiallySubmitted = TempData.Peek("IsPartiallySubmitted").ToString();
            TempData.Keep("IsPartiallySubmitted");
            DashboardRepository _objRepository = new DashboardRepository();
            List<mStudentList> _list = new List<mStudentList>();
            DataSet _ds = _objRepository.sp_select_all_student_Phase2(CountryToStay, IsPartiallySubmitted, Session["Phase"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _list.Add(new mStudentList
                        {
                            RowNo = _dr["RowNo"].ToString(),
                            FirstName = _dr["FirstName"].ToString(),
                            LastName = _dr["LastName"].ToString(),
                            studentid = _dr["studentid"].ToString(),
                            Email = _dr["Email"].ToString(),
                            Mobile = _dr["Mobile"].ToString(),
                            Registerdate = _dr["Registerdate"].ToString(),
                            Country_Name = _dr["Country_Name"].ToString(),
                            Nationality = _dr["Nationality"].ToString(),
                            OverallProgress = _dr["OverallProgress"].ToString(),
                            ChoiceCount = _dr["ChoiceCount"].ToString(),
                            ChoiceFillingDate = _dr["ChoiceFillingDate"].ToString(),
                            //EditApplicationDate = (_dr["EditApplicationDate"] != null ? _dr["EditApplicationDate"].ToString() : ""),
                            nameofagency = _dr["nameofagency"].ToString()
                        });
                    }
                }
            }
            var jsonResult = Json(new { data = _list }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            
        }
    }
}