using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class SCFDatesController : Controller
    {
        // GET: Admin/SCFDates
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public JsonResult SelectData()
        {
            string Code = string.Empty, Message = string.Empty;
            List<mSCFDates> _list = new List<mSCFDates>();
            try
            {
                SCFRepository _objRepo = new SCFRepository();
                DataSet _ds = _objRepo.Opr_ProgrammeLevel_Ch_CloseDT(new mSCFDatesSave { Type = "Select" });
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mSCFDates
                            {
                                ProgrammeLevel = _dr["ProgrammeLevel"].ToString(),
                                ClosingDate = Convert.ToDateTime(_dr["ClosingDate"].ToString()).ToString("yyyy-MM-dd HH-mm-ss"),
                                StartingDateApproveReject = Convert.ToDateTime(_dr["StartingDateApproveReject"].ToString()).ToString("yyyy-MM-dd HH-mm-ss"),
                                ClosingDateApproveReject = Convert.ToDateTime(_dr["ClosingDateApproveReject"].ToString()).ToString("yyyy-MM-dd HH-mm-ss")
                            });
                        }
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
                List = _list,
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SaveData(mSCFDatesSave _obj)
        {
            string Code = string.Empty, Message = string.Empty, Error = string.Empty;
            try
            {
                SCFRepository _objRepo = new SCFRepository();
                _obj.Type = "Update";

                #region Change Config File Data
                Configuration configFile = null;
                if (System.Web.HttpContext.Current != null)
                {
                    configFile = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                }
                else
                {
                    configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
                var settings = configFile.AppSettings.Settings;
                if (settings["StudentChoiceFillingDateTime"] == null)
                {
                    settings.Add("StudentChoiceFillingDateTime", _obj.StudentChoiceFillingDateTime);
                }
                else
                {
                    settings["StudentChoiceFillingDateTime"].Value = _obj.StudentChoiceFillingDateTime;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                #endregion
                DataSet _ds = _objRepo.Opr_ProgrammeLevel_Ch_CloseDT(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Code = "success";
                        Message = "Dates have been updated.";
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
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