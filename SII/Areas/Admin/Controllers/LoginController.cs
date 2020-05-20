using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckLogin(Usermaster _obj)
        {
            bool flagLogin = false;
            bool flagCaptcha = false;
            bool flagValidID = false;
            UserRepository _objRepository = new UserRepository();
            DataSet ds = _objRepository.Login_Usermaster(_obj);
            try
            {
                if (this.Session["CaptchaImageText"].ToString() == _obj.Captchastr)
                {
                    flagCaptcha = true;
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            flagValidID = true;
                            DataRow dr = ds.Tables[0].Rows[0];
                            if (dr["Password"].ToString() == _obj.Password)
                            {
                                string localIPadmin = "?";
                                localIPadmin = Request.ServerVariables["REMOTE_ADDR"].ToString();
                                Session["localIPADmin"] = localIPadmin;
                                Session["is_callCentre"] = dr["is_callCentre"].ToString();
                                Session["User_id"] = dr["User_id"];
                                Session["User_Name"] = dr["User_Name"];
                                Session["Name"] = dr["Name"].ToString();
                                Session["is_admin"] = dr["is_admin"].ToString();
                                Session["AdminRole"] = dr["AdminRole"].ToString();
                                Session["is_doc_verification"] = dr["is_doc_verification"].ToString();
                                string localIP = "?";
                                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                                Session["localIP"] = localIP;
                                flagLogin = true;
                            }
                        }
                    }
                }
                else
                {
                    flagCaptcha = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new
            {
                flagLogin = flagLogin,
                flagValidID= flagValidID,
                flagCaptcha = flagCaptcha
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}