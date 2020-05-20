
using SII.Models;
using SIIModel.Institute;
using SIIModel.StudentRegister;
using SIIRepository.Institute;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class AdmittedStudentController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/AdmittedStudent
        public ActionResult Index()
        {
            return View();
        }
        #region StudentList
        public ActionResult StudentsList()
        {
            if (Convert.ToDateTime(Session["AR_StartDate"].ToString()) <= DateTime.Now && Convert.ToDateTime(Session["AR_EndDate"].ToString()) >= DateTime.Now)
            {
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
            }
            //Session["InstituteID"] = "SII-I-0207";
            return View();
        }
        #endregion

        #region Student Section

        #region Students
        public ActionResult Student(string id = "", string i = "1", string ps = "10", string sbt = "")
        {
            if (Convert.ToDateTime(Session["AR_StartDate"].ToString()) <= DateTime.Now && Convert.ToDateTime(Session["AR_EndDate"].ToString()) >= DateTime.Now)
            {
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
            }
            ViewBag.id = id;
            ViewBag.StartIndex = i;
            ViewBag.PageSize = ps;
            ViewBag.SearchByText = sbt;
            ViewBag.StartPage = Convert.ToInt32(Convert.ToInt32(i) / Convert.ToInt32(ps)) + 1;
            TempData["ProgrammeLevel"] = id;
            return View();
        }
        public JsonResult ListOfStudents(string PL = "", string StartIndex = "", string PageSize = "", string SearchByText = "")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SELECT_PHASE2_ALLOTED_STUDENTS_FOR_INSTITUTES(Session["InstituteID"].ToString(), "PrgList", PL, StartIndex, PageSize, SearchByText);
                List<mAdmittedStudentsList> _list = new List<mAdmittedStudentsList>();
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mAdmittedStudentsList
                            {
                                ID = _dr["ID"].ToString(),
                                StudentName = _dr["StudentName"].ToString(),
                                Email = _dr["Email"].ToString(),
                                Mobile = _dr["Mobile"].ToString(),
                                Country_Name = _dr["Country_Name"].ToString(),
                                Discipline = _dr["Discipline"].ToString(),
                                ProgrammeLevel = _dr["ProgrammeLevel"].ToString(),
                                Qualification = _dr["Qualification"].ToString(),
                                CourseOfStudy = _dr["CourseOfStudy"].ToString(),
                                Nationality = _dr["Nationality"].ToString(),
                                StudentID = _dr["StudentID"].ToString(),
                                StudentGender = _dr["StudentGender"].ToString(),
                                IsSeatAlloted = _dr["IsSeatAlloted"].ToString(),
                                InstituteID_Alloted = _dr["InstituteID_Alloted"].ToString(),
                                InstituteCourseID_Alloted = _dr["InstituteCourseID_Alloted"].ToString(),
                                InstituteName = _dr["InstituteName"].ToString(),
                                FeeWaiver = _dr["FeeWaiver"].ToString(),
                                FeeWaiverRemarks = _dr["FeeWaiverRemarks"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString(),
                                ISApprovebyInstitute = _dr["ISApprovebyInstitute"].ToString(),
                                ApprovebyInstituteRemarks = _dr["ApprovebyInstituteRemarks"].ToString(),
                                ApprovebyInstituteDate = _dr["ApprovebyInstituteDate"].ToString(),
                                Doc_AllotmentLetter = _dr["Doc_AllotmentLetter"].ToString(),
                                SkypeInterviewRequired = _dr["SkypeInterviewRequired"].ToString(),
                                SkypeInterviewDate = _dr["SkypeInterviewDate"].ToString(),
                                SkypeInterviewStatus = _dr["SkypeInterviewStatus"].ToString(),
                                StudentStatus = _dr["StudentStatus"].ToString(),
                                StudentStatusRemarks = _dr["StudentStatusRemarks"].ToString(),
                                ApplicationNo = _dr["ApplicationNo"].ToString()
                            });
                        }
                        Message = "Student has been approved successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.!";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
            }

            return Json(new
            {
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Skype Interview
        public ActionResult SkypeInterview(string id = "", string u = "")
        {
            if (Convert.ToDateTime(Session["AR_StartDate"].ToString()) <= DateTime.Now && Convert.ToDateTime(Session["AR_EndDate"].ToString()) >= DateTime.Now)
            {
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
            }
            TempData.Keep("ProgrammeLevel");
            //Session["InstituteID"] = "SII-I-0207";
            try
            {
                ViewBag.id = id;
                ViewBag.U = StringCipher.Decrypt(u);
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS_SELECT(ViewBag.U);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];
                        if (_dr["SkypeInterviewStatus"] != null)
                        {
                            if (_dr["SkypeInterviewStatus"].ToString() != "")
                            {
                                ViewBag.SkypeInterviewStatus = _dr["SkypeInterviewStatus"].ToString();
                            }
                        }
                        if (_dr["SkypeInterviewDate"] != null)
                        {
                            if (_dr["SkypeInterviewDate"].ToString() != "")
                            {
                                ViewBag.SkypeInterviewDate = Convert.ToDateTime(_dr["SkypeInterviewDate"].ToString()).ToString("dd-MM-yyyy");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
                //return RedirectToAction("StudentsList", "AdmittedStudent", new { Area = "Institute" });
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveSkypeInterview(string id = "", string SkypeInterviewStatus = "", string SkypeInterviewDate = "")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS(id, Session["InstituteID"].ToString(), SkypeInterviewStatus, SkypeInterviewDate);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Interview scheduled!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.!";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
            }

            return Json(new
            {
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Approve / Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ARAction(string Approve = "0", string StudentID = "", string CourseID = "", string Remarks = "", string CMRID = "0")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.APPROVE_REJECT_PHASE2_ALLOTED_STUDENTS(Session["InstituteID"].ToString(), StudentID, CourseID, Remarks, Approve, CMRID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (Approve == "1")
                        {
                            Message = "Student has been approved successfully!";
                            DataRow _dr = _ds.Tables[0].Rows[0];
                            SendEmail _objseedemail = new SendEmail();

                            string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
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
                            string Subject = "Congratulations! The institute has accepted your candidature.";
                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("<br/>Dear " + _dr["StudentName"].ToString() + ",<br/>");
                            MailBody.Append("<br/>Congratulations! The institute has accepted your candidature. Please login to your dashboard and accept the offer to Study in India.");
                            MailBody.Append("<br/>To check your results Login at : <a href='https://www.studyinindia.gov.in/admission/login'>https://www.studyinindia.gov.in/admission/login</a><br/>");
                            MailBody.Append("<br/><br/><br/>Regards,<br/>");
                            MailBody.Append("Study in India Team<br/>");
                            string bcc = "";
                            string cc = "";
                            _objseedemail.SendEmailInBackgroundThread(strform, _dr["Email"].ToString(), bcc, cc, Subject, MailBody.ToString(), "", true);
                        }
                        else
                        {
                            Message = "Student has been rejected successfully!";
                        }
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.!";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
            }

            return Json(new
            {
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Upload Admission Letter 
        public ActionResult UploadAllotmentLatter(string id = "", string u = "")
        {
            if (Convert.ToDateTime(Session["AR_StartDate"].ToString()) <= DateTime.Now && Convert.ToDateTime(Session["AR_EndDate"].ToString()) >= DateTime.Now)
            {
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
            }
            TempData.Keep("ProgrammeLevel");
            try
            {
                ViewBag.id = id;
                ViewBag.U = StringCipher.Decrypt(u);
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS_SELECT(ViewBag.U);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];
                        if (_dr["SkypeInterviewStatus"] != null)
                        {
                            if (_dr["SkypeInterviewStatus"].ToString() != "")
                            {
                                ViewBag.SkypeInterviewStatus = _dr["SkypeInterviewStatus"].ToString();
                            }
                        }
                        if (_dr["SkypeInterviewDate"] != null)
                        {
                            if (_dr["SkypeInterviewDate"].ToString() != "")
                            {
                                ViewBag.SkypeInterviewDate = Convert.ToDateTime(_dr["SkypeInterviewDate"].ToString()).ToString("dd-MM-yyyy");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
                //return RedirectToAction("StudentsList", "AdmittedStudent", new { Area = "Institute" });
            }

            return View();
        }
        [HttpPost]
#pragma warning disable SCS0016 // Controller method is vulnerable to CSRF
        public JsonResult UploadAllotmentLatterDoc(string id = "")
#pragma warning restore SCS0016 // Controller method is vulnerable to CSRF
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty, path = string.Empty;
            try
            {
                if (Convert.ToDateTime(Session["AR_StartDate"].ToString()) <= DateTime.Now && Convert.ToDateTime(Session["AR_EndDate"].ToString()) >= DateTime.Now)
                {
                }
                else
                {
                    return Json(new
                    {
                        flag = false
                    },
                        JsonRequestBehavior.AllowGet
                    );
                }
                TempData.Keep("ProgrammeLevel");

                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/AllotmentLetter/" + ViewBag.id;
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {
                            string[] curentfiles = Directory.GetFiles(path);
                        }
                        HttpPostedFileBase file = files[0];
                        filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                        fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + ViewBag.id), filename);
                        file.SaveAs(fname);
                        path = "Uploads/studentDocument/" + ViewBag.id + "/" + filename;
                    }
                    else
                    {
                        path = "";
                    }
                }
                else
                {
                    path = "";
                }
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.ALLOTMENT_UPLOAD_PHASE2_ALLOTED_STUDENTS(id, Session["InstituteID"].ToString(), path);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Document uploaded successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.!";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
            }

            return Json(new
            {
                c = Code,
                m = Message,
                p = path
            },
               JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Travel Document
        public ActionResult TravelDocumentation(string id = "", string a = "", string p = "")
        {
            try
            {
                ViewBag.StudentID = id;
                ViewBag.ApplicationNo = StringCipher.Decrypt(a);
                ViewBag.ProgramLevel = p;
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_Student_TravelPlan_Status(ViewBag.StudentID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            ViewBag.HasPassportDetails = _dr["HasPassportDetails"].ToString();
                            ViewBag.HasAirTicketDetails = _dr["HasAirTicketDetails"].ToString();
                            ViewBag.HasVisaDetails = _dr["HasVisaDetails"].ToString();
                            ViewBag.HasInstituteSpocDetails = _dr["HasInstituteSpocDetails"].ToString();
                            ViewBag.IsAdmittedByInstitute = _dr["IsAdmittedByInstitute"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        #region Institite SPOC
        public ActionResult InstituteSpoc(string id = "")
        {
            try
            {
                ViewBag.id = id;
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadDocs(string ProgramLevel = "", string DocumentName = "", string OtherDocumentName = "")
        {

            string Message = string.Empty, Code = string.Empty, Error = string.Empty, FinalPath = string.Empty, path = string.Empty, filename = string.Empty, fname = string.Empty, folderPath = string.Empty, name = string.Empty;
            try
            {
                if (DocumentName == "Other")
                {
                    name = OtherDocumentName;
                }
                else
                {
                    name = DocumentName;
                }
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        folderPath = "Uploads/Institute/" + Session["InstituteID"].ToString() + "/TravelPlan/";
                        path = AppDomain.CurrentDomain.BaseDirectory + folderPath;
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        name = name.Trim().Replace(" / ", "_");
                        name = name.Trim().Replace("/", "_");
                        name = name.Trim().Replace(" ", "_");
                        name = name.Trim().Replace(".", "_");
                        name = name.Trim().Replace(",", "_");
                        name = name.Trim().Replace("-", "_");
                        filename = Session["InstituteID"].ToString() + "_" + name + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(file.FileName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {
                            string[] curentfiles = Directory.GetFiles(path);
                            foreach (string curentfile in curentfiles)
                            {
                                if (curentfile.IndexOf(filename) >= 0)
                                {
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                    System.IO.File.Delete(path: curentfile);
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                }
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/" + folderPath), filename);
                        file.SaveAs(fname);
                        FinalPath = folderPath + filename;
                    }
                    else
                    {
                        FinalPath = "";
                    }
                }
                else
                {
                    FinalPath = "";
                }
                if (FinalPath != "")
                {
                    Message = "Document uploaded successfully!";
                    Code = "success";
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {

                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }

            return Json(new
            {
                m = Message,
                c = Code,
                p = FinalPath
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveInstituteSpoc(mTravelPlanInstituteSpoc _obj)
        {

            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.CreatedIP = Session["localIP"].ToString();
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.INSERT_UPDATE_StudentTravelInstituteSpoc(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                        {
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
        public JsonResult SelectInstituteSpoc(string id, string ProgramLevel = "")
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanInstituteSpoc> _list = new List<mTravelPlanInstituteSpoc>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_StudentTravelInstituteSpoc(id, Session["InstituteID"].ToString(), ProgramLevel);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mTravelPlanInstituteSpoc
                            {
                                ID = _dr["ID"].ToString(),
                                NameOfSpoc = _dr["NameOfSpoc"].ToString(),
                                StudentIDs = _dr["StudentIDs"].ToString(),
                                Mobile = _dr["Mobile"].ToString(),
                                Email = _dr["Email"].ToString(),
                                DocumentName1 = _dr["DocumentName1"].ToString(),
                                OtherDocumentName1 = _dr["OtherDocumentName1"].ToString(),
                                DoumentPath1 = _dr["DoumentPath1"].ToString(),
                                DocumentName2 = _dr["DocumentName2"].ToString(),
                                OtherDocumentName2 = _dr["OtherDocumentName2"].ToString(),
                                DoumentPath2 = _dr["DoumentPath2"].ToString(),
                                DocumentName3 = _dr["DocumentName3"].ToString(),
                                OtherDocumentName3 = _dr["OtherDocumentName3"].ToString(),
                                DoumentPath3 = _dr["DoumentPath3"].ToString(),
                                DocumentName4 = _dr["DocumentName4"].ToString(),
                                OtherDocumentName4 = _dr["OtherDocumentName4"].ToString(),
                                DoumentPath4 = _dr["DoumentPath4"].ToString(),
                                DocumentName5 = _dr["DocumentName5"].ToString(),
                                OtherDocumentName5 = _dr["OtherDocumentName5"].ToString(),
                                DoumentPath5 = _dr["DoumentPath5"].ToString()
                            });
                        }
                        Message = "Details has been saved successfully!";
                        Code = "success";
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
                e = Error,
                List = _list
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult DeleteInstituteSpoc(string id, string ProgramLevel = "")
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanInstituteSpoc> _list = new List<mTravelPlanInstituteSpoc>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.DELETE_StudentTravelInstituteSpoc(id, Session["InstituteID"].ToString(), ProgramLevel);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Details has been deleted successfully!";
                        Code = "success";
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
                e = Error,
                List = _list
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Student Admitted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult StudentAdmitted(string StudentID = "", string ProgramLevel = "", string Admitted = "")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.STUDENT_ADMITTED_BY_INSTITUTE(StudentID, Session["InstituteID"].ToString(), ProgramLevel, Admitted);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Student [" + StudentID + "] has " + (Admitted == "1" ? "completed on-board" : "dropped out") + " successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.!";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
                Error = ex.Message;
            }

            return Json(new
            {
                c = Code,
                m = Message,
                e = Error
            },
               JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #endregion

        #endregion
    }
}