using SIIRepository.Institute;
using System.Data;
using System.Web.Mvc;

namespace SII.Controllers
{
     //[CompressContent]
    //   [WhitespaceFilter]
    public class ExploreController : Controller
    {
        // GET: Explore
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index(string instituteid = "" )
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
           
            TempData.Keep("instituteid");
          //  TempData.Keep("NicheCourseId");
            return View();
        }
        public ActionResult ViewDetails(string instituteid = "", string For = "", string Category = null, string NicheCourseId = null)
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            if (NicheCourseId == "")
            {
                TempData["NicheCourseId"] = "";
            }
            else
            {
                TempData["NicheCourseId"] = NicheCourseId;
            }
            TempData.Keep("NicheCourseId");
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _ds = _objRepository.Select_Institute_By_InstituteID(instituteid);
            string InstituteName = "[Institute Name]";
            string TotalCourses = "0";
            string TotalSeats = "0";
            string IsNICHECourse = "0";
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[0].Rows[0];
                    InstituteName = _dr["InstituteName"].ToString() + ", " + _dr["City"].ToString().Trim();
                    IsNICHECourse = _dr["IsNicheAllowed"].ToString().Trim();
                }
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[1].Rows[0];
                    TotalCourses = _dr["TotalCourses"].ToString();
                    TotalSeats = _dr["TotalSeats"].ToString();
                }
            }
            ViewBag.InstituteName = InstituteName;
            TempData["TotalCourses"] = TotalCourses;
            TempData["TotalSeats"] = TotalSeats;
            TempData["IsNICHECourse"] = IsNICHECourse;
            TempData.Keep("instituteid");
            ViewBag.DetailsFor = For;
            if (Category == "")
            {
                TempData["Category"] = "";
            }
            else
            {
                TempData["Category"] = Category;
            }
            return View();
        }
        public ActionResult ViewNicheDetails(string instituteid = "", string For = "", string Category = null, string NicheCourseId = null)
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            if (NicheCourseId == "")
            {
                TempData["NicheCourseId"] = "";
            }
            else
            {
                TempData["NicheCourseId"] = NicheCourseId;
            }
            TempData.Keep("NicheCourseId");
            InstituteRepository _objRepository = new InstituteRepository();
            DataSet _ds = _objRepository.Select_Institute_By_InstituteID(instituteid);
            string InstituteName = "[Institute Name]";
            string TotalCourses = "0";
            string TotalSeats = "0";
            string IsNICHECourse = "0";
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[0].Rows[0];
                    InstituteName = _dr["InstituteName"].ToString() + ", " + _dr["City"].ToString().Trim();
                    IsNICHECourse = _dr["IsNicheAllowed"].ToString().Trim();
                }
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[1].Rows[0];
                    TotalCourses = _dr["TotalCourses"].ToString();
                    TotalSeats = _dr["TotalSeats"].ToString();
                }
            }
            ViewBag.InstituteName = InstituteName;
            TempData["TotalCourses"] = TotalCourses;
            TempData["TotalSeats"] = TotalSeats;
            TempData["IsNICHECourse"] = IsNICHECourse;
            TempData.Keep("instituteid");
            ViewBag.DetailsFor = For;
            if (Category == "")
            {
                TempData["Category"] = "";
            }
            else
            {
                TempData["Category"] = Category;
            }
            return View();
        }

        public ActionResult _HowToReach(string instituteid = "")
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            TempData.Keep("TotalCourses");
            TempData.Keep("TotalSeats");
            return PartialView();
        }
        public ActionResult _AreaOfExpert(string instituteid = "")
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            TempData.Keep("TotalCourses");
            TempData.Keep("TotalSeats");
            return PartialView();
        }
        public ActionResult _Campus(string instituteid = "")
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            TempData.Keep("TotalCourses");
            TempData.Keep("TotalSeats");
            return PartialView();
        }
        public ActionResult _AboutInstitute(string instituteid = "")
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            TempData.Keep("instituteid");
            return PartialView();
        }
        public ActionResult _GalleryPhoto(string instituteid = "", string Category = "")
        {
            if (instituteid == "")
            {
                TempData["instituteid"] = "";
            }
            else
            {
                TempData["instituteid"] = instituteid;
            }
            if (Category == "")
            {
                TempData["Category"] = "";
            }
            else
            {
                TempData["Category"] = Category;
            }




            TempData.Keep("instituteid");
            return PartialView();
        }

    }
}