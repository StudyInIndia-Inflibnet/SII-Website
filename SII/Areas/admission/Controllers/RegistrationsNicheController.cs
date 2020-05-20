using SII.Filters;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Areas.admission.Controllers
{
    public class RegistrationsNicheController : Controller
    {
        // GET: admission/Registrations
        public ActionResult Index(string instituteid = null, string For = null, string NicheCourseId = null)
        {
            selectDropdown();
            if (NicheCourseId == "")
            {
                TempData["NicheCourseId"] = "";
            }
            else
            {
                TempData["NicheCourseId"] = NicheCourseId;
            }
            TempData.Keep("NicheCourseId");


            if (For == "")
            {
                TempData["For"] = "";
            }
            else
            {
                TempData["For"] = For;
            }
            TempData.Keep("For");


            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            return View();
        }
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Nationality> _Nationality = new List<Nationality>();
            List<Country> _Country = new List<Country>();
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
                        _Country.Add(_objcountry);
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
            ViewBag.Year = _Date;
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        //[RecaptchaFilter], bool CaptchaValid
#pragma warning disable SCS0016 // Controller method is vulnerable to CSRF
        public JsonResult RegistationUser(Student_Register _obj)
#pragma warning restore SCS0016 // Controller method is vulnerable to CSRF
        {

            //_obj.instituteid = TempData["instituteid"].ToString();
            //_obj.NicheCourseID = TempData["NicheCourseId"].ToString();

            bool flagCaptcha = false;
            bool flagValidID = true;
            bool flagDOB = true;
            string[] DMonths = null;
            string Studentid = null;
            try
            {
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
                               //StringBuilder hashPassword = new StringBuilder();
                               //string new_password = _obj.ActualPassword;
                               //switch (month)
                               //{
                               //    case 1:
                               //        hashPassword.Append(Helper.ComputeHash(new_password, "MD5", null));
                               //        break;

                        //    case 2:
                        //        hashPassword.Append(Helper.ComputeHash(new_password, "SHA1", null));
                        //        break;

                        //    case 3:
                        //        hashPassword.Append(Helper.ComputeHash(new_password, "SHA256", null));
                        //        break;

                        //    case 4:
                        //        hashPassword.Append(Helper.ComputeHash(new_password, "SHA384", null));
                        //        break;

                        //    case 5:
                        //        hashPassword.Append(Helper.ComputeHash(new_password, "SHA512", null));
                        //        break;
                        //}
                        //_obj.ActualPassword = hashPassword.ToString();
                        _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        DataSet ds = _objRepository.InsertStudentRegistration_Niche(_obj);
                        SendEmail _objseedemail = new SendEmail();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Exist"].ToString() == "0")
                            {
                                flagValidID = true;
                                string strform = "";
                                if (_obj.Email.ToString() != "")
                                {
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

                                    string Subject = "Student Login";
                                    StringBuilder MailBody = new StringBuilder();
                                    MailBody.Append("<br/>Dear " + _obj.FirstName + " " + _obj.LastName + ",<br/>");
                                    MailBody.Append("<br/>Thank You for registering at Study in India. The applications for 2019 or 2020 admissions have already begun.");
                                    MailBody.Append("<br/>");
                                    MailBody.Append("<br/>Username: " + ds.Tables[0].Rows[0]["UserName"].ToString());
                                    MailBody.Append("<br/>Mobile: " + ds.Tables[0].Rows[0]["Mobile"].ToString());
                                    MailBody.Append("<br/>Email: " + ds.Tables[0].Rows[0]["Email"].ToString());
                                    MailBody.Append("<br/>");
                                    // MailBody.Append("<br/>To activate your account <b><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/login?eid=" + Encrypt_Decrypt.EncryptData(_obj.Email, "") + "'>click on the following link </a> </b>");
                                    MailBody.Append("<br/>");
                                    MailBody.Append("<br/>Please note: Kindly keep this details for future  usage.<br/>");
                                    MailBody.Append("<br/><br/><br/>Regards,<br/>");
                                    MailBody.Append("Study in India Team<br/>");
                                    string bcc = "";
                                    string cc = "";
                                    _objseedemail.SendEmailForRegistration(strform, _obj.Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                                    SendemailForCourse(ds.Tables[0].Rows[0]["studentid"].ToString(), ds.Tables[0].Rows[0]["NicheCourseID"].ToString(), ds.Tables[0].Rows[0]["Email"].ToString(), _obj.FirstName + " " + _obj.LastName);
                                    Studentid = ds.Tables[0].Rows[0]["studentid"].ToString();
                                }
                            }
                            else
                            {
                                flagValidID = false;
                            }

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
                flagValidID = flagValidID,
                flagDOB = flagDOB,
                Studentid = Studentid
            },
                JsonRequestBehavior.AllowGet
            );
        }

        public JsonResult RegistationUserForCourse(Student_Register _obj)
        {
            string flagValidID = "";
            string flagValidCourse = "";
            string InstituteName = "";
            string CourseDetails = "";
            try
            {
                StudentRepository _objRepository = new StudentRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.Created_Ip = localIP;
                _obj.Created_Ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
                DataSet ds = _objRepository.InsertUpdatet_tbl_Student_Ch_Choice_Filling_NicheCourse(_obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Count"].ToString() == "1")
                    {
                        flagValidID = "True";
                        flagValidCourse = "True";
                        SendemailForCourse(ds.Tables[1].Rows[0]["Studentid"].ToString(), _obj.NicheCourseID.ToString(), ds.Tables[1].Rows[0]["Email"].ToString(), ds.Tables[1].Rows[0]["FirstName"].ToString() + " " + ds.Tables[1].Rows[0]["LastName"].ToString());
                        InstituteName = ds.Tables[2].Rows[0]["InstituteName"].ToString();
                        CourseDetails = ds.Tables[2].Rows[0]["Natureofcourse"].ToString();
                    }
                    else if (ds.Tables[0].Rows[0]["Count"].ToString() == "0")
                    {
                        flagValidID = "false";
                        flagValidCourse = "false";
                    }
                    else if (ds.Tables[0].Rows[0]["Count"].ToString() == "-2")
                    {
                        flagValidID = "True";
                        flagValidCourse = "false";
                    }
                    else
                    {
                        flagValidID = "false";
                        flagValidCourse = "false";
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
            return Json(new
            {
                flagValidID = flagValidID,
                flagValidCourse = flagValidCourse,
                Institute = InstituteName,
                CourseType = CourseDetails
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

        public ActionResult ThankYou(string instituteid = null, string For = null, string NicheCourseId = null)
        {
            if (NicheCourseId == "")
            {
                TempData["NicheCourseId"] = "";
            }
            else
            {
                TempData["NicheCourseId"] = NicheCourseId;
            }
            TempData.Keep("NicheCourseId");


            if (For == "")
            {
                TempData["For"] = "";
            }
            else
            {
                TempData["For"] = For;
            }
            TempData.Keep("For");


            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            return View();
        }
#pragma warning disable SCS0029 // Potential XSS vulnerability
        public string SendemailForCourse(string Studentid = "", string NicheCourseId = "", string Email = "", string name = "")
#pragma warning restore SCS0029 // Potential XSS vulnerability
        {
            string msg = "";
            SendEmail _objseedemail = new SendEmail();
            SIIRepository.Institute.InstituteRepository _objRepository = new SIIRepository.Institute.InstituteRepository();
            System.Data.DataSet ds = _objRepository.Get_Dashboard_Modal_Data(TempData["instituteid"].ToString(), "NicheCourses", "", ConfigurationManager.AppSettings["ParticipatedYear"].ToString(), TempData["NicheCourseId"].ToString());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strform = "";
                    if (Email.ToString() != "")
                    {
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
                        string Subject = "Study In India|| Course Apply";
                        StringBuilder MailBody = new StringBuilder();
                        MailBody.Append("<br/>Dear " + name + ",<br/>");
                        MailBody.Append("<br/>Thank You for applying for below listed course at Study in India.");
                        MailBody.Append("<br/>");
                        MailBody.Append("<br/><b>Institute Name: </b>" + ds.Tables[0].Rows[0]["InstituteName"].ToString());
                        MailBody.Append("<br/><b>City: </b>" + ds.Tables[0].Rows[0]["City"].ToString());

                        //MailBody.Append("<br/><b>Course type: </b>" + ds.Tables[0].Rows[0]["CourseType"].ToString());
                        MailBody.Append("<br/><b>Discipline: </b>" + ds.Tables[0].Rows[0]["Discipline"].ToString());
                        MailBody.Append("<br/><b>Course of Study: </b>" + ds.Tables[0].Rows[0]["Natureofcourse"].ToString());
                        //MailBody.Append("<br/><b>Program Level: </b>" + ds.Tables[0].Rows[0]["ProgramLevel"].ToString());
                        //MailBody.Append("<br/><b>Branch/Subject : </b>" + ds.Tables[0].Rows[0]["BranchName"].ToString());
                        MailBody.Append("<br/><b>Start Date: </b>" + ds.Tables[0].Rows[0]["StartDate"].ToString());
                        MailBody.Append("<br/><b>End Date: </b>" + ds.Tables[0].Rows[0]["EndDate"].ToString());
                        MailBody.Append("<br/><b>Total Fees: </b>" + ds.Tables[0].Rows[0]["TotalFeesCurrency"].ToString() + "   " + ds.Tables[0].Rows[0]["TotalFees"].ToString());
                        if (ds.Tables[0].Rows[0]["EligibilityCriteria"].ToString() != "")
                        {
                            MailBody.Append("<br/><b>Eligibility Criteria (if any) : </b>" + ds.Tables[0].Rows[0]["EligibilityCriteria"].ToString());
                        }
                        //if (ds.Tables[0].Rows[0]["AditionalExamsCriteria"].ToString() != "")
                        //{
                        //    MailBody.Append("<br/><b>Aditional Exams Criteria : </b>" + ds.Tables[0].Rows[0]["AditionalExamsCriteria"].ToString());
                        //}
                        //if (ds.Tables[0].Rows[0]["AditionalExamsCriteria"].ToString() != "")
                        //{
                        //    MailBody.Append("<br/><b>Aditional Exams Criteria : </b>" + ds.Tables[0].Rows[0]["AditionalExamsCriteria"].ToString());
                        //}
                        //if (ds.Tables[0].Rows[0]["AdmissionReq"].ToString() != "")
                        //{
                        //    MailBody.Append("<br/><b>Admission Requirement : </b>" + ds.Tables[0].Rows[0]["AdmissionReq"].ToString());
                        //}
                        if (ds.Tables[0].Rows[0]["CourseDesc"].ToString() != "")
                        {
                            MailBody.Append("<br/><b>Course Description : </b>" + ds.Tables[0].Rows[0]["CourseDesc"].ToString());
                        }
                        MailBody.Append("<br/>");
                        MailBody.Append("<br/><b>Point of contact from the Institute is: </b>");
                        MailBody.Append("<br/><b> Name: </b>" + ds.Tables[0].Rows[0]["NodalPrefix"].ToString() + " " + ds.Tables[0].Rows[0]["NodalFirstName"].ToString() + " " + ds.Tables[0].Rows[0]["NodalLastName"].ToString());
                        MailBody.Append("<br/><b> Email: </b>" + ds.Tables[0].Rows[0]["NodalEmail"].ToString());
                        MailBody.Append("<br/><b> Phone: </b>" + ds.Tables[0].Rows[0]["NodalPhone"].ToString());
                        MailBody.Append("<br/>");

                        MailBody.Append("<br/>Please note: Kindly keep these details for further usage.<br/>");
                        MailBody.Append("<br/>Regards,");
                        MailBody.Append("<br/> Study in India Cell<br/>");
                        MailBody.Append("<br/><a href ='https://studyinindia.gov.in/'> https://studyinindia.gov.in/</a>");
                        MailBody.Append("<br/><strong style='style = 'font-size:16px;color:white;background:mediumturquoise;'> <i> Diversify. Learn. Rise. </i></strong>");
                        MailBody.Append("<br/><br/><strong> Find us on:</em></strong>");
                        MailBody.Append("<br/><a href = 'https://www.facebook.com/studyinindiagov/'> Facebook </a> &nbsp;| &nbsp;<a href = 'https://twitter.com/StudyInIndiaGov' > Twitter </a> &nbsp;| &nbsp;<a href = 'https://www.instagram.com/studyinindiagov/' > Instagram </a>");
                        string cc = "";
                        string bcc = "";
                        _objseedemail.SendEmailForRegistration(strform, Email, bcc, cc, Subject, MailBody.ToString(), "", true);
                        msg = "Success";
                    }

                }

            }

            return msg;
        }
    }
}