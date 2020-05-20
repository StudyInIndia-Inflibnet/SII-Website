using SIIModel.Institute;
using SIIModel.Master;
using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class GalleryController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Gallery
        public ActionResult Index()
        {
            selectDropdown();
            TempData["ActiveMainTabInstitute"] = "Gallery";
            return View();
        }
        public void selectDropdown()
        {
            InstituteGalleryRepository _objrepository = new InstituteGalleryRepository();
            DataSet ds = _objrepository.select_GallaryCategory_Master();
            List<GallaryCategory> _GallaryCategory = new List<GallaryCategory>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        GallaryCategory _objpro = new GallaryCategory();
                        _objpro.GallaryCategory_id = (row["GallaryCategory_id"].ToString());
                        _objpro.GallaryCategory_Name = row["GallaryCategory_Name"].ToString();
                        _GallaryCategory.Add(_objpro);
                    }
                }
            }
            ViewBag.GallaryCategory = _GallaryCategory;
        }
        #region Photo Gallery
        public JsonResult Select_Institute_Photo_Gallery(string ID = "")
        {
            List<mInstituteGallery> _list = new List<mInstituteGallery>();
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
           // using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                DataSet ds = _objRepository.Select_Institute_Photo_Gallery(ID, Session["InstituteID"].ToString());
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            mInstituteGallery _objList = new mInstituteGallery();
                            _objList.ID = row["ID"].ToString();
                            _objList.InstituteID = row["InstituteID"].ToString();
                            _objList.ImagePath = row["ImagePath"].ToString();
                            _objList.Description = row["Description"].ToString();
                            _objList.CategoryID = row["CategoryID"].ToString();
                            _objList.CategoryName = row["GallaryCategory_Name"].ToString();
                            _list.Add(_objList);
                        }
                    }
                }
            }

            return Json(new
            {
                List = _list
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Institute_Photo_Gallery(mInstituteGallery _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Institute/" + Session["InstituteID"].ToString() + "/Gallery/Photo/";
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
                    filename = Session["InstituteID"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/Institute/" + Session["InstituteID"].ToString() + "/Gallery/Photo/"), filename);
                    file.SaveAs(fname);
                    _obj.ImagePath = "Uploads/Institute/" + Session["InstituteID"].ToString() + "/Gallery/Photo/" + filename;
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
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
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
        public JsonResult Delete_Institute_Photo_Gallery(string ID = "")
        {
            bool flag = false;
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
            //using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                DataSet _ds = _objRepository.Delete_Institute_Photo_Gallery(ID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
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
        #endregion

        #region Video Gallery
        public JsonResult Select_Institute_Video_Gallery(string ID = "")
        {
            List<mInstituteGallery> _list = new List<mInstituteGallery>();
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
            // using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                DataSet ds = _objRepository.Select_Institute_Video_Gallery(ID,Session["InstituteID"].ToString());
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            mInstituteGallery _objList = new mInstituteGallery();
                            _objList.ID = row["ID"].ToString();
                            _objList.InstituteID = row["InstituteID"].ToString();
                            _objList.VideoURL = row["VideoURL"].ToString();
                            _objList.Description = row["Description"].ToString();
                            _objList.CategoryID = row["CategoryID"].ToString();
                            _objList.CategoryName = row["GallaryCategory_Name"].ToString();
                            _list.Add(_objList);
                        }
                    }
                }
            }

            return Json(new
            {
                List = _list
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Institute_Video_Gallery(mInstituteGallery _obj)
        {
            bool flag = false;
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
            // using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.Save_Institute_Video_Gallery(_obj);
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
        public JsonResult Delete_Institute_Video_Gallery(string ID = "")
        {
            bool flag = false;
            InstituteGalleryRepository _objRepository = new InstituteGalleryRepository();
            // using (IInstituteGallery _objRepository = new RInstituteGallery())
            {
                DataSet _ds = _objRepository.Delete_Institute_Video_Gallery(ID);
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
        #endregion
    }
}