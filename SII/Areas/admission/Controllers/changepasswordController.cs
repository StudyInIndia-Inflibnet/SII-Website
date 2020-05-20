using SII.Filters;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpire]
    public class changepasswordController : Controller
    {
        // GET: admission/changepassword
        [RecaptchaFilter]
        public ActionResult Index()
        {
            TempData.Keep("old_password");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //   [RecaptchaFilter], bool CaptchaValid
        public JsonResult Check_And_ChangePassword(Student_Register _obj)
        {
            bool flagCheckPassword = false;
            bool flagCaptcha = false;
            bool flagPwdChanged = false;
            if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
            //if (CaptchaValid)
            {
                flagCaptcha = true;
                _obj.studentid = Session["studentid"].ToString();
                StudentRepository _objRepository = new StudentRepository();
                DataSet ds = _objRepository.Login_Student(_obj);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        string actualPassword = dr["ActualPassword"].ToString();
                        string random = "";
                        if (dr["Random"] != null)
                        {
                            random = dr["Random"].ToString();
                        }
                        if (dr["IsPasswordChanged"].ToString().ToLower() == "true" && dr["ischangedpassword"].ToString().ToLower() == "true")
                        {
                            string password = _obj.Random;
                            string MD5 = Helper.VerifyHash(password, "MD5", actualPassword).ToString();
                            string SHA1 = Helper.VerifyHash(password, "SHA1", actualPassword).ToString();
                            string sha256 = Helper.VerifyHash(password, "SHA256", actualPassword).ToString();
                            string sha384 = Helper.VerifyHash(password, "SHA384", actualPassword).ToString();
                            string sha512 = Helper.VerifyHash(password, "SHA512", actualPassword).ToString();

                            if (MD5 == "True" || SHA1 == "True" || sha256 == "True" || sha384 == "True" || sha512 == "True")
                            {
                                flagCheckPassword = true;

                            }
                        }
                        else
                        {
                            if (random != "")
                            {
                                if (random == _obj.Random)
                                {
                                    flagCheckPassword = true;
                                }
                            }
                        }
                        if (flagCheckPassword)
                        {
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
                            DataSet _dsChngPwd = _objRepository.student_password_change(_obj);
                            if (_dsChngPwd != null)
                            {
                                if (_dsChngPwd.Tables[0].Rows.Count > 0)
                                {
                                    flagPwdChanged = true;
                                    Session["IsPasswordChanged"] = "true";
                                }
                            }
                        }
                    }
                }
            }
            return Json(new
            {
                flagCaptcha = flagCaptcha,
                flagPwdChanged = flagPwdChanged
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}