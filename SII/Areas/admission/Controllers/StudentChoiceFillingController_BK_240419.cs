using Newtonsoft.Json;
using SIIModel.Admin;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.Adminservice;
using SIIRepository.Masterservice;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{

    public class StudentChoiceFillingController_BK : Controller
    {
        // GET: admission/StudentChoiceFilling
        #region Basic
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Basic()
        {
            SIIRepository.StudentRegService.DashboardRepository _objRepository = new SIIRepository.StudentRegService.DashboardRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(Session["studentid"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[1].Rows[0];
                    if (_dr["StudentProfile"].ToString() == "100" && _dr["Background"].ToString() == "100" && Session["AllowChoiceFilling"].ToString().ToLower() == "true")
                    {
                        ViewBag.ActiveWizardTab = "Basic";
                        return View();
                    }
                    else
                    {
                        Session["CH_ERROR_FLAG"] = false;
                        return RedirectToAction("Index", "Dashboard", new { Area = "admission" });
                    }
                }
                else
                {
                    Session["CH_ERROR_FLAG"] = false;
                    return RedirectToAction("Index", "Dashboard", new { Area = "admission" });
                }
            }
            else
            {
                Session["CH_ERROR_FLAG"] = false;
                return RedirectToAction("Index", "Dashboard", new { Area = "admission" });
            }
            //ViewBag.ActiveWizardTab = "Basic";
            //return View();
        }

        [SessionExpireStudentJson]
        public JsonResult FillPercentage()
        {
            Percentage_Repository objRep = new Percentage_Repository();
            DataSet ds = objRep.SELECT_tbl_Percentage();
            List<mPercentage> _list = new List<mPercentage>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        _list.Add(new mPercentage
                        {
                            ID = row["ID"].ToString(),
                            PercentageID = row["PercentageID"].ToString(),
                            Percentage = row["Percentage"].ToString()
                        });
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


        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveBasic(mStudent_Ch_Basic _obj)
        {
            //bool flag = false;
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                DataTable _dt = DeserializeJsonToDataTable(_obj.EduQualifications);
                bool flag = true;
                if (_dt != null)
                {
                    string[] EQIDs = new string[10];
                    int index = 0;
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        EQIDs[index++] = _dr["EQID"].ToString();
                    }
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        if (_dr["EQD"].ToString() != "")
                        {
                            var a1 = _dr["EQD"].ToString().Split(',');
                            foreach (string str1 in a1)
                            {
                                var a2 = str1.Split('|');
                                bool flag2 = false;
                                foreach (string str2 in a2)
                                {
                                    if (EQIDs.Contains(str2))
                                    {
                                        flag2 = true;
                                    }
                                }
                                if (!flag2)
                                {
                                    flag = false;
                                }
                            }
                        }
                    }
                }
                if (flag) {
                    _obj.studentid = Session["studentid"].ToString();
                    DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_Basic(_obj);
                    if (_ds != null)
                    {
                        if (_ds.Tables[0].Rows.Count > 0)
                        {
                            Session["ApplicationNo"] = _ds.Tables[0].Rows[0]["ApplicationNo"].ToString();
                            Message = "Details has been saved successfully!";
                            Code = "success";
                            //flag = true;
                        }
                        else
                        {
                            Message = "Error from server side. Kindly refresh the page and try again.!";
                            Code = "servererror";
                        }
                    }
                }
                else
                {
                    Message = "Kinldy add all relevant qualification's score first.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.!!";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }

        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        public JsonResult SelectBasic()
        {
            List<mStudent_Ch_Basic> _listSCHB = new List<mStudent_Ch_Basic>();
            List<mStudent_Ch_Basic_EC> _listSCHBEC = new List<mStudent_Ch_Basic_EC>();
            List<mStudent_Ch_Basic_AE> _listSCHBAE = new List<mStudent_Ch_Basic_AE>();
            ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
            try
            {
                DataSet _ds = _objRepository.SELECT_tbl_Student_Ch_Basic(Session["studentid"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            Session["ApplicationNo"] = _dr["ApplicationNo"].ToString();
                            _listSCHB.Add(new mStudent_Ch_Basic
                            {
                                ID = _dr["ID"].ToString(),
                                studentid = _dr["studentid"].ToString(),
                                ApplicationNo = _dr["ApplicationNo"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[1].Rows)
                        {
                            _listSCHBEC.Add(new mStudent_Ch_Basic_EC
                            {
                                ID = _dr["ID"].ToString(),
                                EQName = _dr["EQName"].ToString(),
                                IsGiven = _dr["IsGiven"].ToString(),
                                EQID = _dr["EQID"].ToString(),
                                MainPart = _dr["MainPart"].ToString(),
                                DeciamlPart = _dr["DeciamlPart"].ToString()
                            });
                        }
                    }
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[2].Rows)
                        {
                            _listSCHBAE.Add(new mStudent_Ch_Basic_AE
                            {
                                ID = _dr["ID"].ToString(),
                                AEName = _dr["AEName"].ToString(),
                                AEID = _dr["AEID"].ToString(),
                                Score = _dr["Score"].ToString()
                            });
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
                List = _listSCHB,
                ListEC = _listSCHBEC,
                ListAE = _listSCHBAE
            },
                JsonRequestBehavior.AllowGet
            );
        }

        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        public JsonResult CheckBasic(mStudent_Ch_Basic _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                _obj.studentid = Session["studentid"].ToString();
                DataSet _ds = _objRepository.CHECK_tbl_Student_Ch_Basic(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];
                        if (_dr["EC_FLAG"].ToString().ToLower() == "true" && _dr["AE_FLAG"].ToString().ToLower() == "true")
                        {
                            Message = "Details has been saved successfully!";
                            Code = "success";
                        }
                        else
                        {
                            Message = "Any change will reset your filled course choices. More course choice might be available. Do you want to proceed?";
                            Code = "changes";
                        }
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        public JsonResult ResetChoiceFilling(mStudent_Ch_Basic _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                _obj.studentid = Session["studentid"].ToString();
                DataSet _ds = _objRepository.RESET_tbl_Student_Ch_Choice_Filling(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Reset succcessfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public DataTable DeserializeJsonToDataTable(string json)
        {
            var table = JsonConvert.DeserializeObject<DataTable>(json);
            return table;
        }

        #endregion

        #region SelectDisciplines
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult SelectDisciplines()
        {
            ViewBag.ActiveWizardTab = "SelectDisciplines";
            return View();
        }
        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public JsonResult SaveSDicipline(mStudent_Ch_Basic _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                _obj.studentid = Session["studentid"].ToString();
                DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_SelectDiscipline(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Disciplines(s) have been saved successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveProgramLevel(mStudent_Ch_Basic _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                _obj.studentid = Session["studentid"].ToString();
                DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_SelectProgramLevel(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Program Level(s) have been saved successfully!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [SessionExpireStudentJson]
        public JsonResult SelectSDicipline()
        {
            ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
            List<mStudent_Ch_SelectedDisciplines> _listDPL = new List<mStudent_Ch_SelectedDisciplines>();
            try
            {
                DataSet _ds = _objRepository.SELECT_tbl_Student_Ch_SelecedDiscipline(Session["studentid"].ToString(), Session["ApplicationNo"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _listDPL.Add(new mStudent_Ch_SelectedDisciplines
                            {
                                Discipline_ID = _dr["Discipline_ID"].ToString(),
                                ProgrammeLevel_IDs = _dr["ProgrammeLevel_IDs"].ToString()
                            });
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
                sd = _listDPL
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectProgramLevel()
        {
            ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
            string SelectedProgramlevel = "";
            try
            {
                DataSet _ds = _objRepository.SELECT_tbl_Student_Ch_SelecedDiscipline(Session["studentid"].ToString(), Session["ApplicationNo"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            SelectedProgramlevel = _dr["SelectedProgramlevel"].ToString();
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
                sd = SelectedProgramlevel
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Choice Filling
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult ChoiceFilling()
        {
            ViewBag.ActiveWizardTab = "ChoiceFilling";
            return View();
        }
        #region Fill Dropdowns
        [SessionExpireStudentJson]
        public JsonResult SelectPL(string Discipline_ID)
        {
            string Code = string.Empty, Message = string.Empty;
            List<mProgrammeLevel> _list = new List<mProgrammeLevel>();
            try
            {
                //ProgrammeLevel_Repository _objRepo = new ProgrammeLevel_Repository();
                ChoiceFillingRepository _objRepo = new ChoiceFillingRepository();
                DataSet _ds = _objRepo.SELECT_PROGRAMELEVEL_FROM_DISCIPLINE_FOR_CH(Session["studentid"].ToString(), Session["ApplicationNo"].ToString(), Discipline_ID, "ChoiceFilling");
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
        [SessionExpireStudentJson]
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
        [SessionExpireStudentJson]
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
        #endregion
        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveStdCh(mStudent_Ch_Choice_Filling_Save _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                if (Session["ApplicationNo"] != null)
                {
                    if (Session["ApplicationNo"].ToString() != "")
                    {
                        _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                    }
                }
                _obj.studentid = Session["studentid"].ToString();
                DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_Choice_Filling(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["msg"].ToString() == "Success")
                        {
                            Message = "Choice have been saved successfully!";
                            Code = "success";
                        }
                        else if (_ds.Tables[0].Rows[0]["msg"].ToString() == "NotEligible")
                        {
                            Message = "You are not eligible for this course!";
                            Code = "servererror";
                        }
                        else
                        {
                            Message = "Error from server side. Kindly refresh the page and try again.";
                            Code = "servererror";
                        }
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [SessionExpireStudentJson]
        public JsonResult SelectStdCh()
        {
            mStudent_Ch_Choice_Filling_Save _obj = new mStudent_Ch_Choice_Filling_Save();
            string Code = string.Empty, Message = string.Empty;
            if (Session["ApplicationNo"] != null)
            {
                if (Session["ApplicationNo"].ToString() != "")
                {
                    _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                }
            }
            _obj.studentid = Session["studentid"].ToString();
            List<mStudent_Ch_Choice_Filling_Saved_List> _list = new List<mStudent_Ch_Choice_Filling_Saved_List>();
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                DataSet _ds = _objRepository.SELECT_tbl_Student_Ch_Choice_Filling(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mStudent_Ch_Choice_Filling_Saved_List
                            {
                                id = _dr["ID"].ToString(),
                                InstituteName = _dr["InstituteName"].ToString(),
                                InstituteCourseName = _dr["Coursename"].ToString(),
                                InstituteType = _dr["InstituteType"].ToString(),
                                Discipline = _dr["Discipline"].ToString(),
                                ProgramLevel = _dr["ProgramLevel"].ToString(),
                                Coursename = _dr["Coursename"].ToString(),
                                Specialization = _dr["Specialization"].ToString(),
                                SequenceNumber = _dr["SequenceNumber"].ToString()
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
        [HttpPost]
        [SessionExpireStudentJson]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteStdCh(string id = "0")
        {
            mStudent_Ch_Choice_Filling_Save _obj = new mStudent_Ch_Choice_Filling_Save();
            string Code = string.Empty, Message = string.Empty;
            if (Session["ApplicationNo"] != null)
            {
                if (Session["ApplicationNo"].ToString() != "")
                {
                    _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                }
            }
            _obj.studentid = Session["studentid"].ToString();
            List<mStudent_Ch_Choice_Filling_Saved_List> _list = new List<mStudent_Ch_Choice_Filling_Saved_List>();
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                DataSet _ds = _objRepository.DELETE_tbl_Student_Ch_Choice_Filling(id, Session["ApplicationNo"].ToString(), Session["studentid"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Code = "success";
                        Message = "Choice has been deleted successfully.";
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

        #region Choice Priority
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Rank()
        {
            ViewBag.ActiveWizardTab = "Rank";
            return View();
        }
        public JsonResult SWAPRank(mStudent_Ch_Choice_Filling_Swap obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            //obj.Type = "SWAP";
            if (Session["ApplicationNo"] != null)
            {
                if (Session["ApplicationNo"].ToString() != "")
                {
                    obj.ApplicationNo = Session["ApplicationNo"].ToString();
                }
            }
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            obj.CreatedIp = localIP;
            obj.studentid = Session["studentid"].ToString();
            DataSet _ds = objRep.SWAP_tbl_Student_Ch_Choice_Filling(obj);
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

        #region UploadDocs
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult UploadDocs()
        {
            ViewBag.ActiveWizardTab = "UploadDocs";
            return View();
        }
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadDocs(string id = "", string name = "")
        {
            mStudent_Ch_Doc_Upload _obj = new mStudent_Ch_Doc_Upload();
            string Message = string.Empty, Code = string.Empty;
            try
            {
                string path = "";
                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/";
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        name = name.Trim().Replace(" / ", "_");
                        name = name.Trim().Replace(" ", "_");
                        filename = name + "_" + Session["ApplicationNo"].ToString() + Path.GetExtension(file.FileName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {
                            string[] curentfiles = Directory.GetFiles(path);
                            foreach (string curentfile in curentfiles)
                            {
                                if (curentfile.IndexOf(filename) >= 0)
                                    System.IO.File.Delete(curentfile);
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/"), filename);
                        file.SaveAs(fname);
                        _obj.Path = "Uploads/studentDocument/" + Session["studentid"].ToString() + "/" + Session["ApplicationNo"].ToString() + "/" + filename;
                    }
                    else
                    {
                        _obj.Path = "";
                    }
                }
                else
                {
                    _obj.Path = "";
                }
                if (_obj.Path != "")
                {
                    Message = "Document uploaded successfully!";
                    Code = "success";
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {

                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }

            return Json(new
            {
                m = Message,
                c = Code,
                p = _obj.Path
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [CloseStudentChoiceFillingJson]
        [SessionExpireStudentJson]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveUploadDocs(string Docs = "")
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                DataSet _ds = _objRepository.INSERT_UPDATE_tbl_Student_Ch_Doc_Upload(Session["ApplicationNo"].ToString(), Session["studentid"].ToString(), Docs, localIP);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Documents have been uploaded!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Submit
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Submit()
        {
            ViewBag.ActiveWizardTab = "Submit";
            return View();
        }
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SubmitChoices()
        {
            string Message = string.Empty, Code = string.Empty;
            try
            {
                ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                DataSet _ds = _objRepository.Submit_Student_Ch(Session["studentid"].ToString(), localIP);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Session["submitChoiceFill"] = "True";
                        Message = "Your Choices have been successfully submitted..!!!";
                        Code = "success";
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
                    }
                }
            }
            catch (NullReferenceException)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
            }
            catch (Exception)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Closed
        [SessionExpireStudent]
        public ActionResult Closed()
        {
            return View();
        }
        public JsonResult CloseJson()
        {
            string Message = string.Empty, Code = string.Empty;
            Message = "Student choice filling has been closed.";
            Code = "ChoiceFillingClosed";
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SubmittedJson()
        {
            string Message = string.Empty, Code = string.Empty;
            Message = "You choice filing is already submitted.";
            Code = "ChSubmitted";
            return Json(new
            {
                m = Message,
                c = Code
            },
                JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Choice Filling New
        public ActionResult _FillChoiceGrid(mStudent_ch_choiceFilling obj)
        {
            if (Session["studentid"] == null)
            {
                return PartialView("_SessionExpired");
            }
            return PartialView(obj);
        }
        public ActionResult _SessionExpired()
        {
            return PartialView();
        }
        public ActionResult _FillElegibilityCriteria(mStudent_ch_choiceFilling obj)
        {
            if (Session["studentid"] == null)
            {
                return PartialView("_SessionExpired");
            }
            return PartialView(obj);
        }
        #endregion

        #region Report
        [NoDirectAccessLearner]
        [SessionExpireStudent]
        public ActionResult Report()
        {

            return View();
        }
        #endregion
    }
}