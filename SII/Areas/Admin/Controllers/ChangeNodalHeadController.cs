using SIIModel.Institute;
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
    [NoDirectAccessAdmin]
    public class ChangeNodalHeadController : Controller
    {
        // GET: Admin/ChangeNodalHead
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(string id = "")
        {
            if (id == "")
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Nodal_Head_Details(mNodalHeadOfficers _obj)
        {
            string flag = "0";
            try
            {
                DashboardRepository _objRepository = new DashboardRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                DataSet _ds = _objRepository.Save_NodalHead_Data(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        flag = _ds.Tables[0].Rows[0]["FLAG"].ToString();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}