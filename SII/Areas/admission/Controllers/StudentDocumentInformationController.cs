using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.IO;
using System.Data;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class StudentDocumentInformationController : Controller
    {
        // GET: admission/StudentDocumentInformation
        public ActionResult Index()
        {
            ViewBag.Filesize = System.Configuration.ConfigurationManager.AppSettings["FileSizeinMB"];

            //return View();
            return RedirectToAction("Index", "Dashboard", new { Area = "admission" });
        }

        #region  document infomation
        public JsonResult Savestudentdocument(student_document _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            _obj.created_by = Session["studentid"].ToString();
            _obj.studentid = Session["studentid"].ToString();
            // _obj.CREATED_IP = Session["localIP"].ToString();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + Session["studentid"].ToString();
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
                    filename = _obj.document_name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + Session["studentid"].ToString()), filename);
                    file.SaveAs(fname);
                    _obj.document_path = "/Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + filename;
                }
                else
                {
                    _obj.document_path = "";
                }
            }
            else
            {
                _obj.document_path = "";
            }
            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.insert_studentdocument(_obj);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Select_studentdocument()
        {

            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.select_studentdocument(Session["studentid"].ToString());
            List<student_document> _list = new List<student_document>();
            string student_path = "";
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        student_document objdoc = new student_document();

                        objdoc.document_id = row["document_id"].ToString();
                        objdoc.document_name = row["document_name"].ToString();
                        objdoc.document_path = row["document_path"].ToString();
                        objdoc.studentid = row["studentid"].ToString();
                        _list.Add(objdoc);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        //student_document objdoc = new student_document();
                        student_path = row["student_path"].ToString();
                        Session["StudentProfilePic"] = row["student_path"].ToString();
                        //_list.Add(objdoc);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                student_path = student_path
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult uploadstudentimage()
        {
            string path = "";
            string filename = "";
            string fname = "";
            Student_Register _obj = new Student_Register();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    //Upload the file... 
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentPhoto/";
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
                    filename = Session["studentid"].ToString() + "_Photo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/studentPhoto/"), filename);
                    file.SaveAs(fname);
                    _obj.student_path = "/Uploads/studentPhoto/" + filename;
                }
                else
                {
                    _obj.student_path = _obj.student_path;
                }
            }
            else
            {
                _obj.student_path = _obj.student_path;
            }
            _obj.studentid = Session["studentid"].ToString();
            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.update_image_path(_obj);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["COUNTS"].ToString() != "0")
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

        public JsonResult Delete_studentdocument(string document_id = "0")
        {

            StudentRepository objRepository = new StudentRepository();
            DataSet ds = objRepository.delete_studentdocument(document_id);
            bool flag = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion
    }
}