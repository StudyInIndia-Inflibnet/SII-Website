using SIIModel.Admin;
using SIIModel.Courses;
using SIIModel.FrontPanel;
using SIIModel.Master;
using SIIRepository.Adminservice;
using SIIRepository.Courses;
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
    public class NICHEController : Controller
    {
        // GET: NICHE
        #region Views
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult CourseSearch(string For = "")
        {
            SelectDropdown();
            SelectDropdownNiche();
            TempData["For"] = For;
            ViewBag.For = For;
            return View();
        }
        public ActionResult Yoga()
        {
            return View();
        }
        public ActionResult Ayurvedic()
        {
            return View();
        }
        //public ActionResult Tibetan()
        //{
        //    return View();
        //}
        public ActionResult Buddhism()
        {
            return View();
        }
        #endregion


        #region Dropdowns
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
                DataSet _ds = _objRepo.SELECT_INSTITUTE_SEARCH_NICHE_DROPDOWNS("Dropdowns", "", "", "");
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
        public void SelectDropdownNiche()
        {
            NICHE _objDiscipline = new NICHE();
            DataSet ds = _objDiscipline.Select_Niche("Discipline");
            List<Descipline> _Discipline = new List<Descipline>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Descipline _obj = new Descipline();
                        _obj.Discipline_ID = (row["Discipline_ID"].ToString());
                        _obj.Discipline = row["Discipline"].ToString();
                        _Discipline.Add(_obj);
                    }
                }
            }
            ViewBag.DesciplineNiche = _Discipline;
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

        public void SelectDropdown()
        {
            Descipline obj = new Descipline();
            DisciplineRepository _objNationality = new DisciplineRepository();
            DataSet ds = _objNationality.Select_decipline("1");
            List<Descipline> _Descipline = new List<Descipline>();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Descipline _objDescipline = new Descipline();
                        _objDescipline.Discipline_ID = (row["Discipline_ID"].ToString());
                        _objDescipline.Discipline = row["Discipline"].ToString();
                        _Descipline.Add(_objDescipline);
                    }
                }
            }

            ProgramLevels objpro = new ProgramLevels();
            ProgramLevelsRepository _objpro = new ProgramLevelsRepository();
            DataSet ds1 = _objpro.Select_ProgramLevel("1");
            List<ProgramLevels> _ProgramLevels = new List<ProgramLevels>();

            if (ds1 != null)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        ProgramLevels _objProgramLevels = new ProgramLevels();
                        _objProgramLevels.ProgramLevel_Id = (row["ProgramLevel_Id"].ToString());
                        _objProgramLevels.ProgramLevel = row["ProgramLevel"].ToString();
                        _ProgramLevels.Add(_objProgramLevels);
                    }
                }
            }

            CurrencyRepository _objRepo = new CurrencyRepository();
            DataSet dsContry = _objRepo.select_Currency();
            List<Currency> _ListCurrency = new List<Currency>();
            if (dsContry != null)
            {
                if (dsContry.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsContry.Tables[0].Rows)
                    {
                        Currency _objcont = new Currency();
                        _objcont.Currency_Id = row["Currency_Id"].ToString();
                        _objcont.CurrencyCode = row["CurrencyCode"].ToString();
                        _objcont.CurrencyName = row["CurrencyName"].ToString();
                        _ListCurrency.Add(_objcont);
                    }
                }
            }

            ViewBag.Currency = _ListCurrency;
            ViewBag.Descipline = _Descipline;
            ViewBag.ProgramLevels = _ProgramLevels;
        }

        public JsonResult SelectDropdown_CourseType(string ID = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "", string Type = "", string CourseOfStudy_ID = "", string InstituteType = "", string InstituteID = "", string GenderRestrictions = "")
        {
            NICHE objRep = new NICHE();
            DataSet ds = objRep.sp_Select_tbl_InstituteCourse_Niche_Search(ID, Discipline_ID, "0", "0", "DropDown_List_Type", "0", "0", "", "0");
            List<CourseType> _CourseType = new List<CourseType>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CourseType _obj = new CourseType();
                        _obj.Id = (row["Id"].ToString());
                        _obj.Value = row["Value"].ToString();
                        _CourseType.Add(_obj);

                    }
                }
            }
            string Code = string.Empty, Message = string.Empty;
            return Json(new
            {
                List = _CourseType,
                c = Code,
                m = Message
            },
               JsonRequestBehavior.AllowGet
            );
            //ViewBag.DesciplineNiche = _CourseType;
        }
        public JsonResult SelectPLNiche(string ID = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "", string Type = "", string CourseOfStudy_ID = "", string InstituteType = "", string InstituteID = "", string GenderRestrictions = "")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.sp_Select_tbl_InstituteCourse_Niche_Search(ID, Discipline_ID, "0", "0", "DropDown_List_ProgramLevel", "0", InstituteType, "", "0");
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mProgrammeLevel
                            {
                                ProgramLevel_Id = _dr["ProgramLevel_Id"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString()
                            });
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
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
        public JsonResult SelectQNiche(string ID = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "", string Type = "", string CourseOfStudy_ID = "", string InstituteType = "", string InstituteID = "", string GenderRestrictions = "")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mQualification> _list = new List<mQualification>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.sp_Select_tbl_InstituteCourse_Niche_Search(ID, Discipline_ID, ProgramLevel_Id, "0", "DropDown_List_Qualification", "0", InstituteType, "", "0");
                if (_ds != null)

                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mQualification
                            {
                                Qualification_ID = _dr["Qualification_ID"].ToString(),
                                Qualification = _dr["Qualification"].ToString()
                            });
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Code = "error";
                Message = "Your session has been expired. Kindly refresh and try again.";
            }
            catch (Exception)
            {
                Code = "error";
                Message = "Error from server side. Kindly refresh and try again.";
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
        public JsonResult SelectCSNiche(string ID = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "", string Type = "", string CourseOfStudy_ID = "", string InstituteType = "", string InstituteID = "", string GenderRestrictions = "")
        {
            string Code = string.Empty, Message = string.Empty;
            List<mCourseOfStudy> _list = new List<mCourseOfStudy>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.sp_Select_tbl_InstituteCourse_Niche_Search(ID, Discipline_ID, ProgramLevel_Id, Qualification_ID, "DropDown_List_CourseOfStudy", "0", InstituteType, "", "0");
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mCourseOfStudy
                            {
                                CourseOfStudy_ID = _dr["CourseOfStudy_ID"].ToString(),
                                CourseOfStudy = _dr["CourseOfStudy"].ToString()
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

        public JsonResult SelectNicheCourse(string ID = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "", string Type = "", string CourseOfStudy_ID = "", string InstituteType = "", string InstituteID = "", string Month_id = "", string Year_id = "", string GenderRestrictions = "")
        {
            NICHE objRep = new NICHE();

            DataSet ds = objRep.sp_Select_tbl_InstituteCourse_Niche_Search(ID, Discipline_ID, ProgramLevel_Id, Qualification_ID, "AllNicheCourse", CourseOfStudy_ID, InstituteType, InstituteID, GenderRestrictions, Month_id, Year_id);
            //List<NicheCourse> _list = new List<NicheCourse>();
            List<InstituteSearchVM> _list = new List<InstituteSearchVM>();
            List<Date> _listDT = new List<Date>();
            List<Date> _listYr = new List<Date>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[0].Rows)
                    {
                        NicheCourse objNicheCourse = new NicheCourse();

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
                        _objResult.ID = _dr["ID"].ToString();
                        _objResult.StartDate = _dr["StartDate"].ToString();
                        _objResult.EndDate = _dr["EndDate"].ToString();
                        _list.Add(_objResult);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Date _obj = new Date();
                        _obj.Month_id = (row["Month_id"].ToString());
                        _obj.Month = row["Month"].ToString();
                        _listDT.Add(_obj);
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        Date _obj = new Date();
                        _obj.Year_id = (row["Year_id"].ToString());
                        _obj.Year = row["year"].ToString();
                        _listYr.Add(_obj);
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListMonth = _listDT,
                ListYear = _listYr,
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SearchCourseList(InstituteSearchPara _obj)
        {
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.Created_Ip = localIP;
            _obj.ParticipatedYear = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
            InstituteSearchRepository _objRepository = new InstituteSearchRepository();
            DataSet _ds = _objRepository.InstituteSearchForWebsite_New(_obj);
            List<InstituteSearchVM> _list = new List<InstituteSearchVM>();
            List<InstituteSearchDropdowns> _listCity = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listDiscipline = new List<InstituteSearchDropdowns>();
            List<InstituteSearchDropdowns> _listCourseOfStudy = new List<InstituteSearchDropdowns>();
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        InstituteSearchVM _objResult = new InstituteSearchVM();
                        _objResult.ID = _dr["ID"].ToString();
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
                        _objResult.StartDate = Convert.ToDateTime(_dr["StartDate"].ToString()).ToString("dd-MM-yyyy");
                        _objResult.EndDate = Convert.ToDateTime(_dr["EndDate"].ToString()).ToString("dd-MM-yyyy");
                        _objResult.TotalFees = _dr["TotalFees"].ToString();
                        _objResult.TotalFeesCurrency = _dr["TotalFeesCurrency"].ToString();
                        _objResult.Photo = _dr["Photo"].ToString();

                        _list.Add(_objResult);
                    }
                }
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[1].Rows)
                    {
                        _listCity.Add(new InstituteSearchDropdowns
                        {
                            Id = _dr["City"].ToString(),
                            Value = _dr["City"].ToString()
                        });
                    }
                }

                if (_ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[2].Rows)
                    {
                        _listDiscipline.Add(new InstituteSearchDropdowns
                        {
                            Id = _dr["Discipline_ID"].ToString(),
                            Value = _dr["Discipline"].ToString()
                        });
                    }
                }

                if (_ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[3].Rows)
                    {
                        _listCourseOfStudy.Add(new InstituteSearchDropdowns
                        {
                            Id = _dr["CourseOfStudy_ID"].ToString(),
                            Value = _dr["CourseOfStudy"].ToString()
                        });
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListCity = _listCity,
                ListDiscipline = _listDiscipline,
                ListCourseOfStudy = _listCourseOfStudy
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}