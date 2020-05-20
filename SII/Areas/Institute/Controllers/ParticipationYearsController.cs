using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    //[NoDirectAccess]
    public class ParticipationYearsController : Controller
    {
        // GET: Institute/ParticipationYears
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
#pragma warning disable SCS0016 // Controller method is vulnerable to CSRF
        public JsonResult ParticipateInCurrentYear()
#pragma warning restore SCS0016 // Controller method is vulnerable to CSRF
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                Session["localIP"] = "";
                InstituteRepository _objRepository = new InstituteRepository();
                DataSet _ds = _objRepository.SP_PARTICIPATE_INSTITUTE(Session["InstituteID"].ToString(), Session["localIP"].ToString(), ConfigurationManager.AppSettings["ParticipatedYear"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
                        Message = "Successfully participated in " + ConfigurationManager.AppSettings["ParticipatedYear"].ToString() + "!";
                        Code = "success";
                    }
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
                c = Code,
                m = Message,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}