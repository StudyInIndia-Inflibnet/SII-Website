using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class CourseOfStudyMasterController : Controller
    {
        // GET: Admin/CourseOfStudyMaster
        public ActionResult Index(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult SaveData(mCourseOfStudy _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_CourseOfStudy(_obj);
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
        public JsonResult SelectData(string CourseOfStudy_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mCourseOfStudy> _list = new List<mCourseOfStudy>();
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.SELECT_CourseOfStudy_FOR_FORM(CourseOfStudy_ID, Convert.ToInt32(IsNicheCourse));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mCourseOfStudy
                            {
                                CourseOfStudy_ID = _dr["CourseOfStudy_ID"].ToString(),
                                CourseOfStudy = _dr["CourseOfStudy"].ToString()
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
        public JsonResult DeleteData(string CourseOfStudy_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.DELETE_CourseOfStudy_FOR_FORM(CourseOfStudy_ID, Convert.ToInt32(IsNicheCourse));
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

        #region Mapping
        public ActionResult Mapping(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult MappingSaveData(mCourseOfStudyMapping _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_tbl_CourseBranch(_obj);
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
        public JsonResult MappingSelectData(string CourseOfStudy_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mCourseOfStudy> _list = new List<mCourseOfStudy>();
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.SELECT_CourseOfStudy_FOR_FORM(CourseOfStudy_ID, Convert.ToInt32(IsNicheCourse));
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mCourseOfStudy
                            {
                                CourseOfStudy_ID = _dr["CourseOfStudy_ID"].ToString(),
                                CourseOfStudy = _dr["CourseOfStudy"].ToString()
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
        public JsonResult MappingDeleteData(string Branch_Id, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                CourseOfStudy_Repository _objRepo = new CourseOfStudy_Repository();
                DataSet _ds = _objRepo.DELETE_tbl_CourseBranch_FOR_FORM(Branch_Id, Convert.ToInt32(IsNicheCourse));
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