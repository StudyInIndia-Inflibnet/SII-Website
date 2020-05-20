using System.Web.Mvc;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System;
using System.IO;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class StudentAcademicInformationController : Controller
    {
        // GET: admission/StudentAcademicInformation
        public ActionResult Index()
        {
            selectDropdown();
            //return View();
            return RedirectToAction("Index", "Dashboard", new { Area= "admission" });
        }

        #region Academic information
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
        public JsonResult SaveAcademicinformation(StudentAcademic_information _obj)
        {
            _obj.studentid = Session["studentid"].ToString();
            _obj.Created_By = Session["studentid"].ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString(); 
            StudentRepository objRepository = new StudentRepository();
            DataSet _ds = objRepository.insert_academic_information(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectAcademicinformation(int id=0)
        {
            //StudentAcademic_information _obj = new StudentAcademic_information();
            StudentRepository objRep = new StudentRepository();
            //_obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.select_StudentAcademic_information(Session["studentid"].ToString(), id);
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
                        objacademic.ProgramLevel=row["ProgramLevel_Id"].ToString();
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
        public JsonResult SelectQualification()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<ProgramLevels> _ProgramLevel = new List<ProgramLevels>();
            if (ds != null)
            {
                if (ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[3].Rows)
                    {
                        ProgramLevels _obj = new ProgramLevels();
                        _obj.ProgramLevel_Id = (row["ProgramLevel_Id"].ToString());
                        _obj.ProgramLevel = row["ProgramLevel"].ToString();
                        _ProgramLevel.Add(_obj);
                    }
                }
            }
            return Json(new
            {
                List = _ProgramLevel
            },
               JsonRequestBehavior.AllowGet
           );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Upload_GradeConversionDocument()
        {
            string path = "";
            string filename = "";
            string fname = "";
            string GradeConversionDocument = "";
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    //Upload the file... 
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/";
                    filename = Path.GetFileName(Request.Files[0].FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        string[] curentfiles = Directory.GetFiles(path);

                    }
                    HttpPostedFileBase file = files[0];
                    filename = Session["studentid"].ToString() + "_GradeConversionDocument_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/"), filename);
                    file.SaveAs(fname);
                    GradeConversionDocument = "/Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/" + filename;
                }
                else
                {
                    GradeConversionDocument = "";
                }
            }
            else
            {
                GradeConversionDocument = "";
            }
            return Json(new
            {
                GradeConversionDocument = GradeConversionDocument
            },
                JsonRequestBehavior.AllowGet
            );
        }

        public JsonResult SaveOtherAcademicinformation(StudentAcademic_information _obj)
        {
            _obj.studentid = Session["studentid"].ToString();
            _obj.Created_By = Session["studentid"].ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            string path = "";
            string filename = "";
            string fname = "";
            string GradeConversionDocument = "";
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    //Upload the file... 
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/";
                    filename = Path.GetFileName(Request.Files[0].FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        string[] curentfiles = Directory.GetFiles(path);

                    }
                    HttpPostedFileBase file = files[0];
                    filename = Session["studentid"].ToString() + "_GradeConversionDocument_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/"), filename);
                    file.SaveAs(fname);
                    GradeConversionDocument = "/Uploads/GradeConversionDocument/" + Session["studentid"].ToString() + "/" + filename;
                }
                else
                {
                    GradeConversionDocument = _obj.GradeConversionDocument;
                }
            }
            else
            {
                GradeConversionDocument = _obj.GradeConversionDocument;
            }
            _obj.GradeConversionDocument = GradeConversionDocument;
            StudentRepository objRepository = new StudentRepository();
            DataSet _ds = objRepository.insert_other_academicinformation(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult delete_other_academicinformation(StudentAcademic_information _obj)
        {
            _obj.studentid = Session["studentid"].ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            StudentRepository objRepository = new StudentRepository();
            DataSet _ds = objRepository.delete_other_academicinformation(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion
    }
}