using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class CampusController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Campus
        public ActionResult Index()
        {
            TempData["ActiveMainTabInstitute"] = "Campus";

            
            return View();
        }
        #region Infrastucture
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Campus_Infrastructure(InstituteInfrascuture _obj)
        {
            InstituteInfrascutureRepository objRepository = new InstituteInfrascutureRepository();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.CreatedIP = Session["localIP"].ToString();
            _obj.Edited_by= Session["User_id"].ToString();
            DataSet _ds = objRepository.Save_Campus_Infrastructure(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Select_Campus_Infrastructure()
        {
            InstituteInfrascutureRepository objRep = new InstituteInfrascutureRepository();
            DataSet ds = objRep.Select_Campus_Infrastructure(Session["InstituteID"].ToString());
            List<InstituteInfrascuture> _list = new List<InstituteInfrascuture>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InstituteInfrascuture objCourse = new InstituteInfrascuture();
                        objCourse.ID = row["ID"].ToString();
                        objCourse.InstituteID = row["InstituteId"].ToString();
                        objCourse.Area = row["Area"].ToString();
                        objCourse.ITInfrastructure = row["ITInfrastructure"].ToString();
                        objCourse.ITInfrastructureWifiFacility = row["ITInfrastructureWifiFacility"].ToString();
                        objCourse.AcademicFacilities = row["AcademicFacilities"].ToString();
                        objCourse.Database = row["Database"].ToString();
                        objCourse.elibrary = row["elibrary"].ToString();
                        objCourse.ResearchFacilitiesLabs = row["ResearchFacilitiesLabs"].ToString();
                        objCourse.Accommodation = row["Accommodation"].ToString();
                        objCourse.AccommodationWifi = row["AccommodationWifi"].ToString();
                        objCourse.CuisineServedInMess = row["CuisineServedInMess"].ToString();
                        objCourse.CuisinesOfFoodServed = row["CuisinesOfFoodServed"].ToString();
                        objCourse.Doctors = row["Doctors"].ToString();
                        objCourse.Pharmacy = row["Pharmacy"].ToString();
                        _list.Add(objCourse);
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
        #endregion

        #region Life On Campus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Campus_Life_On_Campus(LifeOnCampus _obj)
        {
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.CreatedIP = Session["localIP"].ToString();
            _obj.Edited_by = Session["User_id"].ToString();
            string path = "";
            string filename = "";
            string fname = "";
            if (Request.Files.Count > 0)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Institute/" + _obj.InstituteID + "/Newslatter/";
                    filename = Path.GetFileName(Request.Files[0].FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        string[] curentfiles = Directory.GetFiles(path);
                    }
                    HttpPostedFileBase file = files[0];
                    filename = _obj.InstituteID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") +  Path.GetExtension(file.FileName);
                    fname = Path.Combine(Server.MapPath("~/Uploads/Institute/" + _obj.InstituteID + "/Newslatter/"), filename);
                    file.SaveAs(fname);
                    _obj.NewsLatters = "Uploads/Institute/" + _obj.InstituteID + "/Newslatter/" + filename;
                }
                else
                {
                    _obj.NewsLatters = "";
                }
            }
            else
            {
                _obj.NewsLatters = "";
            }
            InstituteInfrascutureRepository objRepository = new InstituteInfrascutureRepository();
            
            DataSet _ds = objRepository.Save_Campus_Life_On_Campus(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Select_Campus_Life_On_Campus()
        {
            InstituteInfrascutureRepository objRep = new InstituteInfrascutureRepository();
            DataSet ds = objRep.Select_Campus_Life_On_Campus(Session["InstituteID"].ToString());
            List<LifeOnCampus> _list = new List<LifeOnCampus>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LifeOnCampus objCourse = new LifeOnCampus();
                        objCourse.ID = row["ID"].ToString();
                        objCourse.InstituteID = row["InstituteId"].ToString();
                        objCourse.SportArea = row["SportArea"].ToString();
                        objCourse.TypesOfSportsCurrentlyPlayed = row["TypesOfSportsCurrentlyPlayed"].ToString();
                        objCourse.SportAccomplishments = row["SportAccomplishments"].ToString();
                        objCourse.MusicInstruments = row["MusicInstruments"].ToString();
                        objCourse.MusicAccomplishments = row["MusicAccomplishments"].ToString();
                        objCourse.AcademicBodie = row["AcademicBodie"].ToString();
                        objCourse.FestivalsConductedByStudents = row["FestivalsConductedByStudents"].ToString();
                        objCourse.NewsLatters = row["NewsLatters"].ToString();
                        objCourse.EventsCompetitions = row["EventsCompetitions"].ToString();
                        objCourse.OfficialEvents = row["OfficialEvents"].ToString();
                        _list.Add(objCourse);
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
        #endregion

        #region Life Outside Campus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Campus_Life_Outside_Campus(LifeOutsideCampus _obj)
        {
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.CreatedIP = Session["localIP"].ToString();
            _obj.Edited_by = Session["User_id"].ToString();
            InstituteInfrascutureRepository objRepository = new InstituteInfrascutureRepository();

            DataSet _ds = objRepository.Save_Campus_Life_Outside_Campus(_obj);
            bool flag = true;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "0")
                    {
                        flag = false;
                    }
                }
            }
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Select_Campus_Life_Outside_Campus()
        {
            InstituteInfrascutureRepository objRep = new InstituteInfrascutureRepository();
            DataSet ds = objRep.Select_Campus_Life_Outside_Campus(Session["InstituteID"].ToString());
            List<LifeOutsideCampus> _list = new List<LifeOutsideCampus>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LifeOutsideCampus objCourse = new LifeOutsideCampus();
                        objCourse.ID = row["ID"].ToString();
                        objCourse.InstituteID = row["InstituteId"].ToString();
                        objCourse.PlacesToVisit = row["PlacesToVisit"].ToString();
                        objCourse.ThingsToDo = row["ThingsToDo"].ToString();
                        objCourse.LocalLanguages = row["LocalLanguages"].ToString();
                        objCourse.LocalCulture = row["LocalCulture"].ToString();
                        _list.Add(objCourse);
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
        #endregion
    }
}