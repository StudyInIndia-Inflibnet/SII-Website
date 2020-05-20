using CCA.Util;
using Newtonsoft.Json;
using SIIModel.Admin;
using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.Adminservice;
using SIIRepository.Masterservice;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class StudentChoiceFillingController : Controller
    {
        // GET: admission/StudentChoiceFilling
        #region Basic
        [NoDirectAccessLearner]
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        public ActionResult Basic()
        {
            SIIRepository.StudentRegService.DashboardRepository _objRepository = new SIIRepository.StudentRegService.DashboardRepository();
            DataSet _ds = _objRepository.Get_Dashboard_Data(Session["studentid"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    DataRow _dr = _ds.Tables[1].Rows[0];
                    if (_dr["StudentProfile"].ToString() == "100" && _dr["Background"].ToString() == "100" && Session["AllowChoiceFilling"].ToString().ToLower() == "true" && Session["submitChoiceFill"].ToString().ToLower() != "true")
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
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
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
                //DataTable _dt = DeserializeJsonToDataTable(_obj.EduQualifications);
                bool flag = true;
                //if (_dt != null)
                //{
                //    string EQIDs = string.Empty;
                //    int index = 0;
                //    foreach (DataRow _dr in _dt.Rows)
                //    {
                //        if (index > 0)
                //        {
                //            EQIDs = EQIDs + ",";
                //        }
                //        EQIDs = EQIDs + _dr["EQID"].ToString();
                //        index++;
                //    }
                //    var aEQID = EQIDs.Split(',');
                //    foreach (DataRow _dr in _dt.Rows)
                //    {
                //        if (_dr["EQD"].ToString() != "")
                //        {
                //            var a1 = _dr["EQD"].ToString().Split(',');
                //            foreach (string str1 in a1)
                //            {
                //                var a2 = str1.Split('|');
                //                bool flag2 = false;
                //                foreach (string str2 in a2)
                //                {
                //                    if (aEQID.Contains(str2))
                //                    {
                //                        flag2 = true;
                //                    }
                //                }
                //                if (!flag2)
                //                {
                //                    flag = false;
                //                }
                //            }
                //        }
                //    }
                //}
                if (flag)
                {
                    System.GC.Collect();
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
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.!!";
                Code = "servererror";
                Error = ex.Message;
            }
            return Json(new
            {
                m = Message,
                c = Code,
                e = Error
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
                                IsGiven = _dr["IsGiven"].ToString(),
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
        public DataTable DeserializeJsonToDataTable(string json = "")
        {
            DataTable table = JsonConvert.DeserializeObject<DataTable>(json);
            return table;
        }
        #endregion

        #region SelectDisciplines
        [NoDirectAccessLearner]
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
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
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
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

        [SessionExpireStudentJson]
        [CloseStudentChoiceFillingJson]
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
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
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
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
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
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
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
                        name = name.Trim().Replace("/", "");
                        name = name.Trim().Replace(" ", "");
                        name = name.Trim().Replace("//", "_");
                        name = name.Trim().Replace("(", "_");
                        name = name.Trim().Replace(")", "_");
                        name = name.Trim().Replace(",", "");
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
            catch (Exception ex)
            {
                Error = ex.Message;
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
            }

            return Json(new
            {
                m = Message,
                c = Code,
                p = _obj.Path,
                e = Error
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

        #region Payment
        //[NoDirectAccessLearner]
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        public ActionResult Payment()
        {
            mStudentPayment _obj = new mStudentPayment
            {
                Type = "Select",
                StudentID = Session["studentid"].ToString()
            };
            StudentPaymentRepository _objRepository = new StudentPaymentRepository();
            DataSet _ds = _objRepository.OPR_STUDENT_PAYMENT(_obj);
            if (_ds != null)
            {

                if (_ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[2].Rows)
                    {
                        Session["Amount"] = _dr["Amount"].ToString();
                        Session["currency"] = _dr["Currency"].ToString();
                    }
                }
                else
                {
                    return Redirect("~/admission/Dashboard");
                }
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        Session["OrderID"] = _dr["OrderID"].ToString();
                        Session["TransactionStatus"] = _dr["TransactionStatus"].ToString();
                        Session["Amount"] = _dr["Amount"].ToString();
                        Session["currency"] = _dr["currency"].ToString();
                        Session["BankRefNo"] = _dr["BankRefNo"].ToString();
                    }
                }
                else
                {
                    if (Session["TransactionStatus"] == null)
                    {
                        Session["TransactionStatus"] = "Pending";
                    }
                    Session["OrderID"] = "O_" + DateTime.Now.ToString("MMddyyyyHHmmss");
                }

            }
            else
            {
                if (Session["TransactionStatus"] == null)
                {
                    Session["TransactionStatus"] = "Pending";
                }
                Session["OrderID"] = "O_" + DateTime.Now.ToString("MMddyyyyHHmmss");
                Session["Amount"] = "2";
                Session["currency"] = "USD";
            }
            Session["merchant_id"] = "235907";

            Session["redirect_url"] = FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/StudentChoiceFilling/RedirectUrl";
            Session["cancel_url"] = FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "admission/StudentChoiceFilling/RedirectUrl";
            ViewBag.ActiveWizardTab = "Payment";
            return View();
        }

        #region Create Objects for Payment
        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = "9013F7151DCEBCA81147F88024A6CEB4";//put in the 32bit alpha numeric key in the quotes provided here 	
        string ccaRequest = "";
        public string strEncRequest = "";
        public string strAccessCode = "AVUJ88GJ37BN79JUNB";// put the access key in the quotes provided here.
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireStudent]
        public ActionResult PaymentRequest()
        {
            string paymentCurrency = Session["currency"].ToString();
            string paymentAmount = Session["Amount"].ToString();

            //ccaRequest = "merchant_id=" + Session["merchant_id"].ToString() + "&order_id=" + Session["OrderID"].ToString() + "&amount=" + paymentAmount + "&currency=" + paymentCurrency + "&redirect_url=" + Session["redirect_url"].ToString() + "&cancel_url=" + Session["cancel_url"].ToString() + "&billing_name=" + Session["studentname"].ToString() + "&billing_address=" + Session["Addressline1"].ToString() + "&billing_city=" + Session["City_name"].ToString() + "&billing_state=" + Session["State_name"].ToString() + "&billing_zip=" + Session["Area"].ToString() + "&billing_country=" + Session["Country_Name"].ToString() + "&billing_tel=" + Session["Mobile"].ToString() + "&billing_email=" + Session["Email"].ToString() + "&delivery_name=" + Session["studentname"].ToString() + "&delivery_address=" + Session["Addressline1"].ToString() + "&delivery_city=" + Session["City_name"].ToString() + "&delivery_state=" + Session["State_name"].ToString() + "&delivery_zip=" + Session["Area"].ToString() + "&delivery_country=" + Session["Country_Name"].ToString() + "&delivery_tel=" + Session["Mobile"].ToString() + "&";

            ccaRequest = "merchant_id=" + Session["merchant_id"].ToString() + "&order_id=" + Session["OrderID"].ToString() + "&redirect_url=" + Session["redirect_url"].ToString() + "&cancel_url=" + Session["cancel_url"].ToString() + "&billing_name=" + Session["studentname"].ToString() + "&billing_address=" + Session["Addressline1"].ToString() + "&billing_city=" + Session["City_name"].ToString() + "&billing_state=" + Session["State_name"].ToString() + "&billing_zip=" + Session["Area"].ToString() + "&billing_country=" + Session["Country_Name"].ToString() + "&billing_tel=" + Session["Mobile"].ToString() + "&billing_email=" + Session["Email"].ToString() + "&delivery_name=" + Session["studentname"].ToString() + "&delivery_address=" + Session["Addressline1"].ToString() + "&delivery_city=" + Session["City_name"].ToString() + "&delivery_state=" + Session["State_name"].ToString() + "&delivery_zip=" + Session["Area"].ToString() + "&delivery_country=" + Session["Country_Name"].ToString() + "&delivery_tel=" + Session["Mobile"].ToString() + "&";

            if (Request.Form != null)
            {
                if (Request.Form["CardIssuedType"] == "FromIndia")
                {
                    paymentCurrency = "INR";
                    paymentAmount = "140";
                    //ccaRequest = ccaRequest + "amount=" + paymentAmount + "&currency=" + paymentCurrency + "&tid=76034918&";

                    ccaRequest = ccaRequest + "amount=" + paymentAmount + "&currency=" + paymentCurrency + "&";
                }
                else
                {
                    paymentCurrency = "USD";
                    paymentAmount = "2";
                    //ccaRequest = ccaRequest + "amount=" + paymentAmount + "&currency=" + paymentCurrency + "&tid=79021790&";
                    ccaRequest = ccaRequest + "amount=" + paymentAmount + "&currency=" + paymentCurrency + "&";
                }
            }

            foreach (string name in Request.Form)
            {
                if (name != null)
                {
                    if (!name.StartsWith("_"))
                    {
                        if (name != "CardIssuedType")
                        {
                            ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";
                        }
                        /* Response.Write(name + "=" + Request.Form[name]);
                          Response.Write("</br>");*/
                    }
                }
            }

            string strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
            mStudentPayment _obj = new mStudentPayment
            {
                Type = "Insert",
                StudentID = Session["studentid"].ToString(),
                OrderID = Session["OrderID"].ToString(),
                Amount = paymentAmount,
                Currency = paymentCurrency,
                //TransactionStatus = Session["TransactionStatus"].ToString(),
                RequestedXMLContent = ccaRequest,
                CreatedIP = Session["localIP"].ToString(),
            };
            StudentPaymentRepository _objRepository = new StudentPaymentRepository();
            DataSet _ds = _objRepository.OPR_STUDENT_PAYMENT(_obj);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                    {

                    }
                }
            }
            ViewBag.strEncRequest = strEncRequest;
            ViewBag.strAccessCode = strAccessCode;
            return View();
        }

        public ActionResult RedirectUrl()
        {
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }
            string finalValue = "";
            for (int i = 0; i < Params.Count; i++)
            {
                finalValue = finalValue + Params.Keys[i] + " = " + Params[i] + "<br>";
            }
            Session["TransactionStatus"] = Params["order_status"];
            Session["BankRefNo"] = Params["bank_ref_no"];

            Session["OrderID"] = Params["order_id"];

            #region Refill Sessions
            StudentRepository _objRepository = new StudentRepository();
            Student_Register _obj = new Student_Register { studentid = Params["merchant_param1"] };
            DataSet ds = _objRepository.Login_Student(_obj);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Session["studentid"] = dr["studentid"].ToString();


                    Session["studentname"] = dr["studentname"].ToString();
                    Session["Email"] = dr["Email"].ToString();
                    Session["Mobile"] = dr["Mobile"].ToString();
                    Session["StudentProfilePic"] = "/assets/img/avatar.png";
                    Session["submitChoiceFill"] = dr["submitChoiceFill"].ToString();
                    Session["EditApplication"] = dr["EditApplication"].ToString();
                    Session["IsPasswordChanged"] = dr["IsPasswordChanged"].ToString();
                    Session["ischangedpassword"] = dr["ischangedpassword"].ToString();
                    Session["IsSeatAlloted"] = dr["IsSeatAlloted"].ToString();
                    Session["IsAllowEditData"] = dr["IsAllowEditData"].ToString();
                    Session["AllowChoiceFilling"] = dr["AllowChoiceFilling"].ToString();
                    Session["CountryID"] = dr["CountryID"].ToString();
                    Session["OpenChoiceFilling_"] = dr["OpenChoiceFilling_"].ToString();
                    Session["IndividualOpenChoiceFilling_"] = dr["IndividualOpenChoiceFilling_"].ToString();
                    Session["ApplyingForCourse"] = dr["ApplyingForCourse"].ToString();
                    Session["isTestStudent"] = dr["isTestStudent"].ToString();
                    Session["SCH_UG"] = "No";
                    Session["SCH_PG"] = "No";
                    Session["SCH_PhD"] = "No";
                    string localIP = "?";
                    localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    Session["localIP"] = localIP;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[1].Rows)
                    {
                        if (_dr["AddressType"].ToString() == "Residential")
                        {
                            Session["Addressline1"] = _dr["Addressline1"].ToString();
                            Session["Addressline2"] = _dr["Addressline2"].ToString();
                            Session["State_name"] = _dr["State_name"].ToString();
                            Session["City_name"] = _dr["City_name"].ToString();
                            Session["Area"] = _dr["Area"].ToString();
                            Session["Country_Name"] = _dr["Country_Name"].ToString();
                        }
                    }
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[3].Rows[0];
                    Session["SCH_UG"] = dr["UG"].ToString();
                    Session["SCH_PG"] = dr["PG"].ToString();
                    Session["SCH_PhD"] = dr["PhD"].ToString();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[4].Rows)
                    {
                        if (_dr["ProgrammeLevel"].ToString() == "UG")
                        {
                            Session["UG_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                        }
                        else if (_dr["ProgrammeLevel"].ToString() == "PG")
                        {
                            Session["PG_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                        }
                        else if (_dr["ProgrammeLevel"].ToString() == "PhD")
                        {
                            Session["PhD_ReEdit_DateTime"] = _dr["ClosingDate"].ToString();
                        }
                    }
                }
            }
            ChoiceFillingRepository _objRepository_CH = new ChoiceFillingRepository();
            DataSet _ds_ch = _objRepository_CH.SELECT_tbl_Student_Ch_Basic(Session["studentid"].ToString());
            if (_ds_ch != null)
            {
                if (_ds_ch.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds_ch.Tables[0].Rows)
                    {
                        Session["ApplicationNo"] = _dr["ApplicationNo"].ToString();
                    }
                }
            }
            #endregion

            #region Update Payment Status 
            mStudentPayment _objPayment = new mStudentPayment
            {
                Type = "Update",
                StudentID = Session["studentid"].ToString(),
                OrderID = Session["OrderID"].ToString(),
                TransactionStatus = Session["TransactionStatus"].ToString(),
                BankRefNo = Session["BankRefNo"].ToString(),
                ResponseContent = encResponse,
                CreatedIP = Session["localIP"].ToString(),
            };
            StudentPaymentRepository _objRepo = new StudentPaymentRepository();
            DataSet _dsPayment = _objRepo.OPR_STUDENT_PAYMENT(_objPayment);
            if (_dsPayment != null)
            {
                if (_dsPayment.Tables[0].Rows.Count > 0)
                {
                    if (_dsPayment.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                    {

                    }
                }
            }
            #endregion

            ViewBag.finalValue = finalValue;
            //return View();
            return Redirect("~/admission/StudentChoiceFilling/Payment");
        }
        #endregion

        #region Submit
        [NoDirectAccessLearner]
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        public ActionResult Submit()
        {
            ViewBag.ActiveWizardTab = "Submit";
            return View();
        }
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadDoc(string id)
        {
            string Message = string.Empty, Code = string.Empty, finalPath = string.Empty, Error = string.Empty;
            try
            {
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        BinaryReader _br = new BinaryReader(Request.Files[0].InputStream);
                        byte[] bytes = _br.ReadBytes((int)Request.Files[0].InputStream.Length);

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        finalPath = base64String;

                        ChoiceFillingRepository _objRepo = new ChoiceFillingRepository();
                        DataSet _ds = _objRepo.Opr_Upload_Student_Image(new Student_Register { studentid = Session["studentid"].ToString(), Photo = finalPath, Signature = finalPath, Type = id });
                        if (_ds != null)
                        {
                            if (_ds.Tables[0].Rows.Count > 0)
                            {
                                Message = id + " uploaded successfully!";
                                Code = "success";
                                Session["" + id + ""] = finalPath;
                            }
                            else
                            {
                                finalPath = "";
                                Message = "Error occured while uploading " + id + "!";
                                Code = "servererror";
                            }
                        }
                        else
                        {
                            finalPath = "";
                            Message = "Error occured while uploading " + id + "!";
                            Code = "servererror";
                        }
                    }
                    else
                    {
                        finalPath = "";
                        Message = "Error occured while uploading " + id + "!";
                        Code = "servererror";
                    }
                }
                else
                {
                    finalPath = "";
                    Message = "Error occured while uploading " + id + "!";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException ex)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
                Error = ex.Message;
            }

            return Json(new
            {
                m = Message,
                c = Code,
                e = Error,
                p = finalPath,
                f = (Session["Photo"].ToString() != "" && Session["Signature"].ToString() != "" ? true : false)
            },
                JsonRequestBehavior.AllowGet
            );
        }
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SubmitChoices()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            mWebhook _response = null;
            try
            {
                if (Session["Photo"].ToString() != "" && Session["Signature"].ToString() != "")
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
                            //Message = "Your Choices have been successfully submitted..!!!";
                            //Code = "success";
                            SendEmail _objseedemail = new SendEmail();
                            Session["submitchoiceDate"] = _ds.Tables[0].Rows[0]["submitchoiceDate"].ToString();
                            //string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername1"];
                            //string Subject = "Choice Filling Submitted";
                            //StringBuilder MailBody = new StringBuilder();
                            //MailBody.Append("<br/>Dear " + Session["studentname"].ToString() + ",<br/>");
                            //MailBody.Append("<br/>You have successfully submitted your application for Study In India. Refer to the website for results declaration and other important dates.");
                            //MailBody.Append("<br/><br/><br/>Regards,<br/>");
                            //MailBody.Append("Study in India Team<br/>");
                            //string bcc = "";
                            //string cc = "";
                            //_objseedemail.SendEmailInBackgroundThread(strform, Session["Email"].ToString(), bcc, cc, Subject, MailBody.ToString(), "", true);

                            #region Call PivotRoots Code
                            string strUrl = "https://pivotroots.com/clients/studyinindia/webhooks/user_events";
                            WebRequest request = HttpWebRequest.Create(strUrl);
                            request.Headers.Add("Request-Id", DateTime.Now.ToString("yyyyMMddhhmmss"));
                            request.Method = "POST";
                            request.ContentType = "application/json";
                            request.Headers.Add("Client-Id", "b7a51eff57749dc0e733b74342c8b512");
                            request.Headers.Add("Client-Access-Token", "dfdd5aa8ea4a1e2fb5999dc213476c2a9b68efa7");
                            mWebhookRequestSubmission _objJsonRequest = new mWebhookRequestSubmission()
                            {
                                timestamp = DateTime.Now.ToString("yyyyMMddhhmmss"),
                                user_id = Session["studentid"].ToString(),
                                @event = "submission",
                                userName = Session["studentname"].ToString(),
                                emailID = Session["Email"].ToString()
                            };
                            string data = JsonConvert.SerializeObject(_objJsonRequest);
                            byte[] dataStream = Encoding.UTF8.GetBytes(data);
                            request.ContentLength = dataStream.Length;
                            Stream r = request.GetRequestStream();
                            r.Write(dataStream, 0, dataStream.Length);
                            r.Close();
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream s = (Stream)response.GetResponseStream();
                            StreamReader readStream = new StreamReader(s);
                            string dataString = readStream.ReadToEnd();
                            _response = JsonConvert.DeserializeObject<mWebhook>(dataString);
                            if (_response.reason == "SUCCESS")
                            {
                                Message = "Your Choices have been successfully submitted..!!!";
                                Code = "success";
                            }
                            else
                            {
                                Message = "Error from server side. Kindly refresh the page and try again.";
                                Code = "servererror";
                            }
                            
                            response.Close();
                            s.Close();
                            readStream.Close();
                            #endregion
                        }
                        else
                        {
                            Message = "Error from server side. Kindly refresh the page and try again.";
                            Code = "servererror";
                        }
                    }
                }
                else
                {
                    Message = "Please upload photo and signature first!";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException ex)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
                Error = ex.Message;
            }
            return Json(new
            {
                m = Message,
                c = Code,
                e = Error
                //r = _response
            },
                JsonRequestBehavior.AllowGet
            );
        }

        [NoDirectAccessLearner]
        [SessionExpireStudent]
        [CloseStudentChoiceFilling]
        public ActionResult Submitted()
        {
            ViewBag.ActiveWizardTab = "Submit";
            return View();
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
        public JsonResult FillChoiceGrid(mStudent_ch_choiceFilling obj)
        {
            ChoiceFillingRepository _objRepository = new SIIRepository.StudentRegService.ChoiceFillingRepository();
            obj.ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            obj.studentID = Session["studentid"].ToString();
            obj.Type = "Fill_choicefilling";
            List<mStudent_ch_choiceFilling_result> _list = new List<mStudent_ch_choiceFilling_result>();
            DataSet _ds = _objRepository.Student_Ch_Choice_Filling_From(obj);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    int index = 0;
                    foreach (System.Data.DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _list.Add(new mStudent_ch_choiceFilling_result
                        {
                            ID = _dr["ID"].ToString(),
                            Srno = (++index).ToString(),
                            InstituteID = _dr["InstituteID"].ToString(),
                            InstituteName = _dr["InstituteName"].ToString(),
                            InstituteType = _dr["InstituteType"].ToString(),
                            Discipline = _dr["Discipline"].ToString(),
                            ProgramLevel = _dr["ProgramLevel"].ToString(),
                            Coursename = _dr["Coursename"].ToString(),
                            Specialization = _dr["Specialization"].ToString(),
                            Eligibility = _dr["Eligibility"].ToString(),
                            AdditionalEligibility = _dr["AdditionalEligibility"].ToString()
                        });
                    }
                }
            }
            var jsonResult = Json(new
            {
                data = _list
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
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

#pragma warning disable SCS0029 // Potential XSS vulnerability
        public string FullyQualifiedApplicationPath(HttpRequestBase httpRequestBase)
#pragma warning restore SCS0029 // Potential XSS vulnerability
        {
            string appPath = string.Empty;

            if (httpRequestBase != null)
            {
                //Formatting the fully qualified website url/name
                appPath = string.Format("{0}://{1}{2}{3}",
                            httpRequestBase.Url.Scheme,
                            httpRequestBase.Url.Host,
                            httpRequestBase.Url.Port == 80 ? string.Empty : ":" + httpRequestBase.Url.Port,
                            httpRequestBase.ApplicationPath);
            }

            if (!appPath.EndsWith("/"))
            {
                appPath += "/";
            }

            return appPath;
        }
    }
}