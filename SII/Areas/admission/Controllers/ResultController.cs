using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class ResultController : Controller
    {
        // GET: admission/Result
        [SessionExpireStudent]
        public ActionResult Index()
        {
            if (Session["AllowChoiceFilling"].ToString().ToLower() != "true")
            {
                return View();
            }
            else
            {
                return Redirect("/admission/Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ARAction(string InstituteID = "", string CourseID = "", string Remarks = "")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                MockResultRepository _objRepo = new MockResultRepository();
                DataSet _ds = _objRepo.ACCEPT_PHASE2_BY_STUDENTS(InstituteID, Session["studentid"].ToString(), CourseID, Remarks);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Seat accepted successfully!";
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RAAction(string InstituteID = "", string CourseID = "", string Remarks = "")
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                MockResultRepository _objRepo = new MockResultRepository();
                DataSet _ds = _objRepo.REJECT_PHASE2_BY_STUDENTS(InstituteID, Session["studentid"].ToString(), CourseID, Remarks);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Seat rejected successfully!";
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
        public ActionResult Accept()
        {
            return View();
        }

        public ActionResult Reject()
        {
            return View();
        }
    }
}