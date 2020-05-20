using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Threading;

namespace SII
{
    public class SendEmail
    {
        public void SendEmailInBackgroundThread(string strFrom, string strTo, string strbcc, string strcc, string strSubject, string strBody, string strAttachmentPath, bool IsBodyHTML, String FiredEmailDateTime = "")
        {
            string username = string.Empty;
            string password = string.Empty;
            string host = string.Empty;
            string port = string.Empty;

            #region Code to send mails simultaneously in a loop (By Amit: 14-06-2019 11:45 AM)
            /*
            if (System.Web.HttpContext.Current.Application["UserCountForMail"] == null)
            {
                System.Web.HttpContext.Current.Application["UserCountForMail"] = 1;
            }
            int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"].ToString());

            if (UserCountForMail == 1)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword1"];
                host = System.Configuration.ConfigurationManager.AppSettings["host1"];
                port = System.Configuration.ConfigurationManager.AppSettings["port1"];
            }
            else if (UserCountForMail == 2)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername2"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword2"];
                host = System.Configuration.ConfigurationManager.AppSettings["host2"];
                port = System.Configuration.ConfigurationManager.AppSettings["port2"];
            }
            else if (UserCountForMail == 3)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername3"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword3"];
                host = System.Configuration.ConfigurationManager.AppSettings["host3"];
                port = System.Configuration.ConfigurationManager.AppSettings["port3"];
            }
            else if (UserCountForMail == 4)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername4"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword4"];
                host = System.Configuration.ConfigurationManager.AppSettings["host4"];
                port = System.Configuration.ConfigurationManager.AppSettings["port4"];
            }
            */
            #endregion

            username = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
            password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword1"];
            host = System.Configuration.ConfigurationManager.AppSettings["host"];
            port = System.Configuration.ConfigurationManager.AppSettings["port"];

            string emailTo = strTo;
            string body = strBody;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(strFrom);
            mail.To.Add(emailTo);
            mail.Subject = strSubject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            if (strAttachmentPath != "")
            {
                string[] multiAttachment = strAttachmentPath.Split(';');
                string newAttachment = string.Empty;
                for (int i = 0; i < multiAttachment.Length; i++)
                {
                    if (System.IO.Directory.Exists(multiAttachment[i]))
                    {
                        if (i != 0)
                        {
                            newAttachment = newAttachment + ";";
                        }
                        newAttachment = newAttachment + multiAttachment[i];
                    }
                }
                if (strAttachmentPath != "")
                {
                    mail.Attachments.Add(new Attachment(strAttachmentPath));
                }
            }
            Thread bgThread = new Thread(new ParameterizedThreadStart(SendEmails));
            bgThread.IsBackground = true;
            bgThread.Start(mail);
        }
        public void SendEmails(Object mailMsg)
        {
            MailMessage mailMessage = (MailMessage)mailMsg;
            try
            {
                /* Setting should be kept somewhere so no need to 
                   pass as a parameter (might be in web.config)       */
                SmtpClient smtpClient = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["host"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
                networkCredential.Password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword"];
                smtpClient.Credentials = networkCredential;
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["port"]))
                    smtpClient.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["port"]);

                //If you are using gmail account then
                smtpClient.EnableSsl = true;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(mailMessage);
            }
            catch (SmtpException)
            {
                // Code to Log error
            }
        }
        public Boolean SEND_SMS(string userid, string Pass, string sssid, string strTo, string strbcc, string strcc, string message)
        {
            string username = string.Empty;
            string password = string.Empty;
            string link = string.Empty;
            username = System.Configuration.ConfigurationManager.AppSettings["OTPUsername"];
            password = System.Configuration.ConfigurationManager.AppSettings["OTPPassword"];
            link = System.Configuration.ConfigurationManager.AppSettings["OTPSMSLink"];
            string SMSmsg = strTo;
            try
            {

                string sURL = link + "?LoginID=" + username + "&pwd=" + password + "&cellNo=" + SMSmsg + "&SID=" + sssid + "&Message=" + message;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string resp = sr.ReadToEnd();
                // int result = objEmployeeMasterBL.InsertOTPDetails(objEmployeeMasterBO, OTP);
                // Response.Redirect("Login_OTP.aspx");
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public Boolean SendEmailForRegistration(string strFrom, string strTo, string strbcc, string strcc, string strSubject, string strBody, string strAttachmentPath, bool IsBodyHTML, String FiredEmailDateTime = "")
        {
            string username = string.Empty;
            string password = string.Empty;
            string host = string.Empty;
            string port = string.Empty;


            //strTo = "khushboo@inflibnet.ac.in";
            username = System.Configuration.ConfigurationManager.AppSettings["Username"];
            password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            host = System.Configuration.ConfigurationManager.AppSettings["Host"];
            port = System.Configuration.ConfigurationManager.AppSettings["Port"];

            int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"].ToString());

            if (UserCountForMail == 1)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword1"];
            }
            else if (UserCountForMail == 2)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername2"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword2"];
            }
            else if (UserCountForMail == 3)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername3"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword3"];
            }
            else if (UserCountForMail == 4)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername4"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword4"];
            }

            host = System.Configuration.ConfigurationManager.AppSettings["host"];
            port = System.Configuration.ConfigurationManager.AppSettings["port"];

            string body = strBody;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(username);
                mail.To.Add(strTo);
                if (strcc != "")
                {
                    mail.CC.Add(strcc);
                }

                mail.Subject = strSubject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(host, Convert.ToInt32(port)))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;
                    smtp.ServicePoint.MaxIdleTime = 1;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return false;
        }
        public Boolean Send_Email(string strFrom, string strTo, string strbcc, string strcc, string strSubject, string strBody, string strAttachmentPath, bool IsBodyHTML, String FiredEmailDateTime = "")
        {
            string username = string.Empty;
            string password = string.Empty;
            string host = string.Empty;
            string port = string.Empty;


            //strTo = "khushboo@inflibnet.ac.in";
            username = System.Configuration.ConfigurationManager.AppSettings["Username"];
            password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            host = System.Configuration.ConfigurationManager.AppSettings["Host"];
            port = System.Configuration.ConfigurationManager.AppSettings["Port"];

            int UserCountForMail = Convert.ToInt32(System.Web.HttpContext.Current.Application["UserCountForMail"].ToString());

            if (UserCountForMail == 1)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword1"];
            }
            else if (UserCountForMail == 2)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername2"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword2"];
            }
            else if (UserCountForMail == 3)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername3"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword3"];
            }
            else if (UserCountForMail == 4)
            {
                username = System.Configuration.ConfigurationManager.AppSettings["Emailusername4"];
                password = System.Configuration.ConfigurationManager.AppSettings["Emailpassword4"];
            }

            host = System.Configuration.ConfigurationManager.AppSettings["host"];
            port = System.Configuration.ConfigurationManager.AppSettings["port"];

            string body = strBody;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(username, "Study in India Cell");
                mail.To.Add(strTo);
                if (strcc != "")
                {
                    mail.CC.Add(strcc);
                }

                mail.Subject = strSubject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //if (strAttachmentPath != "")
                //{
                //    string[] multiAttachment = strAttachmentPath.Split(';');
                //    string newAttachment = string.Empty;
                //    for (int i = 0; i < multiAttachment.Length; i++)
                //    {
                //        if (System.IO.Directory.Exists(multiAttachment[i]))
                //        {
                //            if (i != 0)
                //            {
                //                newAttachment = newAttachment + ";";
                //            }
                //            newAttachment = newAttachment + multiAttachment[i];
                //        }
                //    }
                //    if (strAttachmentPath != "")
                //    {
                //        mail.Attachments.Add(new Attachment(strAttachmentPath));
                //    }
                //}
                using (SmtpClient smtp = new SmtpClient(host, Convert.ToInt32(port)))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    smtp.ServicePoint.MaxIdleTime = 1;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return true;
        }
    }
}