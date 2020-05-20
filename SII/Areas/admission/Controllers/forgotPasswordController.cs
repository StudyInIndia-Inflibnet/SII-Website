using Newtonsoft.Json;
using SII.Filters;
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
    public class forgotPasswordController : Controller
    {
        // GET: admission/forgotPassword
        [RecaptchaFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // [RecaptchaFilter], bool CaptchaValid
        [ValidateAntiForgeryToken]
        public JsonResult ForgotPassword(Student_Register _obj)
        {
            int flag = 0;
            //bool flagExists = false;
            bool flagCaptcha = false;
            string error = "";
            mWebhook _response = null;
            StudentRepository _objRepository = new StudentRepository();
            try
            {
                if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                //if (CaptchaValid)
                {
                    flagCaptcha = true;
                    string password = Membership.GeneratePassword(8, 1);
                    _obj.Random = password;
                    DataSet ds = _objRepository.StudentForgotPassword(_obj);
                    SendEmail _objseedemail = new SendEmail();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                        {
                            //string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
                            string strform = "";
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
                            //string Subject = "Forgot login details of Student";
                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("<br/>Dear " + ds.Tables[0].Rows[0]["StudName"].ToString() + ",<br/>");
                            MailBody.Append("<br/>You may now login with below credentials:");
                            MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["StudId"].ToString() + " or " + _obj.Email);
                            MailBody.Append("<br/>Password: " + password.ToString());
                            MailBody.Append("<br/><br/><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login' style='color:blue;'>click here</a> to reset your Student Portal password." + "<br/>");
                            MailBody.Append("<br/>Please note: This is an auto generated email.<br/>");
                            MailBody.Append("<br/>Regards,<br/>");
                            MailBody.Append("Study in India Team<br/>");
                            //string bcc = "";
                            //string cc = "";
                           /// _obj.Email = "amit@inflibnet.ac.in";
                            //_objseedemail.SendEmailInBackgroundThread(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                           // _objseedemail.SendEmailForRegistration(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                            flag = 1;
                            #region Call PivotRoots Code
                            string strUrl = "https://pivotroots.com/clients/studyinindia/webhooks/user_events";
                            WebRequest request = HttpWebRequest.Create(strUrl);
                            request.Headers.Add("Request-Id", DateTime.Now.ToString("yyyyMMddhhmmss"));
                            request.Method = "POST";
                            request.ContentType = "application/json";
                            request.Headers.Add("Client-Id", "b7a51eff57749dc0e733b74342c8b512");
                            request.Headers.Add("Client-Access-Token", "dfdd5aa8ea4a1e2fb5999dc213476c2a9b68efa7");
                            mWebhookRequestForgot _objJsonRequest = new mWebhookRequestForgot()
                            {
                                timestamp = DateTime.Now.ToString("yyyyMMddhhmmss"),
                                user_id = ds.Tables[0].Rows[0]["StudId"].ToString(),
                                userName = ds.Tables[0].Rows[0]["StudName"].ToString(),
                                emailID = ds.Tables[0].Rows[0]["Email"].ToString(),
                                new_password = password.ToString(),
                                @event = "forgot_password"
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

                            response.Close();
                            s.Close();
                            readStream.Close();
                            #endregion
                        }
                        else if(ds.Tables[0].Rows[0]["COUNTS"].ToString() == "2")
                        {
                            flag = 2;
                        }
                        else
                        {
                            flag = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw;
            }
            return Json(new
            {
                flag = flag,
                flagCaptcha = flagCaptcha,
                e = error

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