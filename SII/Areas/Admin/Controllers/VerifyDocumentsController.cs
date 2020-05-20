using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class VerifyDocumentsController : Controller
    {
        // GET: Admin/VerifyDocuments
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "VerifyDocuments";
            return View();
        }
        public ActionResult Verified()
        {
            ViewBag.CurrentMenu = "VerifyDocuments"; return View();
        }
        public ActionResult Rejected()
        {
            ViewBag.CurrentMenu = "VerifyDocuments";
            return View();
        }
        public ActionResult NotVerified()
        {
            ViewBag.CurrentMenu = "VerifyDocuments";
            return View();
        }
        public ActionResult StudentData(string id)
        {
            ViewBag.CurrentMenu = "VerifyDocuments";
            TempData["studentid"] = id;
            TempData.Keep();
            return View();
        }
        [HttpPost]
#pragma warning disable SCS0016 // Controller method is vulnerable to CSRF
        public JsonResult SaveStudentData(string id, string Docs)
#pragma warning restore SCS0016 // Controller method is vulnerable to CSRF
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {

                DocumentVerification_Repository _objRepo = new DocumentVerification_Repository();
                DataSet _ds = _objRepo.Opr_VerifyDocuments(id, Docs);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                        {
                            SendEmail _objseedemail = new SendEmail();
                            string strform = "";
                            string Subject = "Study in India- Data Verification";
                            #region Code to send mails simultaneously in a loop (By Amit: 15-05-2020 10:11 AM)
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

                            string Email = _ds.Tables[1].Rows[0]["Email"].ToString();
                            string Name = _ds.Tables[1].Rows[0]["FirstName"].ToString() + ' ' + _ds.Tables[1].Rows[0]["LastName"].ToString();
                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("<br/>Dear Student,<br/>");
                            MailBody.Append("<br/>Greetings from Study in India!.");
                            if (_ds.Tables[2].Rows.Count > 0 || _ds.Tables[3].Rows.Count > 0)
                            {
                                // For Rejected
                                MailBody.Append("<br/>The documents uploaded by you are checked by Study in India team and some of your documents /percentage filled are found to be <strong>incorrect</strong>.");
                                MailBody.Append("<br/>Following issues were found with your documents/percentage provided:");

                                MailBody.Append("<table border=\"1\" style=\"border-collapse: collapse;\">");
                                MailBody.Append("<thead>");
                                MailBody.Append("<tr>");
                                MailBody.Append("<th>S. No</th>");
                                MailBody.Append("<th>Qualification</th>");
                                MailBody.Append("<th>Verification status</th>");
                                MailBody.Append("<th>Reason</th>");
                                MailBody.Append("<th>Comments</th>");
                                MailBody.Append("</tr>");
                                MailBody.Append("</thead>");


                                MailBody.Append("<tbody>");
                                int i = 1;
                                if (_ds.Tables[2].Rows.Count > 0)
                                {
                                    foreach (DataRow _dr in _ds.Tables[2].Rows)
                                    {
                                        MailBody.Append("<tr>");
                                        MailBody.Append("<td>" + (i++) + "</td>");
                                        MailBody.Append("<td>" + _dr["EduQualificationsName"].ToString() + (_dr["IsGiven"].ToString() == "2" ? " <label class='badge badge-danger'>Result Awaited</label>" : "") + " </td>");
                                        MailBody.Append("<td>"+ _dr["IsVerified"].ToString() + "</td>");
                                        MailBody.Append("<td>"+ _dr["Reason"].ToString() + "</td>");
                                        MailBody.Append("<td>"+ _dr["Comment"].ToString() + "</td>");
                                        MailBody.Append("</tr>");
                                    }
                                }
                                if (_ds.Tables[3].Rows.Count > 0)
                                {
                                    foreach (DataRow _dr in _ds.Tables[3].Rows)
                                    {
                                        MailBody.Append("<tr>");
                                        MailBody.Append("<td>" + (i++) + "</td>");
                                        MailBody.Append("<td>"+ _dr["AditionalExams"].ToString() + "</td>");
                                        MailBody.Append("<td>" + _dr["IsVerified"].ToString() + "</td>");
                                        MailBody.Append("<td>" + _dr["Reason"].ToString() + "</td>");
                                        MailBody.Append("<td>" + _dr["Comment"].ToString() + "</td>");
                                        MailBody.Append("</tr>");
                                    }
                                }
                                MailBody.Append("</tbody>");

                                MailBody.Append("</table>");

                                MailBody.Append("<br/>The status of the same may be checked on your dashboard.");
                                MailBody.Append("<br/><strong>Kindly upload the correct documents/percentage within three days on your dashboard otherwise your application for Study in India shall stand cancelled</strong>.");
                            }
                            else
                            {
                                // For Verified
                                MailBody.Append("<br/>The documents uploaded by you are verified by Study in India team and all your documents are found to be correct.");
                                MailBody.Append("<br/>The status of the same may be checked on your dashboard.");

                            }
                            MailBody.Append("<br/>");
                            MailBody.Append("<br/>");
                            MailBody.Append("<br/>");
                            MailBody.Append("<br/>For further queries, please contact at our toll-free number: +919899450350.<br/>");
                            MailBody.Append("<br/><br/><br/>Regards,<br/>");
                            MailBody.Append("Study in India cell<br/>");
                            string bcc = "";
                            string cc = "";
                            _objseedemail.Send_Email(strform, Email, bcc, cc, Subject, MailBody.ToString(), "", true);


                            Message = "Details has been saved successfully!";
                            Code = "success";
                        }
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException ex)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
                Error = ex.Message;
            }

            return Json(new
            {
                m = Message,
                c = Code,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );

        }

        public JsonResult FillData(string For = "All")
        {
            List<mDocumentVerificationView> _list = new List<mDocumentVerificationView>();
            DocumentVerification_Repository _objRepository = new DocumentVerification_Repository();

            DataSet _ds = _objRepository.Opr_DocumentVerification_Admin("SELECT", ConfigurationManager.AppSettings["CurrentPhase"].ToString(), For);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _list.Add(new mDocumentVerificationView
                        {
                            Srno = _dr["Srno"].ToString(),
                            studentid = _dr["studentid"].ToString(),
                            StudentName = _dr["StudentName"].ToString(),
                            Country_Name = _dr["Country_Name"].ToString(),
                            ProgramLevel = _dr["ProgramLevel"].ToString(),
                            IsVerified = _dr["IsVerified"].ToString(),
                            VerifiedDate = _dr["VerifiedDate"].ToString()
                        });
                    }
                }
            }
            var jsonResult = Json(new { data = _list }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
    }
}