using SIIModel.Master;
using SIIRepository.StudentRegService;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using SIIModel.StudentRegister;
using SIIRepository.Institute;

namespace SII.Areas.Institute.Controllers
{
    public class ViewStudentDataSecondController : Controller
    {
        // GET: Institute/ViewStudentDataSecond
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(string studentid = "", string Name = "", string Choice_ID = "0")
        {
            if (studentid == "")
            {
                ViewBag.studentid = "0";
            }
            else
            {
                ViewBag.studentid = studentid;
            }
            if (Name == "")
            {
                ViewBag.studentname = "0";
            }
            else
            {
                ViewBag.studentname = Name;
            }
            if (Choice_ID == "0")
            {
                ViewBag.Choice_ID = "0";
            }
            else
            {
                ViewBag.Choice_ID = Choice_ID;
            }
            selectDropdown();


            return View();
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
        public JsonResult SelectCountry()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Country> _Country = new List<Country>();
            if (ds != null)
            {
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
            return Json(new
            {
                List = _Country
            },
               JsonRequestBehavior.AllowGet
           );
        }
        public JsonResult SelectAcademicinformation(string studentid = "", int id = 0)
        {
            //StudentAcademic_information _obj = new StudentAcademic_information();
            StudentRepository objRep = new StudentRepository();
            //_obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.select_StudentAcademic_information(studentid, id);
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
                        objacademic.ProgramLevel = row["ProgramLevel_Id"].ToString();
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
        public JsonResult Select_studentdocument(string studentid = "")
        {
            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.select_studentdocument(studentid);
            List<student_document> _list = new List<student_document>();
            string student_path = "";
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        student_document objdoc = new student_document();

                        objdoc.document_id = row["document_id"].ToString();
                        objdoc.document_name = row["document_name"].ToString();
                        objdoc.document_path = row["document_path"].ToString();
                        objdoc.studentid = row["studentid"].ToString();
                        _list.Add(objdoc);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        //student_document objdoc = new student_document();
                        student_path = row["student_path"].ToString();
                        Session["StudentProfilePic"] = row["student_path"].ToString();
                        //_list.Add(objdoc);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                student_path = student_path
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult UpdateApproveReject(string studentid = "", string choiceid = "", string SeatApprove = "", string SeatApproveReason = "", string IsRequireSkypeInterview = "", string SkypeInterviewRemarks = "", string IsSkypeInterviewComplete = "", string IsStudentAcceptSeat = "")
        {
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _ds = _objRepository.Addmiited_Student_List_Second_Round("", "ApproveSeat", "", "", studentid, "", Session["InstituteID"].ToString(), choiceid, SeatApprove, SeatApproveReason, IsRequireSkypeInterview, SkypeInterviewRemarks, IsSkypeInterviewComplete, IsStudentAcceptSeat);
            bool flag = false;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            return Json(new
            {
                Flag = flag
            },
               JsonRequestBehavior.AllowGet
           );
        }
        public JsonResult SelectApproveReject(string studentid = "", string choiceid = "")
        {

            InstituteRepository _objRepository = new InstituteRepository();

            DataSet _ds = _objRepository.Addmiited_Student_List_Second_Round("", "SelectApproveSeat", "", "", studentid, "", Session["InstituteID"].ToString(), "", "", "", "", "");

            string SeatApprove = "", SeatApproveReason = "", IsRequireSkypeInterview = "", IsSkypeInterviewComplete = "", IsStudentAcceptSeat = ""; /*SkypeInterviewRemarks = "",*/

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        SeatApprove = _dr["SeatApprove"].ToString();
                        SeatApproveReason = _dr["SeatApproveReason"].ToString();
                        IsRequireSkypeInterview = _dr["IsRequireSkypeInterview"].ToString();
                        IsSkypeInterviewComplete = _dr["IsSkypeInterviewComplete"].ToString();
                        IsStudentAcceptSeat = _dr["IsStudentAcceptSeat"].ToString();
                        //SkypeInterviewRemarks = _dr["SkypeInterviewRemarks"].ToString();
                    }
                }
            }
            return Json(new
            {
                SeatApprove = SeatApprove,
                SeatApproveReason = SeatApproveReason,
                IsRequireSkypeInterview = IsRequireSkypeInterview,
                IsSkypeInterviewComplete = IsSkypeInterviewComplete,
                IsStudentAcceptSeat = IsStudentAcceptSeat
                // SkypeInterviewRemarks = SkypeInterviewRemarks
            },
             JsonRequestBehavior.AllowGet
         );
        }
    }
}