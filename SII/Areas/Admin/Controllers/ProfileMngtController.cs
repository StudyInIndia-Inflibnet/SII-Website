using SIIModel.Admin;
using SIIRepository.Adminservice;
using SIIModel.Master;
using SIIRepository.StudentRegService;
using System.Data;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class ProfileMngtController : Controller
    {
        // GET: Admin/ProfileMngt
        public ActionResult Index()
        {
            if (Session["is_callCentre"].ToString().ToLower() == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SearchStudent(string SearchString = "", string Captchastr = "")
        {
            bool flagCaptcha = false;
            bool flag = false;
            List<ProfileManagement> _list = new List<ProfileManagement>();
            if (this.Session["CaptchaImageText"].ToString() == Captchastr)
            {
                flagCaptcha = true;
                string IP = "?";
                IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                SIIRepository.Adminservice.DashboardRepository _objRepo = new SIIRepository.Adminservice.DashboardRepository();
                DataSet _ds = _objRepo.Search_Student_Data(SearchString, IP);

                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        flagCaptcha = true;
                        flag = true;
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new ProfileManagement
                            {
                                srno = _dr["srno"].ToString(),
                                StudentID = _dr["StudentID"].ToString(),
                                StudentName = _dr["StudentName"].ToString(),
                                Email = _dr["Email"].ToString(),
                                Mobile = _dr["Mobile"].ToString(),
                                Country = _dr["Country"].ToString(),
                                Nationality = _dr["Nationality"].ToString(),
                                Gender = _dr["Gender"].ToString(),
                                DateOfBirth = _dr["DateOfBirth"].ToString(),
                                Registerdate = _dr["Registerdate"].ToString()
                            });
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            var jsonResult = Json(new {
                flagCaptcha = flagCaptcha,
                flag = flag,
                List = _list
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult Editprofile(string StudentID)
        {
            if (Session["is_callCentre"].ToString().ToLower() == "true")
            {
                selectDropdown();
                TempData["StudentID"]= StudentID;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
            }
        }
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Nationality> _Nationality = new List<Nationality>();
            List<Country> _Country = new List<Country>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Nationality _objpro = new Nationality();
                        _objpro.Nationality_id = (row["Nationality_id"].ToString());
                        _objpro.Nationality_Name = row["Nationality"].ToString();
                        _Nationality.Add(_objpro);
                    }
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Country.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
        }
        public JsonResult SELECT_EDITPROFILE()
        {

            SIIRepository.Adminservice.DashboardRepository _objRepository = new SIIRepository.Adminservice.DashboardRepository();
            string IP = "?";
            IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            DataSet ds = _objRepository.SELECT_STUDENT_DATA_FOREDIT(TempData.Peek("StudentID").ToString());
            List<ProfileManagement> _list = new List<ProfileManagement>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[0].Rows)
                    {
                        ProfileManagement _obj = new ProfileManagement();
                        _obj.FirstName = _dr["FirstName"].ToString();
                        _obj.MiddleName = _dr["MiddleName"].ToString();
                        _obj.LastName = _dr["LastName"].ToString();
                        _obj.Email = _dr["Email"].ToString();
                        _obj.Mobile = _dr["Mobile"].ToString();
                        _obj.DateOfBirth = _dr["DateOfBirth"].ToString();
                        _obj.StudentID = _dr["StudentID"].ToString();
                        _obj.Country = _dr["Country"].ToString();
                        _list.Add(_obj);
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
        [ValidateAntiForgeryToken]
        public JsonResult SaveProfile(ProfileManagement _obj)
        {
            string counts = "";

            try
            {
                if (ModelState.IsValid)
                {
                    SIIRepository.Adminservice.DashboardRepository objRepository = new SIIRepository.Adminservice.DashboardRepository();
                    _obj.IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    _obj.updatedBy = Session["User_Name"].ToString();
                    DataSet _ds = objRepository.INSERT_STUDENT_DATA_FOREDIT(_obj);
                    if (_ds != null)
                    {
                        if (_ds.Tables[0].Rows.Count > 0)
                        {
                            counts = (_ds.Tables[0].Rows[0]["counts"].ToString());
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Json(new
            {

                count = counts
            },
                JsonRequestBehavior.AllowGet
            );
        }

    }
}