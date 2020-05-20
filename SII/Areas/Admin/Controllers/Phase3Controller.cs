using ClosedXML.Excel;
using SII.Models;
using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class Phase3Controller : Controller
    {
        // GET: Admin/Phase2
        public ActionResult Index()
        {
            TempData["User_id"] = Session["User_id"].ToString();
            return View();
        }
        public ActionResult NicheReports()
        {
            TempData["User_id"] = Session["User_id"].ToString();
            return View();
        }

        public ActionResult NicheReportsList(string ParameterCode = "", string SubParameterLevel1Code = "", string SubParameterLevel2Code = "")
        {
            TempData["User_id"] = Session["User_id"].ToString();
            TempData["ParameterCode"] = ParameterCode;
            TempData["SubParameterLevel1Code"] = SubParameterLevel1Code;
            TempData["SubParameterLevel2Code"] = SubParameterLevel2Code;
            ViewBag.ParameterCode = ParameterCode;
            ViewBag.SubParameterLevel1Code = SubParameterLevel1Code;
            ViewBag.SubParameterLevel2Code = SubParameterLevel2Code;
            #region Export Registered Students
            ReportsRepository _objRepo = new ReportsRepository();
            //DataSet _ds = _objRepo.SELECT_PHASE2_KPI_REGISTERED_STUDENTS("List", "RegisteredStudents");
            SIIRepository.Adminservice.Phase3_Repository _objRepoDashboard = new SIIRepository.Adminservice.Phase3_Repository();
            System.Data.DataSet _ds = _objRepoDashboard.KPIReport_ParameterGridDetails("Details", "", @TempData.Peek("ParameterCode").ToString(), @TempData.Peek("SubParameterLevel1Code").ToString(), @TempData.Peek("SubParameterLevel2Code").ToString());
            DataTable _dt = _ds.Tables[1];
            _dt.TableName = "Data";
            if (_dt.Rows.Count > 0)
            {
                if (_ds != null)
                {

                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow _drCol in _ds.Tables[0].Rows)
                        {
                            if (_drCol["ColVisibility"].ToString() == "True")
                            {
                                _dt.Columns[_drCol["ColCode"].ToString()].ColumnName = _drCol["ColDisplayName"].ToString();
                            }
                        }
                    }

                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(_dt);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    var filename = "";
                    if (SubParameterLevel2Code != "")
                    { filename =  _ds.Tables[2].Rows[0]["SubParameterLevel2"].ToString() + DateTime.Now.ToString(); }
                    else if (SubParameterLevel2Code == "" && SubParameterLevel1Code != "")
                    { filename =   _ds.Tables[2].Rows[0]["SubParameterLevel1"].ToString() + DateTime.Now.ToString(); }
                    else if (SubParameterLevel2Code == "" && SubParameterLevel1Code == "" && ParameterCode!="")
                    { filename =  _ds.Tables[2].Rows[0]["Parameter"].ToString() + DateTime.Now.ToString(); }

                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
                return RedirectToAction("Reports", "Phase3", new { Area = "Admin" });
                #endregion
            }
            else { return View("Reports", "Phase3", new { Area = "Admin" }); }
        }
    }
}