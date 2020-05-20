using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class IndSATSelectionController : Controller
    {
        // GET: admission/IndSATSelection
        public ActionResult Index()
        {
            if (Convert.ToDateTime(Session["submitchoiceDate"].ToString()) > Convert.ToDateTime("2020-04-30 23:59:59"))
            {
                return Redirect("~/admission/Dashboard/");
            }
            if (DateTime.Now > Convert.ToDateTime("2020-05-15 23:59:59"))
            {
                return Redirect("~/admission/Dashboard/");
            }
            if (Session["IsTestCentreCountry"].ToString().ToLower() != "true")
            {
                Session["IndSAT_ERROR_FLAG"] = "false";
                return Redirect("~/admission/Dashboard");
            }
            ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
            DataSet _ds = _objRepository.Opr_TestCentreRegitration(new TestCentreRegitration
            {
                Type = "SELECT",
                studentid = Session["studentid"].ToString()
            });
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    return Redirect("~/admission/Dashboard/ViewDetails?d=IndSATSelection");
                }
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    if (_ds.Tables[1].Rows[0]["IsTestCentreCountry"].ToString().ToLower() == "false")
                    {
                        Session["IndSAT_ERROR_FLAG"] = "Ind-SAT Examination is only being conducated for the students who belong to the contries: <strong>Nepal, Ethiopia, Bangladesh, Bhutan, Uganda, Tanzania, Rwanda, Sri Lanka, Kenya, Zambia, Indonesia</strong> and <strong>Mauritius</strong>.";
                        return Redirect("~/admission/Dashboard");
                    }
                }
                if (_ds.Tables[2].Rows.Count > 0)
                {
                    if (_ds.Tables[2].Rows[0]["DontAllowIndSAT"].ToString().ToLower() != "0")
                    {
                        Session["IndSAT_ERROR_FLAG"] = "Ind-SAT Examination Centre Selection is not allowed for PhD or Integrated PhD students.";
                        return Redirect("~/admission/Dashboard");
                    }
                }
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
            List<Country> _TestCountry = new List<Country>();
            List<TestCity> _TestCity = new List<TestCity>();
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
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;

            ChoiceFillingRepository _objRepo = new ChoiceFillingRepository();
            TestCentreRegitration _obj = new TestCentreRegitration
            {
                Type = "SELECTDRP"
            };
            DataSet _ds2 = _objRepo.Opr_TestCentreRegitration(_obj);
            if (_ds2 != null)
            {
                if (_ds2.Tables[0].Rows.Count > 0)
                {
                    ViewBag.TestCountry = _ds2.Tables[0];
                }

                if (_ds2.Tables[1].Rows.Count > 0)
                {
                    ViewBag.TestCity = _ds2.Tables[1];
                }

            }
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
                        objBasic.Country = row["CountryID"].ToString();
                        objBasic.CountryToStay = row["CountryToStay"].ToString();
                        objBasic.student_path = row["student_path"].ToString();
                        objBasic.bCopyAddress = row["bCopyAddress"].ToString();
                        objBasic.ApplyingForCourse = row["ApplyingForCourse"].ToString();
                        Session["studentname"] = row["FirstName"].ToString() + ' ' + row["MiddleName"].ToString() + ' ' + row["LastName"].ToString();
                        _list.Add(objBasic);
                    }
                }
            }
            TestCentreRegitration _obj1 = new TestCentreRegitration
            {
                Type = "SELECT",
                studentid = Session["studentid"].ToString()
            };
            ChoiceFillingRepository objRep1 = new ChoiceFillingRepository();
            DataSet ds1 = objRep1.Opr_TestCentreRegitration(_obj1);
            List<TestCentreRegitration> _list1 = new List<TestCentreRegitration>();
            if (ds1 != null)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        _list1.Add(new TestCentreRegitration
                        {
                            FatherName = row["FatherName"].ToString(),
                            TestCountry = row["TestCountry"].ToString(),
                            TestCity = row["TestCity"].ToString()
                        });
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
        public JsonResult SaveStudentBasic(TestCentreRegitration _obj)
        {
            _obj.Type = "INSERT";
            _obj.studentid = Session["studentid"].ToString();
            _obj.CreatedIP = Session["localIP"].ToString();
            ChoiceFillingRepository objRepository = new ChoiceFillingRepository();
            DataSet _ds = objRepository.Opr_TestCentreRegitration(_obj);
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

        public JsonResult Select()
        {
            TestCentreRegitration _obj = new TestCentreRegitration
            {
                Type = "SELECT"
            };
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            _obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.Opr_TestCentreRegitration(_obj);
            List<TestCentreRegitration> _list = new List<TestCentreRegitration>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        _list.Add(new TestCentreRegitration
                        {
                            FatherName = row["FatherName"].ToString(),
                            TestCountry = row["TestCountry"].ToString(),
                            TestCity = row["TestCity"].ToString()
                        });
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