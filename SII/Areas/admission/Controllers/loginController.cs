using SII.Filters;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class loginController : Controller
    {
        // GET: admission/login
        [RecaptchaFilter]
        public ActionResult Index(string eid = "")
        {
            if (eid == "")
            {

            }
            else
            {
                StudentRepository _objRepository = new StudentRepository();
                DataSet ds = _objRepository.student_login_activation_link(Encrypt_Decrypt.DecryptData(eid, ""));
                if (ds != null)
                {
                }

            }
            if (Session["studentid"] != null && Session["IsPasswordChanged"] != null && Session["ischangedpassword"] != null)
            {
                if (Session["studentid"].ToString() != "" && Session["IsPasswordChanged"].ToString() == "True" && Session["ischangedpassword"].ToString() == "True")
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "admission" });
                }
            }
            return View();
        }

        [HttpPost]
        //  [RecaptchaFilter] , bool CaptchaValid
        [ValidateAntiForgeryToken]
        public JsonResult CheckLogin(Student_Register _obj)
        {
            bool flagCaptcha = false;
            bool flagLogin = false;
            bool flagPasswordChanged = true;
            bool flagValidID = false;
            String RegistrationPhase = "";
            try
            {
                if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                //if (CaptchaValid)
                {
                    flagCaptcha = true;
                    StudentRepository _objRepository = new StudentRepository();
                    DataSet ds = _objRepository.Login_Student(_obj);
                    if (ds != null)
                    {
                        Session["IsChangePwd"] = null;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            flagValidID = true;
                            DataRow dr = ds.Tables[0].Rows[0];
                            string actualPassword = dr["ActualPassword"].ToString();
                            string random = "";
                            if (dr["Random"] != null)
                            {
                                random = dr["Random"].ToString();
                            }
                            if (dr["IsPasswordChanged"].ToString().ToLower() == "true" && dr["ischangedpassword"].ToString().ToLower() == "true")
                            {
                                string PASSWORD = _obj.ActualPassword;
                                string MD5 = Helper.VerifyHash(PASSWORD, "MD5", actualPassword).ToString();
                                string SHA1 = Helper.VerifyHash(PASSWORD, "SHA1", actualPassword).ToString();
                                string sha256 = Helper.VerifyHash(PASSWORD, "SHA256", actualPassword).ToString();
                                string sha384 = Helper.VerifyHash(PASSWORD, "SHA384", actualPassword).ToString();
                                string sha512 = Helper.VerifyHash(PASSWORD, "SHA512", actualPassword).ToString();
                                if (MD5 == "True" || SHA1 == "True" || sha256 == "True" || sha384 == "True" || sha512 == "True")
                                {
                                    TempData["old_password"] = PASSWORD;
                                    flagLogin = true;
                                }
                            }
                            else
                            {
                                if (random != "")
                                {
                                    if (random == _obj.ActualPassword)
                                    {
                                        flagLogin = true;
                                        flagPasswordChanged = false;
                                        TempData["old_password"] = random;
                                    }
                                }
                            }
                            if (flagLogin)
                            {
                                Session["studentid"] = dr["studentid"].ToString();


                                Session["studentname"] = dr["studentname"].ToString();
                                Session["Email"] = dr["Email"].ToString();
                                Session["Mobile"] = dr["Mobile"].ToString();
                                Session["StudentProfilePic"] = "/assets/img/avatar.png";
                                Session["submitChoiceFill"] = dr["submitChoiceFill"].ToString();
                                Session["submitchoiceDate"] = dr["submitchoiceDate"].ToString();
                                Session["EditApplication"] = dr["EditApplication"].ToString();
                                //Session["submitChoiceFill"] = "false";
                                Session["IsPasswordChanged"] = dr["IsPasswordChanged"].ToString();
                                Session["ischangedpassword"] = dr["ischangedpassword"].ToString();
                                Session["IsSeatAlloted"] = dr["IsSeatAlloted"].ToString();
                                Session["IsAllowEditData"] = dr["IsAllowEditData"].ToString();
                                Session["AllowChoiceFilling"] = dr["AllowChoiceFilling"].ToString();
                                Session["CountryID"] = dr["CountryID"].ToString();
                                Session["RegistrationPhase"] = dr["RegistrationPhase"].ToString();
                                RegistrationPhase = dr["RegistrationPhase"].ToString();
                                Session["OpenChoiceFilling_"] = dr["OpenChoiceFilling_"].ToString();
                                Session["IndividualOpenChoiceFilling_"] = dr["IndividualOpenChoiceFilling_"].ToString();
                                Session["ApplyingForCourse"] = dr["ApplyingForCourse"].ToString();
                                Session["isTestStudent"] = dr["isTestStudent"].ToString();
                                Session["Photo"] = dr["Photo"].ToString();
                                Session["Signature"] = dr["Signature"].ToString();
                                Session["IsTestCentreCountry"] = dr["IsTestCentreCountry"].ToString();
                                //if (dr["student_path"]!= null)
                                //{
                                //    if (dr["student_path"].ToString() != "")
                                //    {
                                //        Session["StudentProfilePic"] = dr["student_path"].ToString();
                                //    }
                                //}
                                Session["SCH_UG"] = "No";
                                Session["SCH_PG"] = "No";
                                Session["SCH_PhD"] = "No";



                                string localIP = "?";
                                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                                Session["localIP"] = localIP;
                                flagLogin = true;
                            }
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow _dr in ds.Tables[1].Rows)
                            {
                                if(_dr["AddressType"].ToString()== "Residential")
                                {
                                    Session["Addressline1"] = _dr["Addressline1"].ToString();
                                    Session["Addressline2"] = _dr["Addressline2"].ToString();
                                    Session["State_name"] = _dr["State_name"].ToString();
                                    Session["City_name"] = _dr["City_name"].ToString();
                                    Session["Area"] = _dr["Area"].ToString();
                                    Session["Country_Name"] = _dr["Country_Name"].ToString();
                                }
                            }
                        }
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[3].Rows[0];
                            Session["SCH_UG"] = dr["UG"].ToString();
                            Session["SCH_PG"] = dr["PG"].ToString();
                            Session["SCH_PhD"] = dr["PhD"].ToString();
                        }

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            foreach (DataRow _dr in ds.Tables[4].Rows)
                            {
                                if (_dr["ProgrammeLevel"].ToString() == "UG")
                                {
                                    Session["UG_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                                }
                                else if (_dr["ProgrammeLevel"].ToString() == "PG")
                                {
                                    Session["PG_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                                }
                                else if (_dr["ProgrammeLevel"].ToString() == "PhD")
                                {
                                    Session["PhD_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                                }
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
                flagLogin = flagLogin,
                flagPasswordChanged = flagPasswordChanged,
                flagValidID = flagValidID,
                RegistrationPhase = RegistrationPhase
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}