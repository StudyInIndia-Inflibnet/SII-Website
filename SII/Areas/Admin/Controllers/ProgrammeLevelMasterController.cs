using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SIIModel.Admin;
using SIIRepository.Adminservice;
using System.Diagnostics;
namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class ProgrammeLevelMasterController : Controller
    {
        // GET: Admin/ProgrammeLevelMaster
        #region Master
        public ActionResult Index(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult SaveData(mProgrammeLevel _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_PROGRAMMELEVEL(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];
                        if (_dr["COUNTS"].ToString() == "1")
                        {
                            Code = "success";
                            Message = "Data saved successfully";
                        }
                        else if (_dr["COUNTS"].ToString() == "2")
                        {
                            Code = "success";
                            Message = "Data updated successfully";
                        }
                        else if (_dr["COUNTS"].ToString() == "-1")
                        {
                            Code = "already";
                            Message = "Data is already exists";
                        }
                        else
                        {
                            Code = "error";
                            Message = "No data saved. Kindly try again.";
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
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectData(string ProgramLevel_Id, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.SELECT_PROGRAMMELEVEL_FOR_FORM(ProgramLevel_Id, IsNicheCourse);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mProgrammeLevel
                            {
                                ProgramLevel_Id = _dr["ProgramLevel_Id"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString()
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
        public JsonResult DeleteData(string ProgramLevel_Id, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.DELETE_PROGRAMMELEVEL_FOR_FORM(ProgramLevel_Id: ProgramLevel_Id, IsNicheCourse: Convert.ToInt32(IsNicheCourse));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Code = "success";
                        Message = "Data has been deleted successfully..";
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
        #endregion

        #region Mapping
        public ActionResult Mapping(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult MappingSaveData(mProgrammeLevelMapping _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_Discipline_Programme_Mapping(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];
                        if (_dr["COUNTS"].ToString() == "1")
                        {
                            Code = "success";
                            Message = "Data saved successfully";
                        }
                        else if (_dr["COUNTS"].ToString() == "2")
                        {
                            Code = "success";
                            Message = "Data updated successfully";
                        }
                        else if (_dr["COUNTS"].ToString() == "-1")
                        {
                            Code = "already";
                            Message = "Data is already exists";
                        }
                        else
                        {
                            Code = "error";
                            Message = "No data saved. Kindly try again.";
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
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult MappingSelectData(string Mpng_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevelMapping> _list = new List<mProgrammeLevelMapping>();
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.SELECT_Discipline_Programme_Mapping_FOR_FORM(Mpng_ID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mProgrammeLevelMapping
                            {
                                Mpng_ID = _dr["Mpng_ID"].ToString(),
                                Discipline_ID = _dr["Discipline_ID"].ToString(),
                                Discipline = _dr["Discipline"].ToString(),
                                ProgramLevel_Id = _dr["ProgramLevel_Id"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString()
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
        public JsonResult MappingDeleteData(string Mpng_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.DELETE_Discipline_Programme_Mapping_FOR_FORM(Mpng_ID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Code = "success";
                        Message = "Data has been deleted successfully..";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
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
        #endregion
    }
}