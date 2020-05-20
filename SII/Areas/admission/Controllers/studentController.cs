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
    [SessionExpireAttribute]
    [NoDirectAccessLearner]
    public class studentController : Controller
    {
        // GET: admission/student
        public ActionResult Index()
        {
            selectDropdown();
            TempData["ActiveMainTab"] = "student";
            return View();
        }

        public ActionResult _Basicinformation()
        {
            selectDropdown();
            return PartialView();
        }
        #region Basic  information
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

        public JsonResult SaveStudentBasic(Student_Register _obj)
        {
            StudentRepository objRepository = new StudentRepository();
            DataSet _ds = objRepository.UpdateStudentRegistration(_obj);
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

        public JsonResult SelectStudentBasic()
        {
            Student_Register _obj = new Student_Register();
            StudentRepository objRep = new StudentRepository();
            _obj.studentid = Session["studentid"].ToString();
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
                        objadd.City = row["City"].ToString();
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

        public ActionResult _Academicinformation()
        {
            selectDropdown();
            return PartialView();
        }
        #region Academic information
        public JsonResult SaveAcademicinformation(StudentAcademic_information _obj)
        {
            _obj.studentid = Session["studentid"].ToString();
            _obj.Created_By = Session["studentid"].ToString();
            _obj.Created_Ip = Session["localIP"].ToString();
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
            //StudentAcademic_information _obj = new StudentAcademic_information();
            StudentRepository objRep = new StudentRepository();
            //_obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.select_StudentAcademic_information(Session["studentid"].ToString());
            List<StudentAcademic_information> _list = new List<StudentAcademic_information>();
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
                        objacademic.passing_year = row["passing_year"].ToString();
                        objacademic.Marks_obtains = row["Marks_obtains"].ToString();
                        objacademic.min_marks = row["min_marks"].ToString();
                        objacademic.subject_studied = row["subject_studied"].ToString();
                        objacademic.country_id = row["country_id"].ToString();
                        objacademic.address = row["address"].ToString();
                        _list.Add(objacademic);
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
        #endregion

        public ActionResult _BackgroundInformation()
        {
            selectDropdown();
            return PartialView();
        }
        #region Student Backgraound

        public JsonResult SaveStudentBackgraound(Student_Register _obj)
        {
            _obj.studentid = Session["studentid"].ToString();
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
            _obj.studentid = Session["studentid"].ToString();
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

        public ActionResult _Documentinformation()
        {
            ViewBag.Filesize = System.Configuration.ConfigurationManager.AppSettings["FileSizeinMB"];
            return PartialView();
        }
        #region  document infomation
        public JsonResult Savestudentdocument(student_document _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            _obj.created_by = Session["studentid"].ToString();
            _obj.studentid = Session["studentid"].ToString();
            // _obj.CREATED_IP = Session["localIP"].ToString();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + Session["studentid"].ToString();
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
                    fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + Session["studentid"].ToString()), filename);
                    file.SaveAs(fname);
                    _obj.document_path = "/Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + filename;
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
            DataSet ds = objRepository.select_studentdocument(Session["studentid"].ToString());
            List<student_document> _list = new List<student_document>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        student_document objdoc = new student_document();
                        objdoc.document_name = row["document_name"].ToString();
                        objdoc.document_path = row["document_path"].ToString();
                        objdoc.studentid = row["studentid"].ToString();
                        _list.Add(objdoc);
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
                    filename = Session["studentid"].ToString() + "_Photo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
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
            _obj.studentid = Session["studentid"].ToString();
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
        #endregion

        public ActionResult _Declaration()
        {
            return PartialView();
        }
    }
}