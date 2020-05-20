using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.Data;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class StudentBackgroundInformationController : Controller
    {
        // GET: admission/StudentBackgroundInformation
        public ActionResult Index()
        {
            if (Session["submitChoiceFill"] != null)
            {
                if (Session["submitChoiceFill"].ToString().ToLower() == "true")
                {
                    return Redirect("~/admission/Dashboard/ViewDetails?d=BackgroundInformation");
                }
            }
            selectDropdown();
            return View();
        }

        #region Student Backgraound Information
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
                        objBasic.PassportFileReferenceNumber = row["PassportFileReferenceNumber"].ToString();
                        objBasic.HaveCitizenshipNumber = row["HaveCitizenshipNumber"].ToString();
                        objBasic.CitizenshipNumber = row["CitizenshipNumber"].ToString();
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
    }
}