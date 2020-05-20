using SIIModel.Institute;
using SIIModel.Master;
using SIIRepository.Institute;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class DetailsController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/Details
        public ActionResult Index()
        {
            
            TempData["ActiveMainTabInstitute"] = "Institute";
            selectDropdown();
            return View();
        }

        #region Dropdown bind
        public void selectDropdown()
        {
            StudentRepository _objNationality = new StudentRepository();
            DataSet ds = _objNationality.select_form_load_student();
            List<Country> _Country = new List<Country>();
            if (ds != null)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString();
                        _Country.Add(_objcountry);
                    }
                }
            }
            ViewBag.Country = _Country;
        }
        #endregion

        #region Institute save update
        public JsonResult Select_Institute_Details()
        {
            List<InstituteMaster> _list = new List<InstituteMaster>();
            InstituteRepository _objRepository = new InstituteRepository();
            //using (IInstituteMaster _objRepository = new RInstituteMaster())
            //{
            DataSet ds = _objRepository.Search_Institute_By_Id(Session["InstituteID"].ToString());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InstituteMaster _objList = new InstituteMaster();
                        _objList.ID = row["ID"].ToString();
                        _objList.InstituteID = row["InstituteID"].ToString();
                        _objList.InstituteName = row["InstituteName"].ToString();
                        _objList.Email = row["Email"].ToString();
                        _objList.Address = row["Address"].ToString();
                        _objList.State = row["State"].ToString();
                        _objList.City = row["City"].ToString();
                        _objList.Pin = row["Pin"].ToString();
                        _objList.YOE = row["YOE"].ToString();
                        _objList.Description = row["Description"].ToString();
                        //_objList.History = row["History"].ToString();
                        //_objList.Awards = row["Awards"].ToString();
                        //_objList.Fellows = row["Fellows"].ToString();
                        //_objList.News = row["News"].ToString();
                        //_objList.Area = row["Area"].ToString();
                        //_objList.ProgramOffered = row["ProgramOffered"].ToString();
                        _objList.IsSubmited = row["IsSubmited"].ToString();
                        _objList.Description = row["Description"].ToString();
                        _objList.AcademicCourses = row["AcademicCourses"].ToString();
                        _objList.AreaOfExcellence = row["AreaOfExcellence"].ToString();
                        _objList.ResearchCapability = row["ResearchCapability"].ToString();
                        // _objList.FacultyOverview = row["FacultyOverview"].ToString();
                        _objList.NotableResearchPublication = row["NotableResearchPublication"].ToString();
                        _objList.NIRFRanking = row["NIRFRanking"].ToString();
                        _objList.NBANAACAccreditation = row["NBANAACAccreditation"].ToString();
                        _objList.instituteweburl = row["instituteweburl"].ToString();
                        _list.Add(_objList);
                    }
                }
                //  }
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
        public JsonResult Save_Institute_Details(InstituteMaster _obj)
        {
            bool flag = false;
            bool flagExists = false;
            try
            {
                InstituteRepository _objRepository = new InstituteRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.ModifiedIP = localIP;
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.Update_Institute_Details(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "-1")
                        {
                            flagExists = true;
                        }
                        else if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "1")
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
                flag = flag,
                flagExists = flagExists
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region  International Collaboration
        public JsonResult Select_InternationalCollaboration(string ID)
        {
            List<InstituteCollaboration> _list = new List<InstituteCollaboration>();
            InstituteCollaborationRepository _objRepository = new InstituteCollaborationRepository();
            DataSet ds = _objRepository.InstituteCollaboration_Select(ID, Session["InstituteID"].ToString());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InstituteCollaboration _objList = new InstituteCollaboration();
                        _objList.ID = row["ID"].ToString();
                        _objList.InstituteID = row["InstituteID"].ToString();
                        _objList.NameOfProgram = row["NameOfProgram"].ToString();
                        _objList.CollaborateInstitute = row["CollaborateInstitute"].ToString();
                        _objList.Collaboratecountry = row["Collaboratecountry"].ToString();
                        _objList.CollaborateAddress = row["CollaborateAddress"].ToString();
                        _objList.Remarks = row["Remarks"].ToString();
                        _objList.Collaborate_country = row["Collaborate_country"].ToString();
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
        public JsonResult Save_InternationalCollaboration(InstituteCollaboration _obj)
        {
            bool flag = false;
            try
            {
                InstituteCollaborationRepository _objRepository = new InstituteCollaborationRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.InstituteCollaboration_Insert(_obj);
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

        public JsonResult Delete_InternationalCollaboration(string ID = "")
        {
            bool flag = false;
            InstituteCollaborationRepository _objRepository = new InstituteCollaborationRepository();
            DataSet _ds = _objRepository.InstituteCollaboration_Delete(ID);
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
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Industry Associations
        public JsonResult Select_InstituteAssociationsRepository(string ID)
        {
            List<InstituteAssociations> _list = new List<InstituteAssociations>();
            InstituteAssociationsRepository _objRepository = new InstituteAssociationsRepository();
            DataSet ds = _objRepository.InstituteAssociations_Select(ID, Session["InstituteID"].ToString());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InstituteAssociations _objList = new InstituteAssociations();
                        _objList.ID = row["ID"].ToString();
                        _objList.InstituteID = row["InstituteID"].ToString();
                        _objList.FamousProject = row["FamousProject"].ToString();
                        _objList.FamousProject2 = row["FamousProject2"].ToString();
                        _objList.FamousProject3 = row["FamousProject3"].ToString();
                        _objList.FamousProject4 = row["FamousProject4"].ToString();
                        _objList.FamousProject5 = row["FamousProject5"].ToString();
                        _objList.Researches = row["Researches"].ToString();
                        _objList.Researches2 = row["Researches2"].ToString();
                        _objList.Researches3 = row["Researches3"].ToString();
                        _objList.Researches4 = row["Researches4"].ToString();
                        _objList.Researches5 = row["Researches5"].ToString();
                        _objList.PlacementOffering = row["PlacementOffering"].ToString();
                        _objList.SummerInternship = row["SummerInternship"].ToString();
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
        public JsonResult Save_InstituteAssociationsRepository(InstituteAssociations _obj)
        {
            bool flag = false;
            try
            {
                InstituteAssociationsRepository _objRepository = new InstituteAssociationsRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.InstituteAssociations_Insert(_obj);
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

        #region KeyStatistics
        public JsonResult Select_KeyStatistics(string ID)
        {
            KeyStatisticsRepository _objKeyStatistics = new KeyStatisticsRepository();
            DataSet ds = _objKeyStatistics.KeyStatistics_Select(ID, Session["InstituteID"].ToString());
            List<KeyStatistics> _list = new List<KeyStatistics>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        KeyStatistics _ObjModel = new KeyStatistics();
                        _ObjModel.ID = row["ID"].ToString();
                        _ObjModel.InstituteID = row["InstituteID"].ToString();
                        _ObjModel.NoOfStudentDegreeAward = row["NoOfStudentDegreeAward"].ToString();
                        _ObjModel.NoOfStudentStrength = row["NoOfStudentStrength"].ToString();
                        _ObjModel.NoOfInterStudentIntake = row["NoOfInterStudentIntake"].ToString();
                        _ObjModel.NoOfResearch = row["NoOfResearch"].ToString();
                        _ObjModel.NoOfPatents = row["NoOfPatents"].ToString();
                        _ObjModel.NoOfFullTimeStafStrength = row["NoOfFullTimeStafStrength"].ToString();
                        _ObjModel.NoOfPartTimeStafStrength = row["NoOfPartTimeStafStrength"].ToString();
                        //_ObjModel.CreatedIP = row["CreatedIP"].ToString();
                        _list.Add(_ObjModel);
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
        public JsonResult Save_KeyStatistics(KeyStatistics _obj)
        {
            bool flag = false;
            try
            {
                KeyStatisticsRepository _objKeyStatistics = new KeyStatisticsRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objKeyStatistics.KeyStatistics_Insert(_obj);
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