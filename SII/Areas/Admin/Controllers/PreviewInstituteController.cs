using SIIRepository.Institute;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class PreviewInstituteController : Controller
    {
        // GET: Admin/PreviewInstitute
        public ActionResult Index(string instituteid = "",string Name="")
        {

            TempData["InstituteID"] = instituteid;
            TempData["InstituteName"] = Name;
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(instituteid);
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
                        ViewBag.HeadName = _dr["HeadPrefix"].ToString() + " " + _dr["HeadFirstName"].ToString() + " " + _dr["HeadLastName"].ToString() + " (" + _dr["HeadDesignation"].ToString() + ")";
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
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return View();
        }

        public ActionResult ViewDetails(string d = "")
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");

            ViewBag.DetailsFor = d;
            return View();
        }

        public ActionResult _InstituteProfile()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _Courses()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }

        public ActionResult _NicheCourses()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _Campus()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _CostOfLiving()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _ExtendedAssistant()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _FacultyAlumni()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _HowToReach()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }
        public ActionResult _Gallery()
        {
            TempData.Keep("InstituteID");
            TempData.Keep("InstituteName");
            return PartialView();
        }

    }
}