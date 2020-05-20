using SIIModel.Faculty;
using SIIModel.Master;
using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class FacultyAlumniController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/FacultyAlumni
        public ActionResult Index()
        {
            selectDropdown();
            TempData["ActiveMainTabInstitute"] = "FacultyAlumni";
            return View();
        }
        #region
        public void selectDropdown()
        {
            InstituteFacultyAlumniRepository _objRepository = new InstituteFacultyAlumniRepository();
            DataSet ds = _objRepository.select_load_faculty();
            List<Qualification> _Qualification = new List<Qualification>();
            List<Designation> _Designation = new List<Designation>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Qualification _objpro = new Qualification();
                        _objpro.QualificationId = (row["QualificationId"].ToString());
                        _objpro.Qualification_Name = row["Qualification_Name"].ToString();
                        _Qualification.Add(_objpro);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Designation _obj = new Designation();
                        _obj.id = (row["id"].ToString());
                        _obj.Designation_name = row["Designation_name"].ToString();
                        // _obj.country_code = row["country_code"].ToString();
                        _Designation.Add(_obj);
                    }
                }
            }
            ViewBag.Qualification = _Qualification;
            ViewBag.Designation = _Designation;
        }
        #endregion

        #region Faculty
        public JsonResult Select_Institute_Faculty(string ID = "", string flag_faculty = "")
        {
            List<mInstituteFaculty> _list = new List<mInstituteFaculty>();
            InstituteFacultyAlumniRepository _objRepository = new InstituteFacultyAlumniRepository();
            string InstituteID = Session["InstituteID"].ToString();
            // using (IInstituteFacultyAlumni _objRepository = new RInstituteFacultyAlumni())
            {
                DataSet ds = _objRepository.Select_Institute_Faculty(ID, flag_faculty, InstituteID);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            mInstituteFaculty _objList = new mInstituteFaculty();
                            _objList.ID = row["ID"].ToString();
                            _objList.InstituteID = row["InstituteID"].ToString();
                            _objList.FacultyName = row["FacultyName"].ToString();
                            _objList.Designation = row["Designation"].ToString();
                            _objList.Designation_name = row["Designation_name"].ToString();
                            _objList.Qualification = row["Qualification"].ToString();
                            _objList.Qualification_Name = row["Qualification_Name"].ToString();
                            _objList.Photo = row["Photo"].ToString();
                            _objList.IsRegular = row["IsRegular"].ToString();
                            _objList.AreaofExcellence = row["AreaofExcellence"].ToString();
                            _objList.CurrentEmployer = row["CurrentEmployer"].ToString();
                            _objList.AlumniDesignation = row["AlumniDesignation"].ToString();
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
        public JsonResult Save_Institute_Faculty(mInstituteFaculty _obj)
        {
            string path = "";
            string filename = "";
            string fname = "";
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.Edited_by = Session["User_id"].ToString();
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    string flagtype = "";
                    if (_obj.flag_faculty == "1")
                    {
                        flagtype = "Faculty";
                    }
                    else
                    {
                        flagtype = "Alumni";
                    }
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Institute/" + _obj.InstituteID + "/" + flagtype + "/";
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
                    filename = _obj.FacultyName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/Institute/" + _obj.InstituteID + "/" + flagtype + "/"), filename);
                    file.SaveAs(fname);
                    _obj.Photo = "Uploads/Institute/" + _obj.InstituteID + "/" + flagtype + "/" + filename;
                }
                else
                {
                    _obj.Photo = "";
                }
            }
            else
            {
                _obj.Photo = "";
            }
            bool flag = false;
            bool flagExists = false;
            bool flaglimit = false;
            InstituteFacultyAlumniRepository _objRepository = new InstituteFacultyAlumniRepository();
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.CreatedIP = localIP;

            DataSet _ds = _objRepository.Save_Institute_Faculty(_obj);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "1")
                    {
                        flag = true;
                    }
                    else if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "-1")
                    {
                        flagExists = true;
                    }
                    else if(_ds.Tables[0].Rows[0]["FLAG"].ToString() == "-2")
                    {
                        flaglimit = true;
                    }
                }
            }
            return Json(new
            {
                flag = flag,
                flagExists = flagExists,
                flaglimit= flaglimit
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Delete_Institute_Faculty(string ID = "")
        {
            bool flag = false;
            InstituteFacultyAlumniRepository _objRepository = new InstituteFacultyAlumniRepository();
            DataSet _ds = _objRepository.Delete_Institute_Faculty(ID);
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