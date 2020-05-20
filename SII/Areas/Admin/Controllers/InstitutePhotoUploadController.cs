using SIIModel.Admin;
using SIIModel.Institute;
using SIIRepository.Adminservice;
using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class InstitutePhotoUploadController : Controller
    {
        // GET: Admin/InstitutePhotoUpload
        public ActionResult Index()
        {
            SelectDropdown();
            return View();
        }

        public void SelectDropdown()
        {
            Dashboard obj = new Dashboard();
            DashboardRepository _objNationality = new DashboardRepository();
            DataSet ds = _objNationality.sp_Select_All_Institutes(obj);
            List<Dashboard> _Descipline = new List<Dashboard>();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Dashboard _objDescipline = new Dashboard();
                        _objDescipline.InstituteID = (row["InstituteID"].ToString());
                        _objDescipline.InstituteName = row["InstituteName"].ToString();
                        _Descipline.Add(_objDescipline);
                    }
                }
            }

            
            ViewBag.Institute = _Descipline;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Institute_Photo_Gallery(mInstituteGallery _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
          //  _obj.InstituteID = Session["InstituteID"].ToString();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Institute/" + _obj.InstituteID + "/Gallery/Photo/";
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
                    filename = _obj.InstituteID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/Institute/" + _obj.InstituteID + "/Gallery/Photo/"), filename);
                    file.SaveAs(fname);
                    _obj.ImagePath = "Uploads/Institute/" + _obj.InstituteID  + "/Gallery/Photo/" + filename;
                }
                else
                {
                    _obj.ImagePath = "";
                }
            }
            else
            {
                _obj.ImagePath = "";
            }
            bool flag = false;
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
            // using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                DataSet _ds = _objRepository.Save_Institute_Photo_Gallery(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "1")
                        {
                            flag = true;
                        }
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