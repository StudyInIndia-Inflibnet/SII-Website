using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class ChangePasswordController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/ChangePassword
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Check_And_ChangePassword(InstituteMaster _obj)
        {
            bool flagCheckPassword = false;
            bool flagCaptcha = false;
            bool flagPwdChanged = false;
            if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
            {
                flagCaptcha = true;
                _obj.InstituteID = Session["InstituteID"].ToString();
                InstituteRepository _objRepository = new InstituteRepository();
                DataSet ds = _objRepository.Login_Institute(_obj);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        string actualPassword = dr["Password"].ToString();
                        string random = "";
                        if (dr["DefaultPassword"] != null)
                        {
                            random = dr["DefaultPassword"].ToString();
                        }
                        if (dr["IsPasswordChanged"].ToString().ToLower() == "true")
                        {
                            string password = _obj.DefaultPassword;
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
                                if (random == _obj.DefaultPassword)
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
                            string new_password = _obj.Password;
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
                            _obj.Password = hashPassword.ToString();
                            DataSet _dsChngPwd = _objRepository.Institute_password_change(_obj);
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