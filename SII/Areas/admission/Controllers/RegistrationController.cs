using SII.Filters;
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

namespace SII.Areas.admission.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: admission/Registration
        //   [RecaptchaFilter]
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
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
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
        [HttpPost]
        [RecaptchaFilter]
        public JsonResult RegistationUser(Student_Register _obj, bool CaptchaValid)
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
                    // _obj.CREATE_BY = Session["FA_USER_ID"].ToString();
                    string localIP = "?";
                    localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    _obj.Created_Ip = localIP;
                    string password = Membership.GeneratePassword(8, 1);
                    _obj.Random = password;
                    Random rn = new Random();
                    int month = rn.Next(1, 6);
                    StringBuilder hashPassword = new StringBuilder();
                    string new_password = _obj.ActualPassword;
                    switch (month)
                    {
                        case 1:
                            hashPassword.Append(Helper.ComputeHash(new_password, "MD5", null));
                            break;

                        case 2:
                            hashPassword.Append(Helper.ComputeHash(new_password, "SHA1", null));
                            break;

                        case 3:
                            hashPassword.Append(Helper.ComputeHash(new_password, "SHA256", null));
                            break;

                        case 4:
                            hashPassword.Append(Helper.ComputeHash(new_password, "SHA384", null));
                            break;

                        case 5:
                            hashPassword.Append(Helper.ComputeHash(new_password, "SHA512", null));
                            break;
                    }
                    _obj.ActualPassword = hashPassword.ToString();
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
                                MailBody.Append("<br/>Dear Student, " + _obj.FirstName + " " + _obj.LastName + ",<br/>");
                                MailBody.Append("<br/>Thank you for registering at Study in India.");
                                MailBody.Append("<br/>To activate your account <b><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login?eid=" + Encrypt_Decrypt.EncryptData(_obj.Email,"") + "'>click on the following link </a> </b>");
                              //  MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["UserName"].ToString() + "(You can also use your email id for logging in)");
                             //   MailBody.Append("<br/>Password: " + password.ToString());
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
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                flagCaptcha = flagCaptcha,
                flagValidID = flagValidID
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public string FullyQualifiedApplicationPath(HttpRequestBase httpRequestBase)
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

    }
}