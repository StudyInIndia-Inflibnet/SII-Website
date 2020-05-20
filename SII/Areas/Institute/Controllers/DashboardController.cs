using SIIRepository.Institute;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class DashboardController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Dashboard
        public ActionResult Index()
        {
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(Session["InstituteID"].ToString(), ConfigurationManager.AppSettings["ParticipatedYear"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        ViewBag.InstituteProfile = _dr["InstituteProfile"].ToString();
                        ViewBag.Courses = _dr["Courses"].ToString();
                        ViewBag.NicheCourses = _dr["NicheCourses"].ToString();
                        ViewBag.Campus = _dr["Campus"].ToString();
                        ViewBag.CostOfLiving = _dr["CostOfLiving"].ToString();
                        ViewBag.InternationalStudents = _dr["InternationalStudents"].ToString();
                        ViewBag.FacultyAlumni = _dr["FacultyAlumni"].ToString();
                        ViewBag.HowToReach = _dr["HowToReach"].ToString();
                        ViewBag.Gallery = _dr["Gallery"].ToString();
                    }
                }
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[1].Rows)
                    {
                        ViewBag.HeadName = _dr["HeadPrefix"].ToString() + " " + _dr["HeadFirstName"].ToString() + " " + _dr["HeadLastName"].ToString() + " ("+ _dr["HeadDesignation"].ToString() + ")";
                        ViewBag.HeadEmail = _dr["HeadEmail"].ToString();
                        ViewBag.HeadMobile = _dr["HeadMobile"].ToString();
                        ViewBag.HeadPhone = _dr["HeadPhone"].ToString();

                        ViewBag.NodalName = _dr["NodalPrefix"].ToString() + " " + _dr["NodalFirstName"].ToString() + " " + _dr["NodalLastName"].ToString() + " (" + _dr["NodalDesignation"].ToString() + ")";
                        ViewBag.NodalEmail = _dr["NodalEmail"].ToString();
                        ViewBag.NodalMobile = _dr["NodalMobile"].ToString();
                        ViewBag.NodalPhone = _dr["NodalPhone"].ToString();
                    }
                }
            }

            //ViewBag.InstituteProfile = "100";
            //ViewBag.Courses = "10";
            //ViewBag.Campus = "35";
            //ViewBag.CostOfLiving = "33";
            //ViewBag.InternationalStudents = "65";
            //ViewBag.FacultyAlumni = "70";
            //ViewBag.HowToReach = "19";
            //ViewBag.Gallery = "80";

            return View();
        }
        public ActionResult ViewDetails(string d = "")
        {
            ViewBag.DetailsFor = d;
            return View();
        }
        public ActionResult ViewDetailsNicheCourse() {
            
            return View();
        }
        public ActionResult _InstituteProfile()
        {

            return PartialView();
        }
        public ActionResult _Courses()
        {
            return PartialView();
        }
        public ActionResult _Campus()
        {
            return PartialView();
        }
        public ActionResult _CostOfLiving()
        {
            return PartialView();
        }
        public ActionResult _ExtendedAssistant()
        {
            return PartialView();
        }
        public ActionResult _FacultyAlumni()
        {
            return PartialView();
        }
        public ActionResult _HowToReach()
        {
            return PartialView();
        }
        public ActionResult _Gallery()
        {
            return PartialView();
        }
    }
}