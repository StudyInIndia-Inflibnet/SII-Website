using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    //[NoDirectAccessLearner]
    public class DashboardController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: admission/Dashboard
        #region Dashboard Views
        public ActionResult Index()
        {
            DashboardRepository _objRepository = new DashboardRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(Session["studentid"].ToString());
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
                        _Obj.Disciplinelist = _dr["Disciplinelist"].ToString();
                        _Obj.TotalChoicefill = _dr["TotalChoicefill"].ToString();
                        _Obj.Doc_required = _dr["Doc_required"].ToString();
                        _Obj.Uploded_doc = _dr["Uploded_doc"].ToString();
                        _Obj.finalSubmit = _dr["finalSubmit"].ToString();
                        _Obj.IndSATCenter = _dr["IndSATCenter"].ToString();
                        ViewBag.DocumentVerified = _dr["DocumentVerified"].ToString();
                        Session["IndSATCenter"] = _dr["IndSATCenter"].ToString();
                        _list.Add(_Obj);
                    }
                }
            }
            ViewBag.StudentdDashboard = _list;

            ChoiceFillingRepository _objRepo = new ChoiceFillingRepository();
            _ds = _objRepo.Opr_TestCentreRegitration(new TestCentreRegitration
            {
                Type = "SELECT",
                studentid = Session["studentid"].ToString()
            });
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.IndSATFilled = "True";
                }
            }

            return View();
        }
        public ActionResult ViewDetails(string d = "")
        {
            selectDropdown();
            ViewBag.DetailsFor = d;
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
        #endregion

        #region Partial View
        public ActionResult _BasicInformation()
        {
            return PartialView();
        }
        public ActionResult _AcademicInformation()
        {
            selectDropdown();
            return PartialView();
        }
        public JsonResult SelectAcademicinformation()
        {
            //StudentAcademic_information _obj = new StudentAcademic_information();
            StudentRepository objRep = new StudentRepository();
            //_obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.select_StudentAcademic_information(Session["studentid"].ToString());
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
        public ActionResult _BackgroundInformation()
        {
            return PartialView();
        }
        public ActionResult _DocumentInformation()
        {
            return PartialView();
        }
        public ActionResult _IndSATSelection()
        {
            return PartialView();
        }
        #endregion

        #region Edit My Application Button Click
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditMyApp()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                StudentRepository _objRepo = new StudentRepository();
                DataSet ds = _objRepo.EDIT_MY_APPLICATION(Session["studentid"].ToString(), Session["localIP"].ToString());
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["submitChoiceFill"] = "False";
                        Session["EditApplication"] = "True";
                        Message = "Application is now editable.";
                        Code = "success";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.!!";
                Code = "servererror";
                Error = ex.Message;
            }

            return Json(new
            {
                m = Message,
                c = Code,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Upload Documents
        public ActionResult UploadDocuments()
        {
            DataSet _ds = (new ChoiceFillingRepository()).SELECT_tbl_Student_Ch_Basic(Session["studentid"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        Session["ApplicationNo"] = _dr["ApplicationNo"].ToString();
                    }
                }
            }
            return View();
        }
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadDocs(StudentDocumentVerification _obj)
        {
            // mStudent_Ch_Doc_Upload _obj = new mStudent_Ch_Doc_Upload();
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                string path = "";
                string filename = "";
                string fname = "";
                if (_obj.For == "Upload")
                {
                    if (Request.Files.Count > 0)
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpFileCollectionBase files = Request.Files;
                            path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/";
                            filename = Path.GetFileName(Request.Files[0].FileName);
                            HttpPostedFileBase file = files[0];
                            _obj.name = _obj.name.Trim().Replace(" / ", "_");
                            _obj.name = _obj.name.Trim().Replace("/", "");
                            _obj.name = _obj.name.Trim().Replace(" ", "");
                            _obj.name = _obj.name.Trim().Replace("//", "_");
                            _obj.name = _obj.name.Trim().Replace("(", "_");
                            _obj.name = _obj.name.Trim().Replace(")", "_");
                            _obj.name = _obj.name.Trim().Replace(",", "");
                            filename = _obj.name + "_" + Session["ApplicationNo"].ToString() + Path.GetExtension(file.FileName);
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            else
                            {
                                string[] curentfiles = Directory.GetFiles(path);
                                foreach (string curentfile in curentfiles)
                                {
                                    if (curentfile.IndexOf(filename) >= 0)
                                        System.IO.File.Delete(curentfile);
                                }
                            }

                            fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/"), filename);
                            file.SaveAs(fname);
                            _obj.Path = "Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/" + filename;
                            
                        }
                        else
                        {
                            Message = "Error from server side. Kindly refresh the page and try again.";
                            Code = "servererror";
                            _obj.Path = "";
                        }
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                        _obj.Path = "";
                    }
                }
                else if (_obj.For == "EQ")
                {

                }
                else if (_obj.For == "AE")
                {

                }
                _obj.Type = "UPDATE";
                _obj.studentid = Session["studentid"].ToString();
                ChoiceFillingRepository _objRepo = new ChoiceFillingRepository();
                DataSet _ds = _objRepo.Opr_DocumentUpload(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Document uploaded successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }

            return Json(new
            {
                m = Message,
                c = Code,
                p = _obj.Path,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion
    }
}