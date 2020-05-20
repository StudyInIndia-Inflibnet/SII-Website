using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Areas.Admin.Controllers
{

    [SessionExpireAdmin]
    public class RegistrationController : Controller
    {
        // GET: Admin/Registration
        public ActionResult Index()
        {
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
                        _objcountry.country_code = row["country_code"].ToString() + " (" + row["Country_Name"].ToString() + ")";
                        _Country.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
        }

        public JsonResult RegistationUser(Student_Register _obj, bool CaptchaValid = true)
        {
            bool flagCaptcha = false;
            bool flagValidID = true;
            try
            {
                //if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                if (CaptchaValid)
                {
                    flagCaptcha = true;
                    StudentRepository _objRepository = new StudentRepository();
                    string localIP = "?";
                    localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    _obj.Created_Ip = localIP;
                    string password = Membership.GeneratePassword(8, 1);
                    _obj.Random = password;
                    _obj.bulk_reg = "true";
                    DataSet ds = _objRepository.InsertStudentRegistration(_obj);
                    SendEmail _objseedemail = new SendEmail();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Exist"].ToString() == "0")
                        {
                            flagValidID = true;
                            if (_obj.Email.ToString() != "")
                            {
                                string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
                                string Subject = "Student Login";
                                StringBuilder MailBody = new StringBuilder();
                                MailBody.Append("<br/>Dear " + _obj.FirstName + " " + _obj.LastName + ",<br/>");
                                MailBody.Append("<br/>Thank you for registering at Study in India.");
                                MailBody.Append("<br/>To activate your account <b><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login'>Click Here</a> </b>");
                                MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["UserName"].ToString() + "(You can also use your email id for logging in)");
                                MailBody.Append("<br/>Password: " + password.ToString());
                                //MailBody.Append("<br/>Please note: This is an auto generated email.<br/>");
                                MailBody.Append("<br/><br/><br/>Regards,<br/>");
                                MailBody.Append("Study in India Team<br/>");
                                string bcc = "";
                                string cc = "";
                                _objseedemail.SendEmailInBackgroundThread(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                            }
                        }
                        else
                        {
                            flagValidID = false;
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new
            {
                flagCaptcha = flagCaptcha,
                flagValidID = flagValidID
            },
                JsonRequestBehavior.AllowGet
            );
        }
#pragma warning disable SCS0029 // Potential XSS vulnerability
        public string FullyQualifiedApplicationPath(HttpRequestBase httpRequestBase)
#pragma warning restore SCS0029 // Potential XSS vulnerability
        {
            string appPath = string.Empty;

            if (httpRequestBase != null)
            {
                //Formatting the fully qualified website url/name
                appPath = string.Format("{0}://{1}{2}{3}",
                            httpRequestBase.Url.Scheme,
                            httpRequestBase.Url.Host,
                            httpRequestBase.Url.Port == 80 ? string.Empty : ":" + httpRequestBase.Url.Port,
                            httpRequestBase.ApplicationPath);
            }

            if (!appPath.EndsWith("/"))
            {
                appPath += "/";
            }

            return appPath;
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
    }
}