using Newtonsoft.Json;
using SII.Filters;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Areas.admission.Controllers
{
    public class RegistrationsController : Controller
    {
        // GET: admission/Registrations
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
            List<Country> _CountryCode = new List<Country>();
            List<Date> _Date = new List<Date>();
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
                        _CountryCode.Add(_objcountry);
                    }
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        if (row["Country_id"].ToString() != "252")
                        {
                            Country _objcountry = new Country();
                            _objcountry.Country_id = (row["Country_id"].ToString());
                            _objcountry.Country_Name = row["Country_Name"].ToString();
                            _objcountry.country_code = row["country_code"].ToString();
                            _Country.Add(_objcountry);
                        }
                    }
                }
                if (ds.Tables[7].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[7].Rows)
                    {
                        Date _objdate = new Date();
                        _objdate.Year = row["Year"].ToString();
                        _Date.Add(_objdate);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
            ViewBag.CountryCode = _CountryCode;
            ViewBag.Year = _Date;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[RecaptchaFilter], bool CaptchaValid
        public JsonResult RegistationUser(Student_Register _obj)
        {
            bool flagCaptcha = false;
            bool flagValidID = true;
            bool flagDOB = true;
            string[] DMonths = null;
            mWebhook _response = null;
            if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
            //  if (CaptchaValid)
            {
                flagCaptcha = true;
                DMonths = new[] { "04", "06", "09", "11" };
                if (_obj.Month == "02")
                {
                    if (Convert.ToInt32(_obj.Year) % 4 == 0)
                    {
                        if (Convert.ToInt32(_obj.Date) > 29)
                        {
                            flagDOB = false;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(_obj.Date) > 28)
                        {
                            flagDOB = false;
                        }
                    }
                }
                else if (DMonths.Contains(_obj.Month))
                {
                    if (Convert.ToInt32(_obj.Date) > 30)
                    {
                        flagDOB = false;
                    }
                }
                if (flagDOB)
                {
                    _obj.DateOfBirth = _obj.Date + "-" + _obj.Month + "-" + _obj.Year;
                    StudentRepository _objRepository = new StudentRepository();
                    // _obj.CREATE_BY = Session["FA_USER_ID"].ToString();
                    string localIP = "?";
                    localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    _obj.Created_Ip = localIP;
                    string password = Membership.GeneratePassword(8, 1);
                    _obj.Random = password;
                    Random rn = new Random();
#pragma warning disable SCS0005 // Weak random generator
                    int month = rn.Next(1, 6);
#pragma warning restore SCS0005 // Weak random generator
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
                    _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    DataSet ds = _objRepository.InsertStudentRegistration(_obj);
                    SendEmail _objseedemail = new SendEmail();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _obj.studentid = ds.Tables[0].Rows[0]["UserName"].ToString();
                        if (ds.Tables[0].Rows[0]["Exist"].ToString() == "0")
                        {
                            flagValidID = true;
                            string strform = "";
                            if (_obj.Email.ToString() != "")
                            {
                                #region Mail Sending Code
                                #region Code to send mails simultaneously in a loop (By Amit: 14-06-2019 11:45 AM)
                                //if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
                                //{
                                //    System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
                                //}
                                //else
                                //{

                                //}
                                //int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"]);
                                //if (UserCountForMail < 4)
                                //{
                                //    UserCountForMail++;
                                //}
                                //else
                                //{
                                //    UserCountForMail = 1;
                                //}

                                //System.Web.HttpContext.Current.Application["UserCountForMail"] = UserCountForMail;
                                //if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
                                //{
                                //    System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
                                //}

                                //if (UserCountForMail == 1)
                                //{
                                //    strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                                //}
                                //else if (UserCountForMail == 2)
                                //{
                                //    strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername2"];
                                //}
                                //else if (UserCountForMail == 3)
                                //{
                                //    strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername3"];
                                //}
                                //else if (UserCountForMail == 4)
                                //{
                                //    strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername4"];
                                //}

                                #endregion

                                string ActivationLink = FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login?eid=" + Encrypt_Decrypt.EncryptData(_obj.Email, "");

                                //string Subject = "Student Login";
                                //StringBuilder MailBody = new StringBuilder();
                                //MailBody.Append("<br/>Dear " + _obj.FirstName + " " + _obj.LastName + ",<br/>");
                                //MailBody.Append("<br/>Greetings from 'Study In India' Team!");
                                //MailBody.Append("<br/>Thank you for registering at 'Study In India' Portal. Your application will be considered for the Academic Year of 2020-21.");
                                //MailBody.Append("<br/>To activate your account <b><a target='_blank' href='" + ActivationLink + "'>click here </a> </b>");
                                ////  MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["UserName"].ToString() + "(You can also use your email id for logging in)");
                                ////   MailBody.Append("<br/>Password: " + password.ToString());
                                ////MailBody.Append("<br/>Please note: This is an auto generated email.<br/>");
                                //MailBody.Append("<br/><br/><br/>Regards,<br/>");
                                //MailBody.Append("'Study In India' Team<br/>");
                                //MailBody.Append("<br/><strong>NOTE:</strong> This is an auto generated mail. Please do not respond to this mail.<br/>");
                                //string bcc = "";
                                //string cc = "";
                                //_objseedemail.SendEmailInBackgroundThread(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                                string MailMessage = "";
                                string MailSent = "1";
                                try
                                {
                                    //_objseedemail.SendEmailForRegistration(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                                    MailMessage = "Mail Sent";
                                    MailSent = "1";
                                }
                                catch (Exception ex)
                                {
                                    MailMessage = ex.Message.ToString();
                                }
                                #endregion

                                #region Call PivotRoots Code
                                int gotoIndex = 0;
                            goback: { }
                                string strUrl = "https://pivotroots.com/clients/studyinindia/webhooks/user_events";
                                WebRequest request = HttpWebRequest.Create(strUrl);
                                request.Headers.Add("Request-Id", DateTime.Now.ToString("yyyyMMddhhmmss"));
                                request.Method = "POST";
                                request.ContentType = "application/json";
                                request.Headers.Add("Client-Id", "b7a51eff57749dc0e733b74342c8b512");
                                request.Headers.Add("Client-Access-Token", "dfdd5aa8ea4a1e2fb5999dc213476c2a9b68efa7");
                                mWebhookRequestRegistration _objJsonRequest = new mWebhookRequestRegistration()
                                {
                                    timestamp = DateTime.Now.ToString("yyyyMMddhhmmss"),
                                    user_id = _obj.studentid,
                                    @event = "new_registration",
                                    userName = _obj.FirstName + " " + _obj.LastName,
                                    emailID = _obj.Email,
                                    activationLink = ActivationLink,
                                    Country = ds.Tables[0].Rows[0]["CountryName"].ToString(),
                                    country_code = ds.Tables[0].Rows[0]["country_code"].ToString(),
                                    mobile = _obj.Mobile,
                                    whatsapp_consent = _obj.whatsapp_consent
                                };
                                string data = JsonConvert.SerializeObject(_objJsonRequest);
                                byte[] dataStream = Encoding.UTF8.GetBytes(data);
                                request.ContentLength = dataStream.Length;
                                Stream r = request.GetRequestStream();
                                r.Write(dataStream, 0, dataStream.Length);
                                r.Close();
                                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                Stream s = (Stream)response.GetResponseStream();
                                StreamReader readStream = new StreamReader(s);
                                string dataString = readStream.ReadToEnd();
                                _response = JsonConvert.DeserializeObject<mWebhook>(dataString);
                                if (_response.reason == "SUCCESS")
                                {
                                    DataSet dsMailSend = _objRepository.Opr_GenerateStudentDtl("ActivationLinkSent", _obj.studentid, ActivationLink, MailSent, MailMessage, strform);
                                    response.Close();
                                    s.Close();
                                    readStream.Close();
                                }
                                else
                                {
                                    response.Close();
                                    s.Close();
                                    readStream.Close();
                                    if ((gotoIndex++) < 3)
                                        goto goback;
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            flagValidID = false;
                        }
                    }
                }
            }
            return Json(new
            {
                flagCaptcha = flagCaptcha,
                flagValidID = flagValidID,
                flagDOB = flagDOB
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

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}