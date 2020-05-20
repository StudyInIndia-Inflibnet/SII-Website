using SII.Models;
using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    public class GenerateDataForMailController : Controller
    {
        // GET: Institute/GenerateDataForMail
        public ActionResult Index()
        {
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _dsInstituteListForGeneration = _objRepository.Select_All_Institutes();
            if (_dsInstituteListForGeneration != null)
            {
                if (_dsInstituteListForGeneration.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsInstituteListForGeneration.Tables[0].Rows)
                    {

                        string InstituteID = "SII-I-" + (Convert.ToInt32(_dr["ID"].ToString())).ToString("D4");

                        string AccessURL = "";
                        AccessURL = FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "Institute/Preamble/Index?u=" + StringCipher.Encrypt(InstituteID);

                        #region Generate Random Password
                        Random random = new Random();
                        string combination = "123456789ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
                        StringBuilder captcha = new StringBuilder();
                        for (int i = 0; i < 8; i++)
#pragma warning disable SCS0005 // Weak random generator
                            captcha.Append(combination[random.Next(combination.Length)]);
#pragma warning restore SCS0005 // Weak random generator
                        string DefaultPassword = captcha.ToString();
                        #endregion

                        DataSet _ds = _objRepository.Update_Institute_Data_For_MailSending(_dr["ID"].ToString(), InstituteID, AccessURL, DefaultPassword);
                    }
                }
            }

            DataSet _dsInstituteListForMailSending = _objRepository.Select_All_Institutes();
            if (_dsInstituteListForMailSending != null)
            {
                if (_dsInstituteListForMailSending.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsInstituteListForMailSending.Tables[0].Rows)
                    {
                        string strform = "amitparmar.msn@gmail.com"; //System.Configuration.ConfigurationManager.AppSettings["formemail"];
                        string Subject = "Registered successfully for Study In India";
                        //string strTo = "amit@inflibnet.ac.in";
                        string strTo = _dr["Email"].ToString();

                        SendEmail _objseedemail = new SendEmail();
                        StringBuilder MailBody = new StringBuilder();
                        MailBody.Append("<br/>Dear Sir/Madam,<br/>");
                        MailBody.Append("<br/>Greetings from Study in India!<br/>");
                        MailBody.Append("<br/>Please ");
                        MailBody.Append("<a target='_blank' href='" + _dr["AccessURL"].ToString() + "' style='color:blue;'>click here</a>");
                        MailBody.Append(" to open Instiute form to fill for Study In India!" + "<br/>");
                        MailBody.Append("Your Login Details:" + "<br/>");
                        MailBody.Append("InstituteID: " + _dr["InstituteID"].ToString() + "<br/>");
                        MailBody.Append("First time Password: " + _dr["DefaultPassword"].ToString() + "<br/><br/>");
                        MailBody.Append("<br/>Please note: This is an auto generated email. In case of any technical queries please contact: <br/>");
                        MailBody.Append("<br/>Regards,<br/>");
                        MailBody.Append("Study in India<br/>");
                        string bcc = "";
                        string cc = "";
                        _objseedemail.SendEmailInBackgroundThread(strform, strTo, bcc, cc, Subject, MailBody.ToString(), "", true);
                        //flagSent = true;
                    }
                }
            }
            ViewBag.Data = _dsInstituteListForMailSending;
            return View();
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