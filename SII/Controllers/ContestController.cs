using SII.Filters;
using SIIModel.Master;
using SIIModel.Admin;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Controllers
{
    public class ContestController : Controller
    {
        // GET: Contest
        public ActionResult Index()
        {
            //selectDropdown();
            //return View();
            return Redirect(System.Configuration.ConfigurationManager.AppSettings["SIIContestLink"]);
        }
        public ActionResult Submit()
        {
            //return View();
            return Redirect(System.Configuration.ConfigurationManager.AppSettings["SIIContestLink"]);
        }
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<ProgramLevels> _ProgramLevels = new List<ProgramLevels>();
            List<Country> _Country = new List<Country>();
            List<mCourseOfStudy> _Course = new List<mCourseOfStudy>();
            if (ds != null)
            {
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Country.Add(_objcountry);
                    }
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[5].Rows)
                    {
                        ProgramLevels _objpro = new ProgramLevels();
                        _objpro.ProgramLevel_Id = (row["ProgramLevel_Id"].ToString());
                        _objpro.ProgramLevel = row["ProgramLevel"].ToString();
                        _ProgramLevels.Add(_objpro);
                    }
                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[6].Rows)
                    {
                        mCourseOfStudy _objpro = new mCourseOfStudy();
                        _objpro.CourseOfStudy_ID = (row["CourseOfStudy_ID"].ToString());
                        _objpro.CourseOfStudy = row["CourseOfStudy"].ToString();
                        _Course.Add(_objpro);
                    }
                    _Course.Add(new mCourseOfStudy { CourseOfStudy_ID = "0", CourseOfStudy = "Other" });
                }
            }
            ViewBag.ProgramLevels = _ProgramLevels;
            ViewBag.Country = _Country;
            ViewBag.Course = _Course;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CheckDtl(mContest _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                RContest _objRepository = new RContest();
                _obj.CreatedIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                DataSet _ds = _objRepository.SELECT_tbl_contest_details(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "0")
                    {
                        Code = "success";
                        Message = "Basic Details have been saved succefully.";
                    }
                    else
                    {
                        Code = "alreadyexists";
                        Message = "You have already submitted your entry.";
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
        public JsonResult UploadDocs(string id = "", string name = "", string Mobile = "")
        {
            mContest _obj = new mContest();
            string Message = string.Empty, Code = string.Empty;
            try
            {
                string path = "";
                string filename = "";
                string fname = "";
                string fileType = "";
                string[] fileExtension = null;
                int MaxContentLength;
                string MaxContentLengthMsg = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        if (id == "TestimonialVideo" )
                        {
                           fileExtension = new[] { ".avi", ".mpeg4", ".mov", ".wmv", ".mp4", ".3gpp" };
                            MaxContentLength = 1073741824; MaxContentLengthMsg = "1 GB";
                        }
                        else
                        {
                           fileExtension = new[] { ".pdf", ".jpeg", ".jpg" };
                            MaxContentLength = 26214400; MaxContentLengthMsg = "25 MB";
                        }
                        HttpFileCollectionBase files = Request.Files;
                        path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Contest/" + Mobile + "/";
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        var checkextension = Path.GetExtension(file.FileName).ToLower();
                        if (fileExtension.Contains(checkextension))
                        {
                            if (MaxContentLength>=file.ContentLength)
                            {
                                filename = Mobile + "_" + id + Path.GetExtension(file.FileName);
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                else
                                {
                                    string[] curentfiles = Directory.GetFiles(path);
                                    foreach (string curentfile in curentfiles)
                                    {
                                        if (curentfile.IndexOf(filename) >= 0) {
                                            //System.IO.File.Delete(curentfile);
                                        }
                                    }
                                }

                                fname = Path.Combine(Server.MapPath("~/Uploads/Contest/" + Mobile + "/"), filename);
                                file.SaveAs(fname);
                                _obj.Path = "Uploads/Contest/" + Mobile + "/" + filename;
                            }
                            else
                            {
                                _obj.Path = "";
                                fileType = "INVALIDSIZE";
                            }
                        }
                        else
                        {
                            _obj.Path = "";
                            fileType = "INVALIDEX";
                        }
                    }
                    else
                    {
                        _obj.Path = "";
                    }
                }
                else
                {
                    _obj.Path = "";
                }
                if (_obj.Path != "")
                {
                    Message = "Document uploaded successfully!";
                    Code = "success";
                }
                else if (_obj.Path == "" && fileType == "INVALIDEX")
                {
                    Code = "fileExtension";
                    Message = "Only formats are allowed :" + String.Join(",", fileExtension);
                }
                else if (_obj.Path == "" && fileType == "INVALIDSIZE")
                {
                    Code = "fileExtension";
                    Message = "Maximum allowed file size : " + MaxContentLengthMsg.ToString();
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }

            return Json(new
            {
                m = Message,
                c = Code,
                p = _obj.Path
            },
                JsonRequestBehavior.AllowGet
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveUploadDocs(mContest _obj, string Docs = "")
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    RContest _objRepository = new RContest();
                    _obj.CreatedIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    DataSet _ds = _objRepository.INSERT_UPDATE_tbl_contest_Doc_Upload(_obj, Docs);
                    if (_ds != null)
                    {
                        if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "1")
                        {
                            Message = "Documents have been uploaded!";
                            Code = "success";
                        }
                        else if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "2")
                        {
                            Message = "You have already submitted your entry.";
                            Code = "alreadyexists";
                        }
                        else
                        {
                            Message = "Error from server side. Kindly refresh the page and try again.";
                            Code = "servererror";
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }


}