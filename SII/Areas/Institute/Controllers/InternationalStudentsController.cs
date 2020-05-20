using SIIModel.Institute;
using SIIRepository.Institute;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class InternationalStudentsController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/InternationalStudents
        public ActionResult Index()
        {
            TempData["ActiveMainTabInstitute"] = "InternationalStudents";
            return View();
        }

        #region Institute save update
        public JsonResult Select_InternationalSchool(InstituteStudentsFacility obj)
        {
            List<InstituteStudentsFacility> _list = new List<InstituteStudentsFacility>();
            obj.InstituteID = Session["InstituteID"].ToString();
            InstituteStudentsFacilityRepository _objRepository = new InstituteStudentsFacilityRepository();
            DataSet ds = _objRepository.InstituteStudentsFacility_Select(obj);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InstituteStudentsFacility _objList = new InstituteStudentsFacility();
                        _objList.ID = row["ID"].ToString();
                        _objList.InstituteID = row["InstituteID"].ToString();
                        _objList.HasCellOffice = row["HasCellOffice"].ToString();
                        _objList.CellOfficeDesc = row["CellOfficeDesc"].ToString();
                        _objList.HasVisaAssistance= row["HasVisaAssistance"].ToString();
                        _objList.VisaAssistanceDesc = row["VisaAssistanceDesc"].ToString();
                        _objList.HasCulturalEngagement = row["HasCulturalEngagement"].ToString();
                        _objList.HasStudentBoarding = row["HasStudentBoarding"].ToString();
                        _objList.HasArrival = row["HasArrival"].ToString();
                        _objList.IntroProgram = row["IntroProgram"].ToString();
                        _objList.ContactPersonName = row["ContactPersonName"].ToString();
                        _objList.ContactPersonEmail = row["ContactPersonEmail"].ToString();
                        _objList.ContactPersonMobile = row["ContactPersonMobile"].ToString();
                        _objList.ContactPersonPhone = row["ContactPersonPhone"].ToString();
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
#pragma warning disable SCS0017 // Request validation is disabled
        [ValidateInput(false)]
#pragma warning restore SCS0017 // Request validation is disabled
        [ValidateAntiForgeryToken]
        public JsonResult Save_StudentFacility(InstituteStudentsFacility _obj)
        {
            bool flag = false;
            try
            {
                InstituteStudentsFacilityRepository _objRepository = new InstituteStudentsFacilityRepository();
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.CreatedIP = Session["localIP"].ToString();
                DataSet _ds = _objRepository.InstituteStudentsFacility_Insert(_obj);
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
        #endregion
    }
}