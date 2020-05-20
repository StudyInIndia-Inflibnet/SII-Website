using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    public class LoginController : Controller
    {
        // GET: Institute/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CheckLogin(InstituteMaster _obj)
        {
            bool flagCaptcha = false;
            bool flagLogin = false;
            bool flagPasswordChanged = true;
            bool flagValidID = false;
            try
            {
                if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                {
                    flagCaptcha = true;
                    InstituteRepository _objRepository = new InstituteRepository();
                    DataSet ds = _objRepository.Login_Institute(_obj);
                    if (ds != null)
                    {
                        Session["IsChangePwd"] = null;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            flagValidID = true;
                            DataRow dr = ds.Tables[0].Rows[0];
                            string Password = dr["Password"].ToString();
                            string random = "";
                            if (dr["DefaultPassword"] != null)
                            {
                                random = dr["DefaultPassword"].ToString();
                            }
                            if (dr["IsPasswordChanged"].ToString().ToLower() == "true")
                            {
                                //nvNHsQGCNC3Ph/TQRX3dbd4BnGKtXFV/Ow==
                                string PASSWORD = _obj.Password;
                                string MD5 = Helper.VerifyHash(PASSWORD, "MD5", Password).ToString();
                                string SHA1 = Helper.VerifyHash(PASSWORD, "SHA1", Password).ToString();
                                string sha256 = Helper.VerifyHash(PASSWORD, "SHA256", Password).ToString();
                                string sha384 = Helper.VerifyHash(PASSWORD, "SHA384", Password).ToString();
                                string sha512 = Helper.VerifyHash(PASSWORD, "SHA512", Password).ToString();
                                if (MD5 != "True" || SHA1 == "True" || sha256 == "True" || sha384 == "True" || sha512 == "True")
                                {
                                    TempData["old_password"] = PASSWORD;
                                    flagLogin = true;
                                }
                            }
                            else
                            {
                                if (random != "")
                                {
                                    if (random == _obj.Password)
                                    {
                                        flagLogin = true;
                                        flagPasswordChanged = false;
                                        TempData["old_password"] = random;
                                    }
                                }
                            }
                            if (flagLogin)
                            {
                                Session["InstituteID"] = dr["InstituteID"].ToString();
                                Session["InstituteName"] = dr["InstituteName"].ToString();
                                Session["Email"] = dr["Email"].ToString();
                                string localIP = "?";
                                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                                Session["localIP"] = localIP;
                                Session["User_id"] = "0";
                                Session["IsAdminFLag"] = dr["IsAdminFLag"].ToString();
                                Session["IsAdminEdit"] = dr["IsAdminEdit"].ToString();
                                Session["IsNicheAllowed"] = dr["IsNicheAllowed"].ToString();
                                Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
                                flagLogin = true;
                            }
                        }
                        if (flagLogin)
                        {
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow _dr in ds.Tables[1].Rows)
                                {
                                    Session["AR_StartDate"] = _dr["MinDate"].ToString();
                                    Session["AR_EndDate"] = _dr["MaxDate"].ToString();
                                }
                            }
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow _dr in ds.Tables[2].Rows)
                                {
                                    Session["ParticipatedYear"] = _dr["ParticipatedYear"].ToString();
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
                flagValidID = flagValidID
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}