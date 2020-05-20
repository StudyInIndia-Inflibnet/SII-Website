using SIIModel.Admin;
using SIIModel.FrontPanel;
using SIIModel.Master;
using SIIRepository.Adminservice;
using SIIRepository.FrontPanel;
using SIIRepository.Institute;
using SIIRepository.Masterservice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SII.Controllers
{
    public class InstituteSearchController : Controller
    {
        // GET: InstituteSearch
        public ActionResult Index()
        {
            SelectDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FilterData(InstituteSearch _obj)
        {
            _obj.Type = "GridDetails";
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.CreatedIP = localIP;
            InstituteSearchRepository _objRepository = new InstituteSearchRepository();
            DataSet _ds = _objRepository.OperationInstituteSearch(_obj);
            List<InstituteSearchResult> _list = new List<InstituteSearchResult>();
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        InstituteSearchResult _objResult = new InstituteSearchResult();
                        _objResult.InstituteID = _dr["InstituteID"].ToString();
                        _objResult.InstituteName = _dr["InstituteName"].ToString();
                        _objResult.instituteweburl = _dr["instituteweburl"].ToString();
                        _objResult.state_name = _dr["state_name"].ToString();
                        _objResult.City = _dr["City"].ToString();
                        _objResult.Pin = _dr["Pin"].ToString();
                        _objResult.Address = _dr["Address"].ToString();
                        _objResult.YOE = _dr["YOE"].ToString();
                        _objResult.description = _dr["description"].ToString();
                        _objResult.NoOfStudentDegreeAward = _dr["NoOfStudentDegreeAward"].ToString();
                        _objResult.NoOfStudentStrength = _dr["NoOfStudentStrength"].ToString();
                        _objResult.NoOfInterStudentIntake = _dr["NoOfInterStudentIntake"].ToString();
                        _objResult.NoOfResearch = _dr["NoOfResearch"].ToString();
                        _objResult.NoOfPatents = _dr["NoOfPatents"].ToString();
                        _objResult.NoOfFullTimeStafStrength = _dr["NoOfFullTimeStafStrength"].ToString();
                        _objResult.NoOfPartTimeStafStrength = _dr["NoOfPartTimeStafStrength"].ToString();
                        _objResult.CourseCount = _dr["CourseCount"].ToString();
                        _objResult.Photo = _dr["Photo"].ToString();
                        _objResult.SheetCount = _dr["SheetCount"].ToString();
                        _objResult.FilttredCourseCount = _dr["FilttredCourseCount"].ToString();
                        _objResult.FiltteredSheetCount = _dr["FiltteredSheetCount"].ToString();
                        _list.Add(_objResult);
                    }
                }
            }
            _obj.Type = "Load";
            DataSet _dsLoad = _objRepository.OperationInstituteSearch(_obj);
            List<InstituteSearchFilter> _listProgramLevel = new List<InstituteSearchFilter>();
            List<InstituteSearchFilter> _listState = new List<InstituteSearchFilter>();
            List<InstituteSearchFilter> _listNatureOfCourse = new List<InstituteSearchFilter>();
            List<InstituteSearchFilter> _listBranch = new List<InstituteSearchFilter>();
            List<InstituteSearchFilter> _listType = new List<InstituteSearchFilter>();
            string StatePara = "", ProgramLevelPara = "", NatureOfCoursePara = "", BranchIDPara = "", InstituteTypePara = "";
            if (_dsLoad != null)
            {
                if (_dsLoad.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[0].Rows)
                    {
                        InstituteSearchFilter _objResult = new InstituteSearchFilter();
                        _objResult.Id = _dr["Id"].ToString();
                        _objResult.Value = _dr["Value"].ToString();
                        _objResult.Help = _dr["Help"].ToString();
                        _listState.Add(_objResult);
                    }
                }
                if (_dsLoad.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[1].Rows)
                    {
                        InstituteSearchFilter _objResult = new InstituteSearchFilter();
                        _objResult.Id = _dr["Id"].ToString();
                        _objResult.Value = _dr["Value"].ToString();
                        _objResult.Help = _dr["Help"].ToString();
                        _listProgramLevel.Add(_objResult);
                    }
                }
                if (_dsLoad.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[2].Rows)
                    {
                        InstituteSearchFilter _objResult = new InstituteSearchFilter();
                        _objResult.Id = _dr["Id"].ToString();
                        _objResult.Value = _dr["Value"].ToString();
                        _objResult.Help = _dr["Help"].ToString();
                        _listNatureOfCourse.Add(_objResult);
                    }
                }
                if (_dsLoad.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[3].Rows)
                    {
                        StatePara = _dr["StatePara"].ToString();
                        ProgramLevelPara = _dr["ProgramLevelPara"].ToString();
                        NatureOfCoursePara = _dr["NatureOfCoursePara"].ToString();
                        BranchIDPara = _dr["BranchIDPara"].ToString();
                        InstituteTypePara = _dr["InstituteTypePara"].ToString();
                    }
                }
                if (_dsLoad.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[4].Rows)
                    {
                        InstituteSearchFilter _objResult = new InstituteSearchFilter();
                        _objResult.Id = _dr["Id"].ToString();
                        _objResult.Value = _dr["Value"].ToString();
                        _objResult.Help = _dr["Help"].ToString();
                        _listBranch.Add(_objResult);
                    }
                }
                if (_dsLoad.Tables[5].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dsLoad.Tables[5].Rows)
                    {
                        InstituteSearchFilter _objResult = new InstituteSearchFilter();
                        _objResult.Id = _dr["Id"].ToString();
                        _objResult.Value = _dr["Value"].ToString();
                        _objResult.Help = _dr["Help"].ToString();
                        _listType.Add(_objResult);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                FilterListState = _listState,
                FilterListProgramLevel = _listProgramLevel,
                FilterListNatureOfCourse = _listNatureOfCourse,
                FilterListBranch = _listBranch,
                FilterListType = _listType,
                StatePara = StatePara,
                ProgramLevelPara = ProgramLevelPara,
                NatureOfCoursePara = NatureOfCoursePara,
                BranchIDPara = BranchIDPara,
                InstituteTypePara = InstituteTypePara
            },
                JsonRequestBehavior.AllowGet
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SearchInstitutes(InstituteSearchPara _obj)
        {
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.Created_Ip = localIP;
            _obj.ParticipatedYear = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
            InstituteSearchRepository _objRepository = new InstituteSearchRepository();
            DataSet _ds = _objRepository.InstituteSearchForWebsite(_obj);
            List<InstituteSearchVM> _list = new List<InstituteSearchVM>();
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        InstituteSearchVM _objResult = new InstituteSearchVM();
                        _objResult.InstituteID = _dr["InstituteID"].ToString();
                        _objResult.InstituteName = _dr["InstituteName"].ToString();
                        _objResult.Website = _dr["Website"].ToString();
                        _objResult.StateName = _dr["StateName"].ToString();
                        _objResult.City = _dr["City"].ToString();
                        _objResult.TotalCourse = _dr["TotalCourse"].ToString();
                        _objResult.TotalSeats = _dr["TotalSeats"].ToString();
                        _objResult.Photo = _dr["Photo"].ToString();
                        _objResult.Discipline = _dr["Discipline"].ToString();
                        _objResult.ProgramLevel = _dr["ProgramLevel"].ToString();
                        _objResult.Qualification = _dr["Qualification"].ToString();
                        _objResult.CourseOfStudy = _dr["CourseOfStudy"].ToString();
                        _list.Add(_objResult);
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

        #region Fill Dropdowns
        private void SelectDropdowns()
        {
            string Code = string.Empty, Message = string.Empty;
            List<InstituteSearchDropdowns> _listDiscipline = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listProgrammeLevel = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listQualification = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listCourseOfStudy = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listInstituteType = new List<InstituteSearchDropdowns>();
            try
            {
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SELECT_INSTITUTE_SEARCH_DROPDOWNS("Dropdowns", "", "", "");
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _listDiscipline.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[1].Rows)
                        {
                            _listProgrammeLevel.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[2].Rows)
                        {
                            _listQualification.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[3].Rows)
                        {
                            _listCourseOfStudy.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[4].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[4].Rows)
                        {
                            _listInstituteType.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.Disciplines = _listDiscipline;
            ViewBag.ProgrammeLevel = _listProgrammeLevel;
            ViewBag.Qualification = _listQualification;
            ViewBag.CourseOfStudy = _listCourseOfStudy;
            ViewBag.InstituteType = _listInstituteType;
        }

        public JsonResult FillDowndowns(string Type = "", string Discipline_ID = "0", string ProgramLevel_Id = "0", string Qualification_ID = "0")
        {
            string Code = string.Empty, Message = string.Empty;
            List<InstituteSearchDropdowns> _list = new List<InstituteSearchDropdowns>();
            try
            {
                InstituteRepository _objRepo = new InstituteRepository();
                DataSet _ds = _objRepo.SELECT_INSTITUTE_SEARCH_DROPDOWNS(Type, Discipline_ID, ProgramLevel_Id, Qualification_ID);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new InstituteSearchDropdowns
                            {
                                Id = _dr["ID"].ToString(),
                                Value = _dr["VALUE"].ToString()
                            });
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
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
        #endregion
    }
}