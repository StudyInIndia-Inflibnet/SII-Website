using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using SIIModel.Courses;
using SIIRepository.Courses;

namespace SII.Areas.Institute.Controllers
{
    public class FeeBreakupController : Controller
    {
        // GET: Institute/FeeBreakup
        [SessionExpireInstitute]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UplaodPdf(Mpdf _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Fee_breakup/" + Session["InstituteID"].ToString();
                    filename = Path.GetFileName(Request.Files[0].FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        string[] curentfiles = Directory.GetFiles(path);

                    }
                    HttpPostedFileBase file = files[0];
                    filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/Fee_breakup/" + Session["InstituteID"].ToString()), filename);
                    file.SaveAs(fname);
                    _obj.pdfpath = "Uploads/Fee_breakup/" + Session["InstituteID"].ToString() + "/" + filename;
                }
                else
                {
                    _obj.pdfpath = "";
                }
            }
            else
            {
                _obj.pdfpath = "";
            }
            bool flag = false;
            Rpdf _objRepository = new Rpdf();
            {
                _obj.created_ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.InstituteID = Session["InstituteID"].ToString();
                DataSet ds = _objRepository.UPLOAD_PDF(_obj);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flag = true;
                    }
                }
            }

            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeletePdf(string id = "0")
        {
            bool flag = false;
            Rpdf _objRepository = new Rpdf();
            {
                DataSet ds = _objRepository.DELETE_PDF(id);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flag = true;
                    }
                }
            }

            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }

    }
}