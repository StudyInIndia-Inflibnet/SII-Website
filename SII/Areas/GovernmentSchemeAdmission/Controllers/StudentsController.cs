using SIIModel.Admin;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.Adminservice;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class StudentsController : Controller
    {
        // GET: GovernmentSchemeAdmission/Students
        public ActionResult Index(string Id = "")
        {
            if (Id == "")
            {
                TempData["Studentid"] = 0;
                //TempData.Keep("Studentid");
            }
            else
            {
                TempData["Studentid"] = Id;
            }
            TempData.Keep("Studentid");
            selectDropdown();
            return View();
        }
        public ActionResult _Basicinformationgov()
        {
            selectDropdown();
            TempData.Keep("Studentid");
            return PartialView();
        }
        public ActionResult _Academicinformationgov()
        {
            selectDropdown();
            TempData.Keep("Studentid");
            return PartialView();
        }
        public ActionResult _BackgroundInformationgov()
        {
            selectDropdown_back();
            TempData.Keep("Studentid");
            return PartialView();
        }
        public ActionResult _Documentinformationgov()
        {
            TempData.Keep("Studentid");
         //   selectDropdown();
            ViewBag.Filesize = System.Configuration.ConfigurationManager.AppSettings["FileSizeinMB"];
            return PartialView();
        }
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Nationality> _Nationality = new List<Nationality>();
            List<Country> _Country = new List<Country>();
            List<Country> _Countrywithoutindia = new List<Country>();
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
                        _objcountry.country_code = row["country_code"].ToString() + " (" + row["Country_Name"].ToString() + ")";
                        _Country.Add(_objcountry);
                    }
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Countrywithoutindia.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
            ViewBag.Countrywithoutindia = _Countrywithoutindia;
        }
        public void selectDropdown_back()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Nationality> _Nationality = new List<Nationality>();
            List<Country> _Country = new List<Country>();
            List<Country> _Countrywithoutindia = new List<Country>();
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
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Countrywithoutindia.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
            ViewBag.Countrywithoutindia = _Countrywithoutindia;
        }

        #region  Basic infomation

        public JsonResult SaveStudent_Basic(Student_Register _obj)
        {
            StudentRepository objRepository = new StudentRepository();
            _obj.gov_scheme_id = Session["Gov_User_id"].ToString();
            _obj.Created_By = Session["Gov_User_id"].ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString(); 
            DataSet _ds = objRepository.InsertUpdateStudentRegistration_gov(_obj);
            bool flag = false;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Exist"].ToString() == "0")
                    {
                        flag = true;
                        TempData["Studentid"] = _ds.Tables[0].Rows[0]["UserName"].ToString();
                        TempData.Keep("Studentid");
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

        public JsonResult SelectStudent_Basic()
        {
            Student_Register _obj = new Student_Register();
            StudentRepository objRep = new StudentRepository();
            _obj.studentid = TempData.Peek("Studentid").ToString();
            TempData.Keep("Studentid");
            DataSet ds = objRep.Select_Student_Information(_obj);
            List<Student_Register> _list = new List<Student_Register>();
            List<Student_AddressDetails> _listAddress = new List<Student_AddressDetails>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Student_Register objBasic = new Student_Register();
                        objBasic.studentid = row["studentid"].ToString();
                        objBasic.FirstName = row["FirstName"].ToString();
                        objBasic.LastName = row["LastName"].ToString();
                        objBasic.MiddleName = row["MiddleName"].ToString();
                        objBasic.DateOfBirth = row["DateOfBirth"].ToString();
                        objBasic.Gender = row["Gender"].ToString();
                        objBasic.Email = row["Email"].ToString();
                        objBasic.Mobile = row["Mobile"].ToString();
                        objBasic.CountryCode = row["CountryCode"].ToString();
                        objBasic.Nationality = row["Nationality"].ToString();
                        objBasic.CountryToStay = row["CountryToStay"].ToString();
                        objBasic.student_path = row["student_path"].ToString();
                        objBasic.agency_det_id = row["agency_det_id"].ToString();
                        Session["studentname"] = row["FirstName"].ToString() + ' ' + row["MiddleName"].ToString() + ' ' + row["LastName"].ToString();
                        _list.Add(objBasic);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Student_AddressDetails objadd = new Student_AddressDetails();
                        objadd.studentid = row["studentid"].ToString();
                        objadd.AddressType = row["AddressType"].ToString();
                        objadd.Addressline1 = row["Addressline1"].ToString();
                        objadd.Country = row["Country"].ToString();
                        objadd.State = row["State"].ToString();
                        objadd.State_name = row["State_name"].ToString();
                        objadd.City = row["City"].ToString();
                        objadd.City_name = row["City_name"].ToString();
                        objadd.Area = row["Area"].ToString();
                        _listAddress.Add(objadd);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListAdd = _listAddress
            },
                JsonRequestBehavior.AllowGet
            );

        }
        #endregion

        #region  Academic Information
        public JsonResult SaveAcademicinformation(StudentAcademic_information _obj)
        {
            _obj.studentid = TempData.Peek("Studentid").ToString(); 
            _obj.Created_By = Session["Gov_User_id"].ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.gov_scheme_id = Session["Gov_User_id"].ToString();
            TempData.Keep("Studentid");
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
        public JsonResult SelectAcademicinformation()
        {
            StudentRepository objRep = new StudentRepository();
            DataSet ds = objRep.select_StudentAcademic_information(TempData.Peek("Studentid").ToString());
            TempData.Keep("Studentid");
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
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/";
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
                    filename = TempData.Peek("Studentid").ToString() + "_GradeConversionDocument_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/"), filename);
                    file.SaveAs(fname);
                    GradeConversionDocument = "/Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/" + filename;
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
            _obj.studentid = TempData.Peek("Studentid").ToString();
            _obj.Created_By = TempData.Peek("Studentid").ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            TempData.Keep("Studentid");
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
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/";
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
                    filename = TempData.Peek("Studentid").ToString() + "_GradeConversionDocument_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/"), filename);
                    file.SaveAs(fname);
                    GradeConversionDocument = "/Uploads/GradeConversionDocument/" + TempData.Peek("Studentid").ToString() + "/" + filename;
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
            _obj.studentid = TempData.Peek("Studentid").ToString();
            _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            TempData.Keep("Studentid");
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

        #region Student Backgraound Information
        public JsonResult SaveStudentBackgraound(Student_Register _obj)
        {
            _obj.studentid = TempData.Peek("Studentid").ToString();
            TempData.Keep("Studentid");
            StudentRepository objRepository = new StudentRepository();
            DataSet _ds = objRepository.UpdateStudentBackground(_obj);
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

        public JsonResult SelectStudentBackgraound()
        {
            Student_Register _obj = new Student_Register();
            StudentRepository objRep = new StudentRepository();
            _obj.studentid = TempData.Peek("Studentid").ToString();
            TempData.Keep("Studentid");
            DataSet ds = objRep.Select_Student_Information(_obj);
            List<Student_Register> _list = new List<Student_Register>();
            List<Student_Register> _list1 = new List<Student_Register>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Student_Register objBasic = new Student_Register();
                        objBasic.studentid = row["studentid"].ToString();
                        objBasic.IsvalidPassport = row["IsvalidPassport"].ToString();
                        objBasic.NameasperPassport = row["NameasperPassport"].ToString();
                        objBasic.PassportNo = row["PassportNo"].ToString();
                        objBasic.IssuingAuthority = row["IssuingAuthority"].ToString();
                        objBasic.PassportExpDate = row["PassportExpDate"].ToString();
                        objBasic.PassportIssueCountry = row["PassportIssueCountry"].ToString();
                        objBasic.ApplyForPassport = row["ApplyForPassport"].ToString();
                        objBasic.AgreeTermsConditions = row["AgreeTermsConditions"].ToString();
                        objBasic.PassportFileReferenceNumber = row["PassportFileReferenceNumber"].ToString();
                        _list.Add(objBasic);
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        Student_Register objBasic = new Student_Register();
                        objBasic.Name = row["Name"].ToString();
                        objBasic.Designation = row["Designation"].ToString();
                        objBasic.Institute_employer_name = row["Institute_employer_name"].ToString();
                        objBasic.Email = row["Email"].ToString();
                        objBasic.ContactNo = row["ContactNo"].ToString();
                        objBasic.RefAddress = row["RefAddress"].ToString();
                        objBasic.RefCountry = row["RefCountry"].ToString();
                        objBasic.RefState = row["RefState"].ToString();
                        objBasic.RefCity = row["RefCity"].ToString();
                        objBasic.RefArea = row["RefArea"].ToString();
                        _list1.Add(objBasic);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                List1 = _list1

            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region  document infomation
        public JsonResult Savestudentdocument(student_document _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            _obj.created_by = TempData.Peek("Studentid").ToString();
            _obj.studentid = TempData.Peek("Studentid").ToString();
            TempData.Keep("Studentid");
            // _obj.CREATED_IP = Session["localIP"].ToString();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + TempData.Peek("Studentid").ToString();
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
                    filename = _obj.document_name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + TempData.Peek("Studentid").ToString()), filename);
                    file.SaveAs(fname);
                    _obj.document_path = "/Uploads/studentDocument/" + TempData.Peek("Studentid").ToString() + "/" + filename;
                }
                else
                {
                    _obj.document_path = "";
                }
            }
            else
            {
                _obj.document_path = "";
            }
            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.insert_studentdocument(_obj);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Select_studentdocument()
        {

            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.select_studentdocument(TempData.Peek("Studentid").ToString());
            TempData.Keep("Studentid");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult uploadstudentimage()
        {
            string path = "";
            string filename = "";
            string fname = "";
            Student_Register _obj = new Student_Register();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    //Upload the file... 
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentPhoto/";
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
                    filename = TempData.Peek("Studentid").ToString() + "_Photo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/studentPhoto/"), filename);
                    file.SaveAs(fname);
                    _obj.student_path = "/Uploads/studentPhoto/" + filename;
                }
                else
                {
                    _obj.student_path = _obj.student_path;
                }
            }
            else
            {
                _obj.student_path = _obj.student_path;
            }
            _obj.studentid = TempData.Peek("Studentid").ToString();
            TempData.Keep("Studentid");
            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.update_image_path(_obj);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["COUNTS"].ToString() != "0")
                    {
                        flag = true;
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

        public JsonResult Delete_studentdocument(string document_id = "0")
        {

            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.delete_studentdocument(document_id);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
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

        public JsonResult update_student_data_gov(string ID = "")
        {
            bool flag = false;
            StudentRepository objRep = new StudentRepository();
            DataSet _ds = objRep.update_student_data_gov(ID);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                    {
                        flag = true;
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

        public JsonResult SelectAgencyDetail()
        {
            AgencyRepository objRep = new AgencyRepository();
            DataSet ds = objRep.select_tbl_Agency_detail(Session["Gov_User_id"].ToString());
            List<AgencyDetail> _list = new List<AgencyDetail>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AgencyDetail objBasic = new AgencyDetail();
                        objBasic.id = row["id"].ToString();
                        objBasic.agencyid = row["agencyid"].ToString();
                        objBasic.nameofentitlename = row["nameofentitlename"].ToString();
                        _list.Add(objBasic);
                    }
                }
            }
            return Json(new
            {
                List = _list
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}