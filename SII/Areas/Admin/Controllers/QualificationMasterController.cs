using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SIIModel.Admin;
using SIIRepository.Adminservice;
using SIIModel.Master;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]

    public class QualificationMasterController : Controller
    {
        // GET: Admin/QualificationMaster
        #region Master
        public ActionResult Index(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult SaveData(mQualification _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_Qualification(_obj);
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
        public JsonResult SelectData(string Qualification_ID = "0", string isNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mQualification> _list = new List<mQualification>();
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.SELECT_Qualification_FOR_FORM(Qualification_ID, IsNicheCourse: Convert.ToInt32(isNicheCourse.ToString()));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mQualification
                            {
                                Qualification_ID = _dr["Qualification_ID"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString(),
                                ProgramLevel_Id = _dr["ProgramLevel_Id"].ToString(),
                                Qualification = _dr["Qualification"].ToString()
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
        public JsonResult DeleteData(string Qualification_ID = "0", string isNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.DELETE_Qualification_FOR_FORM(Qualification_ID, IsNicheCourse: Convert.ToInt32(isNicheCourse.ToString()));
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

        public JsonResult SelectPL(string Discipline_ID = "0", string isNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.SELECT_PROGRAMELEVEL_FROM_DISCIPLINE(Discipline_ID, Convert.ToInt32(isNicheCourse));
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
        public JsonResult SelectQ(string ProgramLevel_Id="0", string isNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mQualification> _list = new List<mQualification>();
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.SELECT_Qualification_FROM_PROGRAMELEVEL(ProgramLevel_Id, IsNicheCourse: Convert.ToInt32(isNicheCourse.ToString()));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mQualification
                            {
                                Qualification_ID = _dr["Qualification_ID"].ToString(),
                                Qualification = _dr["Qualification"].ToString()
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

        #region Mapping
        public ActionResult Mapping(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult MappingSaveData(mQualificationMapping _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_tbl_NatureOfCourse(_obj);
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
        public JsonResult MappingSelectData(string Natureofcourse_Id, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;

            List<mQualificationMapping> _list = new List<mQualificationMapping>();
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.SELECT_tbl_NatureOfCourse_FOR_FORM(Natureofcourse_Id, Convert.ToInt32(IsNicheCourse));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mQualificationMapping
                            {
                                Natureofcourse_Id = _dr["Natureofcourse_Id"].ToString(),
                                Qualification_ID = _dr["Qualification_ID"].ToString(),
                                Mpng_ID = _dr["Mpng_ID"].ToString(),
                                Discipline_ID = _dr["Discipline_ID"].ToString(),
                                ProgramLevel_Id = _dr["ProgramLevel_Id"].ToString(),
                                Discipline = _dr["Discipline"].ToString(),
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
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
        public JsonResult MappingDeleteData(string Natureofcourse_Id="", string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.DELETE_tbl_NatureOfCourse_FOR_FORM(Natureofcourse_Id, IsNicheCourse: Convert.ToInt32(IsNicheCourse));
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
    }
}