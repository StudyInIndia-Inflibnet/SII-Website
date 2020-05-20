using SIIModel.Admin;
using SIIModel.Courses;
using SIIModel.Master;
using SIIRepository.Adminservice;
using SIIRepository.Courses;
using SIIRepository.Masterservice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using System.Web.UI;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class CoursesController : Controller
    {
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        // GET: Institute/Courses
        public ActionResult Index()
        {
            if (Session["IsAdminEdit"] != null)
            {
                if (Session["IsAdminEdit"].ToString() != "True")
                {

                    if (Session["IsAdminFLag"] != null)
                    {
                        if (Session["IsAdminFLag"].ToString() != "True" || DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["InstituteCourseUpdate"].ToString()))
                        {
                            if (Session["IsNicheAllowed"] != null)
                            {
                                if (Session["IsNicheAllowed"].ToString() != "True" || DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["InstituteCourseNicheUpdate"].ToString()))
                                {
                                    return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
                                }
                                return RedirectToAction("NICHE", "Courses", new { Area = "Institute" });
                            }
                            return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
                        }

                    }
                }
            }
            TempData["ActiveMainTabInstitute"] = "Courses";
            SelectDropdown();
            SelectDropdownNiche();
            return View();
        }

        #region FillDropdown
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
        public JsonResult SelectNatureofcourse(NatureOfCourses obj)
        {
            NatureOfCoursesRepository objRep = new NatureOfCoursesRepository();
            DataSet ds = objRep.select_Natureofcourse(obj);
            List<NatureOfCourses> _list = new List<NatureOfCourses>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        NatureOfCourses objBasic = new NatureOfCourses();
                        objBasic.Natureofcourse_Id = row["Natureofcourse_Id"].ToString();
                        objBasic.Discipline_ID = row["Discipline_ID"].ToString();
                        objBasic.ProgramLevel_Id = row["ProgramLevel_Id"].ToString();
                        objBasic.NatureOfCourse = row["NatureOfCourse"].ToString();
                        _list.Add(objBasic);
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
        public JsonResult SelectBranch(Branch obj)
        {
            BranchRepository objRep = new BranchRepository();
            DataSet ds = objRep.sp_select_coursebranch(obj);
            List<Branch> _list = new List<Branch>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Branch objBasic = new Branch();
                        objBasic.Natureofcourse_Id = row["Natureofcourse_Id"].ToString();
                        objBasic.Branchname = row["Branchname"].ToString();
                        objBasic.Branch_Id = row["Branch_Id"].ToString();
                        _list.Add(objBasic);
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
        public JsonResult SelectPL(string Discipline_ID)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.SELECT_PROGRAMELEVEL_FROM_DISCIPLINE(Discipline_ID);
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
        public JsonResult SelectQ(string Discipline_ID, string ProgramLevel_Id)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mQualification> _list = new List<mQualification>();
            try
            {
                Qualification_Repository _objRepo = new Qualification_Repository();
                DataSet _ds = _objRepo.SELECT_Qualification_FROM_DIS_PL(Discipline_ID, ProgramLevel_Id);
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
        public JsonResult SelectCS(string Discipline_ID, string ProgramLevel_Id, string Qualification_ID)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mCourseOfStudy> _list = new List<mCourseOfStudy>();
            try
            {
                ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                DataSet _ds = _objRepo.SELECT_tbl_CourseOfStudy_FROM_Qaulification(Discipline_ID, ProgramLevel_Id, Qualification_ID);
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
        public JsonResult SelectECS(string id)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mEduSubject> _list = new List<mEduSubject>();
            try
            {
                CourseRepository _objRepo = new CourseRepository();
                DataSet _ds = _objRepo.SELECT_tbl_EduSubject(id);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mEduSubject
                            {
                                EduSubject_Id = _dr["EduSubject_Id"].ToString(),
                                EduSubject = _dr["EduSubject"].ToString()
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
        public JsonResult SelectAES(string id)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mAditionalExamScore> _list = new List<mAditionalExamScore>();
            try
            {
                CourseRepository _objRepo = new CourseRepository();
                DataSet _ds = _objRepo.SELECT_tbl_AditionalExamScore(id);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mAditionalExamScore
                            {
                                AditionalExamSocreDisplay = _dr["AditionalExamSocreDisplay"].ToString(),
                                AditionalExamScore = _dr["AditionalExamScore"].ToString()
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
        #endregion

        #region Save Select and Delete CourseOffers
        public JsonResult SaveCourseOffers(Course _obj)
        {
            string Error = string.Empty; bool flag = true;
            try
            {
                CourseRepository objRepository = new CourseRepository();
                _obj.CreatedBy = Session["InstituteID"].ToString();
                _obj.CreatedIP = Session["localIP"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                _obj.ParticipatedYear = Session["ParticipatedYear"].ToString();
                if (_obj.BranchName == null)
                {
                    _obj.BranchName = "";
                }
                DataSet _ds = objRepository.InsertUpdateCourse(_obj);
                
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
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            
            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectCourseOffers(Course obj)
        {
            CourseRepository objRep = new CourseRepository();
            obj.InstituteID = Session["InstituteID"].ToString();
            obj.ParticipatedYear = Session["ParticipatedYear"].ToString();
            DataSet ds = objRep.Select_InstituteCourse(obj);
            List<Course> _list = new List<Course>();
            List<mInstituteCourse_EC> _listEC = new List<mInstituteCourse_EC>();
            List<mInstituteCourse_AE> _listAE = new List<mInstituteCourse_AE>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Course objCourse = new Course();
                        objCourse.ID = row["ID"].ToString();
                        objCourse.InstituteID = row["InstituteId"].ToString();
                        objCourse.Discipline_ID = row["Discipline_Id"].ToString();
                        objCourse.Natureofcourse_Id = row["Natureofcourse_Id"].ToString();
                        objCourse.ProgramLevel_Id = row["ProgramLevel_Id"].ToString();
                        objCourse.Branch_Id = row["Branch_Id"].ToString();
                        objCourse.Discipline = row["Discipline"].ToString();
                        objCourse.Natureofcourse = row["Natureofcourse"].ToString();
                        objCourse.ProgramLevel = row["ProgramLevel"].ToString();
                        objCourse.BranchName = row["BranchName"].ToString();
                        objCourse.EligibilityCriteria = row["EligibilityCriteria"].ToString();
                        objCourse.SeatForForeignStudent = row["SeatForForeignStudent"].ToString();
                        objCourse.AnnualTutionFees = row["AnnualTutionFees"].ToString();
                        objCourse.AnnualBoardingFees = row["AnnualBoardingFees"].ToString();
                        objCourse.AnnualTutionFeesCurrency = row["AnnualTutionFeesCurrency"].ToString();
                        objCourse.AnnualBoardingFeesCurrency = row["AnnualBoardingFeesCurrency"].ToString();
                        objCourse.G1SeatWaiver = row["G1SeatWaiver"].ToString();
                        objCourse.G2SeatWaiver = row["G2SeatWaiver"].ToString();
                        objCourse.G3SeatWaiver = row["G3SeatWaiver"].ToString();
                        objCourse.G4SeatWaiver = row["G4SeatWaiver"].ToString();
                        objCourse.Credits = row["Credits"].ToString();
                        objCourse.CourseDurations = row["CourseDurations"].ToString();
                        objCourse.ClassRoomHours = row["ClassRoomHours"].ToString();
                        objCourse.CoursePatterns = row["CoursePatterns"].ToString();
                        objCourse.CourseDesc = row["CourseDesc"].ToString();
                        objCourse.AdmissionReq = row["AdmissionReq"].ToString();
                        objCourse.IsGivenFromInstitute = row["IsGivenFromInstitute"].ToString();
                        objCourse.FeesForSAARCCountry = row["FeesForSAARCCountry"].ToString();
                        objCourse.FeesForNonSAARCCountry = row["FeesForNonSAARCCountry"].ToString();
                        objCourse.FeesForSAARCCountryCurrency = row["FeesForSAARCCountryCurrency"].ToString();
                        objCourse.FeesForNonSAARCCountryCurrency = row["FeesForNonSAARCCountryCurrency"].ToString();
                        objCourse.Q0Req = row["Q0Req"].ToString();
                        objCourse.Q1Req = row["Q1Req"].ToString();
                        objCourse.Q2Req = row["Q2Req"].ToString();
                        objCourse.Q3Req = row["Q3Req"].ToString();
                        objCourse.Q0Qualification = row["Q0Qualification"].ToString();
                        objCourse.Q0Subject = row["Q0Subject"].ToString();
                        objCourse.Q0Percentage = row["Q0Percentage"].ToString();
                        objCourse.Q1Qualification = row["Q1Qualification"].ToString();
                        objCourse.Q1Subject = row["Q1Subject"].ToString();
                        objCourse.Q1Percentage = row["Q1Percentage"].ToString();
                        objCourse.Q2Qualification = row["Q2Qualification"].ToString();
                        objCourse.Q2Subject = row["Q2Subject"].ToString();
                        objCourse.Q2Percentage = row["Q2Percentage"].ToString();
                        objCourse.Q3Qualification = row["Q3Qualification"].ToString();
                        objCourse.Q3Subject = row["Q3Subject"].ToString();
                        objCourse.Q3Percentage = row["Q3Percentage"].ToString();
                        objCourse.JEEMainReq = row["JEEMainReq"].ToString();
                        objCourse.JEEMainscoreReq = row["JEEMainscoreReq"].ToString();
                        objCourse.JEEAdvanceReq = row["JEEAdvanceReq"].ToString();
                        objCourse.JEEAdvanceScoreReq = row["JEEAdvanceScoreReq"].ToString();
                        objCourse.IELTSReq = row["IELTSReq"].ToString();
                        objCourse.IELTSscoreReq = row["IELTSscoreReq"].ToString();
                        objCourse.GMATReq = row["GMATReq"].ToString();
                        objCourse.GMATScoreReq = row["GMATScoreReq"].ToString();
                        objCourse.TOFELReq = row["TOFELReq"].ToString();
                        objCourse.TOFELScoreReq = row["TOFELScoreReq"].ToString();
                        objCourse.SATReq = row["SATReq"].ToString();
                        objCourse.SATScoreReq = row["SATScoreReq"].ToString();
                        objCourse.GATEReq = row["GATEReq"].ToString();
                        objCourse.GATEScoreReq = row["GATEScoreReq"].ToString();
                        _list.Add(objCourse);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[1].Rows)
                    {
                        _listEC.Add(new mInstituteCourse_EC
                        {
                            ID = _dr["ID"].ToString(),
                            EduQualifications_Id = _dr["EduQualifications_Id"].ToString(),
                            EduQualifications = _dr["EduQualifications"].ToString(),
                            EduQualificationsFor = _dr["EduQualificationsFor"].ToString(),
                            EduSubject_Id = _dr["EduSubject_Id"].ToString(),
                            EduSubject = _dr["EduSubject"].ToString(),
                            Operator = _dr["Operator"].ToString(),
                            OperatorDisplay = _dr["OperatorDisplay"].ToString(),
                            PercentageID = _dr["PercentageID"].ToString()
                        });
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[2].Rows)
                    {
                        _listAE.Add(new mInstituteCourse_AE
                        {
                            ID = _dr["ID"].ToString(),
                            AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                            AditionalExams = _dr["AditionalExams"].ToString(),
                            //CriteriaDate = _dr["CriteriaDate"].ToString(),
                            AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                            CutOff = _dr["CutOff"].ToString(),
                            Operator = _dr["Operator"].ToString(),
                            OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        });
                        //if (_dr["AditionalExams_Id"].ToString() == "10")
                        //{
                        //    _listAE.Add(new mInstituteCourse_AE
                        //    {
                        //        ID = _dr["ID"].ToString(),
                        //        AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                        //        AditionalExams = _dr["AditionalExams"].ToString(),
                        //        AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                        //        CriteriaDate = Convert.ToDateTime(_dr["CriteriaDate"].ToString()).ToString("dd-MM-yyyy"),
                        //        CutOff = _dr["CutOff"].ToString(),
                        //        Operator = _dr["Operator"].ToString(),
                        //        OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        //    });
                        //}
                        //else
                        //{
                        //    _listAE.Add(new mInstituteCourse_AE
                        //    {
                        //        ID = _dr["ID"].ToString(),
                        //        AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                        //        AditionalExams = _dr["AditionalExams"].ToString(),
                        //        //CriteriaDate = _dr["CriteriaDate"].ToString(),
                        //        AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                        //        CutOff = _dr["CutOff"].ToString(),
                        //        Operator = _dr["Operator"].ToString(),
                        //        OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        //    });
                        //}
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListEC = _listEC,
                ListAE = _listAE
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult DeleteCourseOffers(Course _obj)
        {
            CourseRepository objRepository = new CourseRepository();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.ParticipatedYear = Session["ParticipatedYear"].ToString();
            DataSet _ds = objRepository.Delete_InstituteCourse(_obj);
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
        #endregion

        #region BridgeCourse
        public JsonResult SelectLanguage(Language obj)
        {
            LanguageRepository objRep = new LanguageRepository();
            DataSet ds = objRep.select_Language(obj);
            List<Language> _list = new List<Language>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Language objBasic = new Language();
                        objBasic.Language_Id = row["Language_Id"].ToString();
                        objBasic.language = row["language"].ToString();
                        _list.Add(objBasic);
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
        public JsonResult SelectDurationType(DurationType obj)
        {
            DurationTypeRepository objRep = new DurationTypeRepository();
            DataSet ds = objRep.select_DurationType(obj);
            List<DurationType> _list = new List<DurationType>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DurationType objBasic = new DurationType();
                        objBasic.Duration_Id = row["Duration_Id"].ToString();
                        objBasic.DurationName = row["DurationName"].ToString();
                        _list.Add(objBasic);
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
        public JsonResult SaveBridgeCourse(BridgeCourse _obj)
        {
            BridgeCourseRepository objRepository = new BridgeCourseRepository();
            _obj.CreatedIP = Session["localIP"].ToString();
            _obj.Edited_by = Session["User_id"].ToString();
            _obj.Type = "InsertUpdate";
            DataSet _ds = objRepository.OperationCourse(_obj);
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
        public JsonResult SelectBridgeCourse(BridgeCourse obj)
        {
            BridgeCourseRepository objRep = new BridgeCourseRepository();
            obj.InstituteID = Session["InstituteID"].ToString();
            obj.Type = "Fetch";
            DataSet ds = objRep.OperationCourse(obj);
            List<BridgeCourse> _list = new List<BridgeCourse>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        BridgeCourse objCourse = new BridgeCourse();
                        objCourse.ID = row["ID"].ToString();
                        objCourse.InstituteID = row["InstituteId"].ToString();
                        objCourse.CourseName = row["CourseName"].ToString();
                        objCourse.Language = row["Language"].ToString();
                        objCourse.Duration = row["Duration"].ToString();
                        objCourse.DurationType = row["DurationType"].ToString();
                        objCourse.NumberOfSeats = row["NumberOfSeats"].ToString();
                        objCourse.FeesForSAARCCountry = row["FeesForSAARCCountry"].ToString();
                        objCourse.FeesForNonSAARCCountry = row["FeesForNonSAARCCountry"].ToString();
                        objCourse.G1SeatWaiver = row["G1SeatWaiver"].ToString();
                        objCourse.G2SeatWaiver = row["G2SeatWaiver"].ToString();
                        objCourse.G3SeatWaiver = row["G3SeatWaiver"].ToString();
                        objCourse.G4SeatWaiver = row["G4SeatWaiver"].ToString();
                        objCourse.ClassRoomHours = row["ClassRoomHours"].ToString();
                        objCourse.FeesForSAARCCountryCurrency = row["FeesForSAARCCountryCurrency"].ToString();
                        objCourse.FeesForNonSAARCCountryCurrency = row["FeesForNonSAARCCountryCurrency"].ToString();
                        objCourse.TypeOfFees = row["TypeOfFees"].ToString();
                        objCourse.TotalFeesBridgeCourseCurrency = row["TotalFeesBridgeCourseCurrency"].ToString();
                        objCourse.TotalFeesBridgeCourse = row["TotalFeesBridgeCourse"].ToString();
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
        public JsonResult DeleteBridgeCourse(BridgeCourse _obj)
        {
            BridgeCourseRepository objRep = new BridgeCourseRepository();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.Type = "Delete";
            DataSet _ds = objRep.OperationCourse(_obj);
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
        #endregion

        #region NICHE Courses
        public ActionResult NICHE()
        {
            if (Session["IsAdminEdit"] != null)
            {
                if (Session["IsAdminEdit"].ToString() != "True")
                {
                    if (Session["IsNicheAllowed"] != null)
                    {
                        if (Session["IsNicheAllowed"].ToString() != "True" || DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["InstituteCourseNicheUpdate"].ToString()))
                        {
                            return RedirectToAction("Index", "Dashboard", new { Area = "Institute" });
                        }
                    }
                }
            }
            TempData["ActiveMainTabInstitute"] = "Courses";
            SelectDropdown();
            SelectDropdownNiche();
            return View();
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
        public JsonResult SelectPLNiche(string Discipline_ID)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.Select_Niche("PLNiche", Discipline_ID);
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
        public JsonResult SelectQNiche(string Discipline_ID, string ProgramLevel_Id)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mQualification> _list = new List<mQualification>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.Select_Niche("QNiche", Discipline_ID, ProgramLevel_Id);
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
        public JsonResult SelectCSNiche(string Discipline_ID, string ProgramLevel_Id, string Qualification_ID)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mCourseOfStudy> _list = new List<mCourseOfStudy>();
            try
            {
                NICHE objRep = new NICHE();
                DataSet _ds = objRep.Select_Niche("CSNiche", Discipline_ID, ProgramLevel_Id, Qualification_ID);
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
        public JsonResult SaveNicheCourse(NicheCourse _obj)
        {
            NICHE objRepository = new NICHE();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.CreatedIP = Session["localIP"].ToString();
            _obj.Edited_by = Session["User_id"].ToString();
            _obj.ParticipatedYear = Session["ParticipatedYear"].ToString();
            if (_obj.BranchName == null)
            {
                _obj.BranchName = "";
            }
            DataSet _ds = objRepository.sp_Insert_Update_tbl_InstituteCourse_Niche(_obj);
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
        public JsonResult SelectNicheCourse(string ID)
        {
            NICHE objRep = new NICHE();

            DataSet ds = objRep.sp_Select_tbl_InstituteCourse_Niche(ID, Session["InstituteID"].ToString(),Session["ParticipatedYear"].ToString());
            List<NicheCourse> _list = new List<NicheCourse>();
            List<mInstituteCourse_EC> _listEC = new List<mInstituteCourse_EC>();
            List<mInstituteCourse_AE> _listAE = new List<mInstituteCourse_AE>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        NicheCourse objNicheCourse = new NicheCourse();
                        objNicheCourse.ID = row["ID"].ToString();
                        objNicheCourse.InstituteID = row["InstituteId"].ToString();
                        objNicheCourse.CourseType = row["CourseType"].ToString();
                        objNicheCourse.Discipline_ID = row["Discipline_ID"].ToString();
                        objNicheCourse.ProgramLevel_Id = row["ProgramLevel_Id"].ToString();
                        objNicheCourse.Natureofcourse_Id = row["Natureofcourse_Id"].ToString();
                        objNicheCourse.Branch_Id = row["Branch_Id"].ToString();
                        objNicheCourse.GenderRestrictions = row["GenderRestrictions"].ToString();
                        objNicheCourse.Discipline = row["Discipline"].ToString();
                        objNicheCourse.Natureofcourse = row["Natureofcourse"].ToString();
                        objNicheCourse.ProgramLevel = row["ProgramLevel"].ToString();
                        objNicheCourse.BranchName = row["BranchName"].ToString();

                        objNicheCourse.AdditionalFacilities = row["AdditionalFacilities"].ToString();
                        objNicheCourse.TutionFeesCurrency = row["TutionFeesCurrency"].ToString();
                        objNicheCourse.TutionFees = row["TutionFees"].ToString();
                        objNicheCourse.TotalFeesCurrency = row["TotalFeesCurrency"].ToString();
                        objNicheCourse.TotalFees = row["TotalFees"].ToString();
                        objNicheCourse.TutionFeesForSAARCCountryCurrency = row["TutionFeesForSAARCCountryCurrency"].ToString();
                        objNicheCourse.TutionFeesForSAARCCountry = row["TutionFeesForSAARCCountry"].ToString();
                        objNicheCourse.TutionFeesForNonSAARCCountryCurrency = row["TutionFeesForNonSAARCCountryCurrency"].ToString();
                        objNicheCourse.TutionFeesForNonSAARCCountry = row["TutionFeesForNonSAARCCountry"].ToString();
                        objNicheCourse.Credits = row["Credits"].ToString();
                        objNicheCourse.CourseDurations = row["CourseDurations"].ToString();
                        objNicheCourse.ClassRoomHours = row["ClassRoomHours"].ToString();
                        objNicheCourse.CoursePatterns = row["CoursePatterns"].ToString();
                        objNicheCourse.StartDate = row["StartDate"].ToString();
                        objNicheCourse.EndDate = row["EndDate"].ToString();
                        objNicheCourse.tobedecided = row["tobedecided"].ToString();
                        objNicheCourse.CourseDesc = row["CourseDesc"].ToString();
                        objNicheCourse.AdmissionReq = row["AdmissionReq"].ToString();
                        objNicheCourse.CourseDurationsType = row["CourseDurationsType"].ToString();

                        objNicheCourse.MedicalFitness = row["MedicalFitness"].ToString();
                        objNicheCourse.MandatoryMedicalExamination = row["MandatoryMedicalExamination"].ToString();
                        objNicheCourse.MedicalFitnessDocuments = row["MedicalFitnessDocuments"].ToString();
                        objNicheCourse.MedicalFitnessDocumentsOther = row["MedicalFitnessDocumentsOther"].ToString();

                        objNicheCourse.HostelAccommodation = row["HostelAccommodation"].ToString();

                        objNicheCourse.MinimumAgeRequirement = row["MinimumAgeRequirement"].ToString();
                        objNicheCourse.NoEligibilitycriteria = row["NoEligibilitycriteria"].ToString();
                        objNicheCourse.MinimumBatchSize = row["MinimumBatchSize"].ToString();
                        objNicheCourse.InternationalBatchSize = row["InternationalBatchSize"].ToString();
                        objNicheCourse.Food = row["Food"].ToString();
                        objNicheCourse.AC = row["AC"].ToString();

                        _list.Add(objNicheCourse);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[1].Rows)
                    {
                        _listEC.Add(new mInstituteCourse_EC
                        {
                            ID = _dr["ID"].ToString(),
                            EduQualifications_Id = _dr["EduQualifications_Id"].ToString(),
                            EduQualifications = _dr["EduQualifications"].ToString(),
                            EduQualificationsFor = _dr["EduQualificationsFor"].ToString(),
                            EduSubject_Id = _dr["EduSubject_Id"].ToString(),
                            EduSubject = _dr["EduSubject"].ToString(),
                            Operator = _dr["Operator"].ToString(),
                            OperatorDisplay = _dr["OperatorDisplay"].ToString(),
                            PercentageID = _dr["PercentageID"].ToString()
                        });
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[2].Rows)
                    {
                        _listAE.Add(new mInstituteCourse_AE
                        {
                            ID = _dr["ID"].ToString(),
                            AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                            AditionalExams = _dr["AditionalExams"].ToString(),
                            //CriteriaDate = _dr["CriteriaDate"].ToString(),
                            AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                            CutOff = _dr["CutOff"].ToString(),
                            Operator = _dr["Operator"].ToString(),
                            OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        });
                        //if (_dr["AditionalExams_Id"].ToString() == "10")
                        //{
                        //    _listAE.Add(new mInstituteCourse_AE
                        //    {
                        //        ID = _dr["ID"].ToString(),
                        //        AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                        //        AditionalExams = _dr["AditionalExams"].ToString(),
                        //        AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                        //        CriteriaDate = Convert.ToDateTime(_dr["CriteriaDate"].ToString()).ToString("dd-MM-yyyy"),
                        //        CutOff = _dr["CutOff"].ToString(),
                        //        Operator = _dr["Operator"].ToString(),
                        //        OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        //    });
                        //}
                        //else
                        //{
                        //    _listAE.Add(new mInstituteCourse_AE
                        //    {
                        //        ID = _dr["ID"].ToString(),
                        //        AditionalExams_Id = _dr["AditionalExams_Id"].ToString(),
                        //        AditionalExams = _dr["AditionalExams"].ToString(),
                        //        //CriteriaDate = _dr["CriteriaDate"].ToString(),
                        //        AditionalExamsFor = _dr["AditionalExamsFor"].ToString(),
                        //        CutOff = _dr["CutOff"].ToString(),
                        //        Operator = _dr["Operator"].ToString(),
                        //        OperatorDisplay = _dr["OperatorDisplay"].ToString()
                        //    });
                        //}
                    }
                }
            }
            return Json(new
            {
                List = _list,
                ListEC = _listEC,
                ListAE = _listAE
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult DeleteNicheCourse(NicheCourse _obj)
        {
            NICHE objRepository = new NICHE();
            _obj.InstituteID = Session["InstituteID"].ToString();
            _obj.ParticipatedYear = Session["ParticipatedYear"].ToString();
            DataSet _ds = objRepository.Delete_tbl_InstituteCourse_Niche(_obj);
            bool flag = false;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["FLAG"].ToString() == "0")
                    {
                        flag = true;
                    }
                }
            }

            return Json(
                    new
                    {
                        flag = flag
                    }
                    , JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}