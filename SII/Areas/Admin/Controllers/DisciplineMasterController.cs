using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class DisciplineMasterController : Controller
    {
        //// GET: Admin/DisciplineMaster
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Admin/DisciplineMaster?course=niche

        public ActionResult Index(string id = "")
        {
            ViewBag.isNicheCourse = (id == "niche") ? 1 : 0;
            return View();
        }
        public JsonResult SaveData(mDiscipline _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Discipline_Repository _objRepo = new Discipline_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_DISCIPLINE(_obj);
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
        public JsonResult SelectData(string Discipline_ID = "0", string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mDiscipline> _list = new List<mDiscipline>();
            try
            {
                Discipline_Repository _objRepo = new Discipline_Repository();
                DataSet _ds = _objRepo.SELECT_DISCIPLINE_FOR_FORM(Discipline_ID: Discipline_ID, IsNicheCourse: IsNicheCourse);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mDiscipline
                            {
                                Discipline_ID = _dr["Discipline_ID"].ToString(),
                                Discipline = _dr["Discipline"].ToString()
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
        public JsonResult DeleteData(string Discipline_ID, string IsNicheCourse = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                Discipline_Repository _objRepo = new Discipline_Repository();
                DataSet _ds = _objRepo.DELETE_DISCIPLINE_FOR_FORM(Discipline_ID, IsNicheCourse: IsNicheCourse);
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
    }
}