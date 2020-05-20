using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    public class LoginController : Controller
    {
        // GET: GovernmentSchemeAdmission/Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckLogin(Agencymaster _obj)
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
                    AgencyRepository _objRepository = new AgencyRepository();
                    DataSet ds = _objRepository.select_tbl_Agency_master_login(_obj);
                    if (ds != null)
                    {
                        Session["IsChangePwd"] = null;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            flagValidID = true;
                            DataRow dr = ds.Tables[0].Rows[0];
                            string Password = dr["change_password"].ToString();
                            string random = "";
                            if (dr["password"] != null)
                            {
                                random = dr["password"].ToString();
                            }
                            if (dr["is_change_pass"].ToString().ToLower() == "true")
                            {
                                //nvNHsQGCNC3Ph/TQRX3dbd4BnGKtXFV/Ow==
                                string PASSWORD = _obj.password;
                                string MD5 = Helper.VerifyHash(PASSWORD, "MD5", Password).ToString();
                                string SHA1 = Helper.VerifyHash(PASSWORD, "SHA1", Password).ToString();
                                string sha256 = Helper.VerifyHash(PASSWORD, "SHA256", Password).ToString();
                                string sha384 = Helper.VerifyHash(PASSWORD, "SHA384", Password).ToString();
                                string sha512 = Helper.VerifyHash(PASSWORD, "SHA512", Password).ToString();
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
                                    if (random == _obj.password)
                                    {
                                        flagLogin = true;
                                        flagPasswordChanged = false;
                                        TempData["agent_old_password"] = random;
                                    }
                                }
                            }
                            if (flagLogin)
                            {
                                Session["Gov_User_id"] = dr["agencyid"];
                                Session["Gov_User_Name"] = dr["email"];
                                Session["agency_uniq_id"] = dr["agency_uniq_id"];
                                Session["Gov_Name"] = dr["nameofagency"].ToString();
                                flagLogin = true;
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






            //bool flagLogin = false;
            //bool flagCaptcha = false;
            //bool flagValidID = false;
            //UserRepository _objRepository = new UserRepository();
            //DataSet ds = _objRepository.Login_Usermaster(_obj);
            //try
            //{
            //    if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
            //    {
            //        flagCaptcha = true;
            //        if (ds != null)
            //        {
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                flagValidID = true;
            //                DataRow dr = ds.Tables[0].Rows[0];
            //                if (dr["Password"].ToString() == _obj.Password)
            //                {
            //                    string localIPadmin = "?";
            //                    localIPadmin = Request.ServerVariables["REMOTE_ADDR"].ToString();
            //                    Session["localIPADmin"] = localIPadmin;
            //                    Session["Gov_User_id"] = dr["User_id"];
            //                    Session["Gov_User_Name"] = dr["User_Name"];
            //                    Session["Gov_Name"] = dr["Name"].ToString();
            //                    Session["Gov_is_admin"] = dr["is_admin"].ToString();
            //                    flagLogin = true;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        flagCaptcha = false;
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //return Json(new
            //{
            //    flagLogin = flagLogin,
            //    flagValidID = flagValidID,
            //    flagCaptcha = flagCaptcha,
            //},
            //    JsonRequestBehavior.AllowGet
            //);
        }
    }
}