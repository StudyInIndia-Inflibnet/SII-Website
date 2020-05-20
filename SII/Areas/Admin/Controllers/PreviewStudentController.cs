using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class PreviewStudentController : Controller
    {
        // GET: Admin/PreviewStudent
        public ActionResult Index(string studentid = "", string Name = "")
        {
            TempData["studentid"] = studentid;
            TempData["studentname"] = Name;
            DashboardRepository _objRepository = new DashboardRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(studentid);
            List<Student_dashbaord> _list = new List<Student_dashbaord>();
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        Student_dashbaord _Obj = new Student_dashbaord();
                        _Obj.FirstName = _dr["FirstName"].ToString();
                        _Obj.Mobile = _dr["Mobile"].ToString();
                        _Obj.Email = _dr["Email"].ToString();
                        _Obj.DateOfBirth = _dr["DateOfBirth"].ToString();
                        _Obj.Nationality = _dr["Nationality"].ToString();
                        _Obj.PassportNo = _dr["PassportNo"].ToString();
                        _Obj.CitizenshipNumber = _dr["CitizenshipNumber"].ToString();
                        _Obj.Residential = _dr["Residential"].ToString();
                        _Obj.Permanent = _dr["Permanent"].ToString();
                        _Obj.StudentRefrenceDetail = _dr["StudentRefrenceDetail"].ToString();
                        _Obj.AcademicInformation_EC = _dr["AcademicInformation_EC"].ToString();
                        _Obj.AcademicInformation_AE = _dr["AcademicInformation_AE"].ToString();
                        _Obj.Disciplinelist = _dr["Disciplinelist"].ToString();
                        _Obj.TotalChoicefill = _dr["TotalChoicefill"].ToString();
                        _Obj.Doc_required = _dr["Doc_required"].ToString();
                        _Obj.Uploded_doc = _dr["Uploded_doc"].ToString();
                        _Obj.finalSubmit = _dr["finalSubmit"].ToString();
                        _list.Add(_Obj);

                    }
                }
            }
            ViewBag.StudentdDashboard = _list;
            return View();
        }

        public ActionResult ViewDetails(string d = "",string ID="", string Name = "")
        {
            ViewBag.DetailsFor = d;
            TempData["studentid"] = ID;
            TempData["studentname"] = Name;
            TempData.Keep("studentid");
            TempData.Keep("studentname");

            TempData.Peek("studentid");
            TempData.Peek("studentname");
            selectDropdown();
            return View();
        }

        public ActionResult _BasicInformation()
        {
            TempData.Peek("studentid");
            TempData.Peek("studentname");
            return PartialView();
        }
        public ActionResult _AcademicInformation()
        {
            TempData.Peek("studentid");
            TempData.Peek("studentname");
            return PartialView();
        }
        public ActionResult _BackgroundInformation()
        {
            TempData.Peek("studentid");
            TempData.Peek("studentname");
            return PartialView();
        }
        public ActionResult _DocumentInformation()
        {
            TempData.Peek("studentid");
            TempData.Peek("studentname");
            return PartialView();
        }

        public ActionResult _ChoicefillingInformation()
        {
            TempData.Peek("studentid");
            TempData.Peek("studentname");
            return PartialView();
        }
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Nationality> _Nationality = new List<Nationality>();
            List<Country> _Country = new List<Country>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Nationality _objpro = new Nationality();
                        _objpro.Nationality_id = (row["Nationality_id"].ToString());
                        _objpro.Nationality_Name = row["Nationality"].ToString();
                        _Nationality.Add(_objpro);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Country.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
        }
        public JsonResult SelectAcademicinformation()
        {
            StudentRepository objRep = new StudentRepository();
            DataSet ds = objRep.select_StudentAcademic_information(TempData.Peek("studentid").ToString());
            List<StudentAcademic_information> _list = new List<StudentAcademic_information>();
            List<StudentAcademic_information> _listJee = new List<StudentAcademic_information>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StudentAcademic_information objacademic = new StudentAcademic_information();
                        objacademic.studentid = row["studentid"].ToString();
                        objacademic.Education_Qualification_Name = row["Education_Qualification_Name"].ToString();
                        objacademic.Degree_name = row["Degree_name"].ToString();
                        objacademic.board_uni_name = row["board_uni_name"].ToString();
                        objacademic.NameofCourse = row["NameofCourse"].ToString();
                        objacademic.Academicinformationid = row["Academicinformationid"].ToString();
                        objacademic.passing_year = row["passing_year"].ToString();
                        objacademic.Marks_obtains = row["Marks_obtains"].ToString();
                        objacademic.min_marks = row["min_marks"].ToString();
                        objacademic.subject_studied = row["subject_studied"].ToString();
                        objacademic.country_id = row["country_id"].ToString();
                        objacademic.country_name = row["country_name"].ToString();
                        objacademic.address = row["address"].ToString();
                        objacademic.GradeConversionDocument = row["GradeConversionDocument"].ToString();
                        objacademic.TotalMarksinPercentage = row["TotalMarksinPercentage"].ToString();
                        _list.Add(objacademic);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        StudentAcademic_information objacademicjeee = new StudentAcademic_information();
                        objacademicjeee.jeeadvance = row["jeeadvance"].ToString();
                        objacademicjeee.jeeadvancescore = row["jeeadvancescore"].ToString();
                        objacademicjeee.jeemain = row["jeemain"].ToString();
                        objacademicjeee.jeemainscore = row["jeemainscore"].ToString();
                        objacademicjeee.ielts = row["ielts"].ToString();
                        objacademicjeee.ieltsscore = row["ieltsscore"].ToString();
                        objacademicjeee.GMAT = row["GMAT"].ToString();
                        objacademicjeee.GMATscore = row["GMATscore"].ToString();
                        objacademicjeee.TOFEL = row["TOFEL"].ToString();
                        objacademicjeee.TOFELscore = row["TOFELscore"].ToString();
                        objacademicjeee.SAT = row["SAT"].ToString();
                        objacademicjeee.SATscore = row["SATscore"].ToString();
                        objacademicjeee.experience = row["experience"].ToString();
                        objacademicjeee.experiencescore = row["experiencescore"].ToString();
                        _listJee.Add(objacademicjeee);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListJee = _listJee
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}