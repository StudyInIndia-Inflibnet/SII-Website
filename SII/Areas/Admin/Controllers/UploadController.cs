using SIIModel.Admin;
using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Admin/Upload

        [SessionExpireAdmin]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpireAdmin]
        public ActionResult Documents(string s = "", string a = "")
        {
            ViewBag.studentid = s;
            TempData["studentid"] = s;
            TempData["ApplicationNo"] = a;
            ViewBag.ApplicationNo = a;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SearchStudent(string SearchString = "", string Captchastr = "")
        {
            bool flagCaptcha = false;
            bool flag = false;
            List<ProfileManagement> _list = new List<ProfileManagement>();
            if (this.Session["CaptchaImageText"].ToString() == Captchastr)
            {
                flagCaptcha = true;
                string IP = "?";
                IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                SIIRepository.Adminservice.DashboardRepository _objRepo = new SIIRepository.Adminservice.DashboardRepository();
                DataSet _ds = _objRepo.Search_Student_Data(SearchString, IP, "Upload");

                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        flagCaptcha = true;
                        flag = true;
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new ProfileManagement
                            {
                                srno = _dr["srno"].ToString(),
                                StudentID = _dr["StudentID"].ToString(),
                                StudentName = _dr["StudentName"].ToString(),
                                Email = _dr["Email"].ToString(),
                                Mobile = _dr["Mobile"].ToString(),
                                Country = _dr["Country"].ToString(),
                                Nationality = _dr["Nationality"].ToString(),
                                Gender = _dr["Gender"].ToString(),
                                DateOfBirth = _dr["DateOfBirth"].ToString(),
                                Registerdate = _dr["Registerdate"].ToString(),
                                ApplicationNo = _dr["ApplicationNo"].ToString()
                            });
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            var jsonResult = Json(new
            {
                flagCaptcha = flagCaptcha,
                flag = flag,
                List = _list
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        #region UploadDocs
        [SessionExpireAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadDocs(string id = "", string name = "")
        {
            mStudent_Ch_Doc_Upload _obj = new mStudent_Ch_Doc_Upload();
            TempData.Keep("studentid");
            TempData.Keep("ApplicationNo");
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                string path = "";
                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + TempData.Peek("studentid").ToString() + "/" + TempData.Peek("ApplicationNo").ToString() + "/";
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        name = name.Trim().Replace(" / ", "_");
                        name = name.Trim().Replace(" ", "_");
                        filename = name + "_" + TempData.Peek("ApplicationNo").ToString() + Path.GetExtension(file.FileName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {
                            string[] curentfiles = Directory.GetFiles(path);
                            foreach (string curentfile in curentfiles)
                            {
                                if (curentfile.IndexOf(filename) >= 0)
                                    System.IO.File.Delete(curentfile);
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + TempData.Peek("studentid").ToString() + "/" + TempData.Peek("ApplicationNo").ToString() + "/"), filename);
                        file.SaveAs(fname);
                        _obj.Path = "Uploads/studentDocument/" + TempData.Peek("studentid").ToString() + "/" + TempData.Peek("ApplicationNo").ToString() + "/" + filename;
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
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
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
                m = Message,
                c = Code,
                p = _obj.Path,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [SessionExpireAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveUploadDocs(string Docs = "")
        {
            TempData.Keep("studentid");
            TempData.Keep("ApplicationNo");
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_Doc_Upload(TempData.Peek("ApplicationNo").ToString(), TempData.Peek("studentid").ToString(), Docs, localIP);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Documents have been uploaded!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
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
        #endregion
    }
}