using System;
using SIIModel.Admin;
using SIIRepository.Adminservice;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class EQPLMappingController : Controller
    {
        // GET: Admin/EQPLMapping
        [SessionExpireAdmin]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SaveData(mEQPL _obj)
        {
            string Code = string.Empty, Message = string.Empty;
            try
            {
                EQPL_Repository _objRepo = new EQPL_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_EQPLMapping(_obj);
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
        public JsonResult SelectData(string EduQualifications_Id)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mEQPL> _list = new List<mEQPL>();
            try
            {
                EQPL_Repository _objRepo = new EQPL_Repository();
                DataSet _ds = _objRepo.SELECT_EQPLMapping_FOR_FORM(EduQualifications_Id);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mEQPL
                            {
                                EduQualifications_Id = _dr["EduQualifications_Id"].ToString(),
                                EQPLMapping = _dr["EQPLMapping"].ToString()
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
    }
}