using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class changepasswordController : Controller
    {
        // GET: GovernmentSchemeAdmission/changepassword
        public ActionResult Index()
        {
            TempData.Keep("agent_old_password");
            return View();
        }
        [HttpPost]
        // [RecaptchaFilter]
        [ValidateAntiForgeryToken]
        public JsonResult Agent_Check_And_ChangePassword(Agencymaster _obj)
        {
            bool flagCheckPassword = false;
            bool flagCaptcha = false;
            bool flagPwdChanged = false;
            if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
            //if (CaptchaValid)
            {
                flagCaptcha = true;
                _obj.agency_uniq_id = Session["agency_uniq_id"].ToString();
                AgencyRepository _objRepository = new AgencyRepository();
                DataSet ds = _objRepository.select_tbl_Agency_master_login(_obj);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        string actualPassword = dr["change_password"].ToString();
                        string random = "";
                        if (dr["password"] != null)
                        {
                            random = dr["password"].ToString();
                        }
                        if (dr["is_change_pass"].ToString().ToLower() == "true")
                        {
                            string password = _obj.password;
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
                                if (random == _obj.password)
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
                            string new_password = _obj.change_password;
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
                            _obj.change_password = hashPassword.ToString();
                            DataSet _dsChngPwd = _objRepository.agency_password_change(_obj);
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