using SIIModel.Institute;
using SIIModel.Master;
using SIIRepository.Institute;
using SIIRepository.Masterservice;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.IO;
using System.Web;
using System;
using System.Collections;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class FeesController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Fees
        public ActionResult Index()
        {
            TempData["ActiveMainTabInstitute"] = "Fees";
            SelectDropdown();
            return View();
        }

        #region FillDropdown
        public void SelectDropdown()
        {
            NatureofCostCategory obj = new NatureofCostCategory();
            NatureofCostCategoryRepository _objNationality = new NatureofCostCategoryRepository();
            DataSet ds = _objNationality.select_NatureofCostCategory(obj);
            List<NatureofCostCategory> _NatureofCostCategory = new List<NatureofCostCategory>();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        NatureofCostCategory _objNatureofCostCategory = new NatureofCostCategory();
                        _objNatureofCostCategory.Natureofcostcategory_id = (row["Natureofcostcategory_id"].ToString());
                        _objNatureofCostCategory.Natureofcostcategoryname = row["Natureofcostcategoryname"].ToString();
                        _NatureofCostCategory.Add(_objNatureofCostCategory);
                    }
                }
            }

            ViewBag.NatureofCostCategory = _NatureofCostCategory;
        }
        #endregion

        #region Institute save update
        public JsonResult Select_CostofLiving(CostofLiving obj)
        {
            List<CostofLiving> _list = new List<CostofLiving>();
            obj.InstituteID = Session["InstituteID"].ToString();
            CostofLivingRepository _objRepository = new CostofLivingRepository();
            DataSet ds = _objRepository.select_tbl_CostofLiving(obj);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CostofLiving _objList = new CostofLiving();
                        _objList.ID = row["ID"].ToString();
                        _objList.InstituteID = row["InstituteID"].ToString();
                        _objList.Natureofcostcategory_id = row["Natureofcostcategory_id"].ToString();
                        _objList.ApproximatCost = row["ApproximatCost"].ToString();
                        _objList.ApproximatCostType = row["ApproximatCostType"].ToString();
                        _objList.UploadedFilePath = row["UploadedFilePath"].ToString();
                        _objList.Natureofcostcategoryname = row["Natureofcostcategoryname"].ToString();
                        _list.Add(_objList);
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
#pragma warning disable SCS0016 // Controller method is vulnerable to CSRF
        public JsonResult UploadDoc()
#pragma warning restore SCS0016 // Controller method is vulnerable to CSRF
        {
             
            string Message = string.Empty, Code = string.Empty;
            string Dir = "Download/";
            long MaxContentLength = 512000;
            string MaxContentLengthMsg = "500 KB"; 
            string filepath = "";
            string allowedExtensions = ".pdf";
            try
            {
                try
                { 
                    string path = "";
                    string filename = "";
                    string fname = "";
                    string Error = "";
                    if (Request.Files.Count > 0)
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpFileCollectionBase files = Request.Files;
                            path = AppDomain.CurrentDomain.BaseDirectory + Dir;
                            filename = Path.GetFileName(Request.Files[0].FileName);
                            HttpPostedFileBase file = files[0];
                            
                            if (allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                            {
                                if (MaxContentLength >= file.ContentLength)
                                {
                                    filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
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
                                            {
                                                //System.IO.File.Delete(curentfile);
                                            }
                                        }
                                    }
                                    fname = Path.Combine(Server.MapPath("~/" + Dir), filename);
                                    file.SaveAs(fname);
                                    filepath = "/" + Dir + filename;
                                }
                                else
                                {
                                    filepath = "";
                                    Error = "INVALIDSIZE";
                                }
                            }
                            else
                            {
                                filepath = "";
                                Error = "INVALIDEX";
                            }
                        }
                        else
                        {
                            filepath = "";
                        }
                    }
                    else
                    {
                        filepath = "";
                    }
                    if (filepath != "")
                    {
                        Message = "Document uploaded successfully!";
                        Code = "success";
                    }
                    else if (filepath == "" && Error == "INVALIDEX")
                    {
                        Code = "fileExtension";
                        Message = "Only formats are allowed :" + allowedExtensions;
                    }
                    else if (filepath == "" && Error == "INVALIDSIZE")
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
                string[] _str = new string[3];
                _str[0] = Message;
                _str[1] = Code;
                _str[2] = filepath;

            }
            catch (NullReferenceException )
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception )
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new {
                m = Message,
                c = Code,
                p = filepath
            },
            JsonRequestBehavior.AllowGet
        );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_CostofLiving(CostofLiving _obj)
        {
            bool flag = false;
            try
            {
                 
                CostofLivingRepository _objRepository = new CostofLivingRepository();
                _obj.InstituteID = Session["InstituteID"].ToString();
                //_obj.UploadedFilePath = Session["UploadedFilePath"].ToString();
                _obj.CreatedBy = Session["InstituteID"].ToString();
                _obj.CreatedIP = Session["localIP"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.insertupdate_CostofLiving(_obj);
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
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                throw;
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }

        public JsonResult Delete_CostofLiving(CostofLiving _obj)
        {
            CostofLivingRepository objRep = new CostofLivingRepository();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.Type = "Delete";
            DataSet _ds = objRep.delete_tbl_CostofLiving(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "0")
                    {
                        flag = false;
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