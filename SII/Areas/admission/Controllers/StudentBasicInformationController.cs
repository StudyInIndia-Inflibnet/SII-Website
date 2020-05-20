using System.Collections.Generic;
using System.Web.Mvc;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.Data;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class StudentBasicInformationController : Controller
    {
        // GET: admission/StudentBasicInformation
        public ActionResult Index()
        {
            if (Session["submitChoiceFill"] != null)
            {
                if (Session["submitChoiceFill"].ToString().ToLower() == "true")
                {
                    return Redirect("~/admission/Dashboard/ViewDetails?d=BasicInformation");
                }
            }
            selectDropdown();
            return View();
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
                        if (row["Country_id"].ToString() != "252")
                        {
                            Country _objcountry = new Country();
                            _objcountry.Country_id = (row["Country_id"].ToString());
                            _objcountry.Country_Name = row["Country_Name"].ToString();
                            _objcountry.country_code = row["country_code"].ToString() + " (" + row["Country_Name"].ToString() + ")";
                            _Country.Add(_objcountry);
                        }
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
                    else
                    {
                        Session["ApplyingForCourse"] = _obj.ApplyingForCourse;
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
                        objBasic.Country = row["CountryID"].ToString();
                        objBasic.CountryToStay = row["CountryToStay"].ToString();
                        objBasic.student_path = row["student_path"].ToString();
                        objBasic.bCopyAddress = row["bCopyAddress"].ToString();
                        objBasic.ApplyingForCourse = row["ApplyingForCourse"].ToString();
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
    }
}