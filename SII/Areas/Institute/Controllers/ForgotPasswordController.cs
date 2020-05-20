using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Areas.Institute.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: Institute/ForgotPassword
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ForgotPassword(InstituteMaster _obj)
        {
            bool flag = false;
            bool flagHead = false;
            bool flagCaptcha = false;
            string Email = "";
            string Error = string.Empty;
            InstituteRepository _objRepository = new InstituteRepository();
            try
            {
                if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                {
                    flagCaptcha = true;
                    string password = Membership.GeneratePassword(8, 1);
                    _obj.DefaultPassword = password;
                    DataSet ds = _objRepository.InstituteForgotPassword(_obj);
                    SendEmail _objseedemail = new SendEmail();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                        {
                            //string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
                            string strform = string.Empty;
                            #region Code to send mails simultaneously in a loop (By Amit: 14-06-2019 11:45 AM)
                            if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
                            {
                                System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
                            }
                            else
                            {

                            }
                            int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"]);
                            if (UserCountForMail < 4)
                            {
                                UserCountForMail++;
                            }
                            else
                            {
                                UserCountForMail = 1;
                            }

                            System.Web.HttpContext.Current.Application["UserCountForMail"] = UserCountForMail;
                            if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
                            {
                                System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
                            }
                            else
                            {

                            }
                            //int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"]);
                            if (UserCountForMail < 4)
                            {
                                UserCountForMail++;
                            }
                            else
                            {
                                UserCountForMail = 1;
                            }
                            if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
                            {
                                System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
                            }
                            if (UserCountForMail == 1)
                            {
                                strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                            }
                            else if (UserCountForMail == 2)
                            {
                                strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername2"];
                            }
                            else if (UserCountForMail == 3)
                            {
                                strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername3"];
                            }
                            else if (UserCountForMail == 4)
                            {
                                strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername4"];
                            }

                            #endregion
                            string Subject = "Forgot Password: Study in India";
                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("<br/>Dear Sir/Madam <br/>");
                            MailBody.Append("<br/>You may now login with below credentials:");
                            MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["InstituteID"].ToString());
                            MailBody.Append("<br/>Password: " + password.ToString());
                            //MailBody.Append("<br/><br/><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login' style='color:blue;'>click here</a> to reset your Student Portal password." + "<br/>");
                            MailBody.Append("<br/>Please note: This is an auto generated email.<br/>");
                            MailBody.Append("<br/>Regards,<br/>");
                            MailBody.Append("Team Study in India (SII)<br/>");
                            string bcc = "";
                            string cc = "";
                            Email = ds.Tables[0].Rows[0]["Email"].ToString();
                            //Email = "amit@inflibnet.ac.in";
                            //_objseedemail.SendEmailInBackgroundThread(strform, Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                            _objseedemail.SendEmailForRegistration(strform, Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                            flag = true;
                            flagHead = true;
                        }
                        else if(ds.Tables[0].Rows[0]["COUNTS"].ToString() == "-1")
                        {
                            flag = true;
                            flagHead = false;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
                Error = ex.Message;
            }
            return Json(new
            {
                flag = flag,
                flagCaptcha = flagCaptcha,
                flagHead= flagHead,
                Email = Email,
                e = Error
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
    }
}