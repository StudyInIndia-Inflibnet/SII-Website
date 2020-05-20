using ClosedXML.Excel;
using SII.Models;
using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class Phase2Controller : Controller
    {
        // GET: Admin/Phase2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string id = "All")
        {
            ViewBag.For = id;
            return View();
        }
        public ActionResult All()
        {
            return View();
        }
        public ActionResult ProgrammeType()
        {
            return View();
        }
        public ActionResult Details(string p = "", string pf = "")
        {
            ViewBag.For = pf;
            ViewBag.Value = p;
            return View();
        }
        public ActionResult ChoiceFilling(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult ChoiceFillingTest(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult ChoiceFillingTestList(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult Merit(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult Alloted(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult Country(string id = "")
        {
            ViewBag.Value = id;
            return View();
        }
        public ActionResult CountryWise(string id = "", string c = "")
        {
            ViewBag.Value = id;
            ViewBag.Country = c;
            return View();
        }
        public ActionResult CountryWiseList(string id = "", string p = "", string c = "", string a = "")
        {
            ViewBag.Value = id;
            ViewBag.ProgrammeLevel = p;
            ViewBag.Country = c;
            ViewBag.Alloted = a;
            return View();
        }


        #region Reports 
        public ActionResult Reports()
        {
            #region Registered Students
            ReportsRepository _objRepo = new ReportsRepository();
            DataSet _ds = _objRepo.SELECT_PHASE2_KPI_REGISTERED_STUDENTS("Count");
            ViewBag.RegisteredStudents = 0;
            ViewBag.ParticipatedCountries = 0;
            ViewBag.ConsideredStudents = 0;
            ViewBag.AllottedStudents = 0;
            if (_ds != null)
            {
                DataRow _dr = _ds.Tables[0].Rows[0];
                ViewBag.RegisteredStudents = _dr["Counts"].ToString();
                ViewBag.ParticipatedCountries = _dr["Country"].ToString();
                ViewBag.ConsideredStudents = _dr["Considered"].ToString();
                ViewBag.AllottedStudents = _dr["Allotted"].ToString();
            }
            #endregion

            #region Counselling_Overview
            ReportsRepository _objRepoC = new ReportsRepository();
            DataSet _dsC = _objRepo.SELECT_PHASE2_KPI_Counselling_Overview("Count");
            ViewBag.UG_SeatAlloted = 0;
            ViewBag.PG_SeatAlloted = 0;
            ViewBag.PHD_SeatAlloted = 0;

            ViewBag.UG_NoSeatAlloted = 0;
            ViewBag.PG_NoSeatAlloted = 0;
            ViewBag.PHD_NoSeatAlloted = 0;

            ViewBag.UG_NoSeatAlloted_Common = 0;
            ViewBag.PG_NoSeatAlloted_Common = 0;
            ViewBag.PHD_NoSeatAlloted_Common = 0;

            ViewBag.UG_ConsiderStudent = 0;
            ViewBag.PG_ConsiderStudent = 0;
            ViewBag.PHD_ConsiderStudent = 0;

            ViewBag.TotalSc = 0;
            ViewBag.TotalSIISc_PG = 0;
            ViewBag.TotalSIISc_UG = 0;
            ViewBag.TotalAfricaSc_PG = 0;
            ViewBag.TotalAfricaSc_UG = 0;
            ViewBag.TotalCountrySc_UG = 0;
            ViewBag.TotalCountrySc_PG = 0;
            ViewBag.TotalCountrySc = 0;


            ViewBag.UG2_SeatAlloted = 0;
            ViewBag.UG2_ConsiderStudent = 0;
            ViewBag.UG2_NoSeatAlloted = 0;
            ViewBag.UG2_NoSeatAlloted_Common = 0;

            if (_dsC != null)
            {
                DataRow _drC = _dsC.Tables[0].Rows[0];
                ViewBag.UG_SeatAlloted = _drC["UG_SeatAlloted"].ToString();
                ViewBag.PG_SeatAlloted = _drC["PG_SeatAlloted"].ToString();
                ViewBag.PHD_SeatAlloted = _drC["PHD_SeatAlloted"].ToString();

                ViewBag.UG_NoSeatAlloted = _drC["UG_NoSeatAlloted"].ToString() ;
                ViewBag.PG_NoSeatAlloted = _drC["PG_NoSeatAlloted"].ToString() ;
                ViewBag.PHD_NoSeatAlloted = _drC["PHD_NoSeatAlloted"].ToString();

                ViewBag.UG_NoSeatAlloted_Common = _drC["UG_NoSeatAlloted_Common"].ToString();
                ViewBag.PG_NoSeatAlloted_Common = _drC["PG_NoSeatAlloted_Common"].ToString();
                ViewBag.PHD_NoSeatAlloted_Common = _drC["PHD_NoSeatAlloted_Common"].ToString();

                ViewBag.UG_ConsiderStudent = _drC["UG_ConsiderStudent"].ToString();
                ViewBag.PG_ConsiderStudent = _drC["PG_ConsiderStudent"].ToString();
                ViewBag.PHD_ConsiderStudent = _drC["PHD_ConsiderStudent"].ToString();

                ViewBag.TotalSc = _drC["TotalSc"].ToString(); ;
                ViewBag.TotalSIISc_PG = _drC["TotalSIISc_PG"].ToString(); ;
                ViewBag.TotalSIISc_UG = _drC["TotalSIISc_UG"].ToString(); ;
                ViewBag.TotalAfricaSc_PG = _drC["TotalAfricaSc_PG"].ToString(); ;
                ViewBag.TotalAfricaSc_UG = _drC["TotalAfricaSc_UG"].ToString(); ;
                ViewBag.TotalCountrySc_UG = _drC["TotalCountrySc_UG"].ToString(); ;
                ViewBag.TotalCountrySc_PG = _drC["TotalCountrySc_PG"].ToString(); ;
                ViewBag.TotalCountrySc = _drC["TotalCountrySc"].ToString(); ;

                ViewBag.UG2_SeatAlloted = _drC["UG2_SeatAlloted"].ToString(); ;
                ViewBag.UG2_ConsiderStudent = _drC["UG2_ConsiderStudent"].ToString(); ;
                ViewBag.UG2_NoSeatAlloted = _drC["UG2_NoSeatAlloted"].ToString(); ;
                ViewBag.UG2_NoSeatAlloted_Common = _drC["UG2_NoSeatAlloted_Common"].ToString(); ;

            }
            #endregion

            #region INSTITUTE OVERVIEW
            ReportsRepository _objRepo_ = new ReportsRepository();
            DataSet _ds_ = _objRepo.SELECT_PHASE2_KPI_Institute_Overview_("Count");
            ViewBag.Regint = 0;
            ViewBag.Allotedint = 0;
            ViewBag.AproveStudent = 0;
            ViewBag.OfferAcept = 0;
            ViewBag.AdmittedStudents = 0;
            ViewBag.TotalCourse = 0;
            ViewBag.TotalSeat = 0;

            ViewBag.InsRejectTotal = 0;
            ViewBag.InsRejectUG = 0;
            ViewBag.InsRejectPG = 0;
            ViewBag.InsRejectPHD = 0;
            if (_ds_ != null)
            {
                DataRow _dr_ = _ds_.Tables[0].Rows[0];
                ViewBag.Regint = _dr_["Regint"].ToString();
                ViewBag.TotalCourse = _dr_["TotalCourse"].ToString();
                ViewBag.TotalSeat = _dr_["TotalSeat"].ToString();

                ViewBag.Allotedint = _dr_["AllotedintTotal"].ToString();
                ViewBag.AllotedintUG = _dr_["AllotedintUG"].ToString();
                ViewBag.AllotedintPG = _dr_["AllotedintPG"].ToString();
                ViewBag.AllotedintPHD = _dr_["AllotedintPHD"].ToString();


                ViewBag.InsApproveTotal = _dr_["InsApproveTotal"].ToString();
                ViewBag.InsApproveUG = _dr_["InsApproveUG"].ToString();
                ViewBag.InsApprovePG = _dr_["InsApprovePG"].ToString();
                ViewBag.InsApprovePHD = _dr_["InsApprovePHD"].ToString();


                ViewBag.StdApproveTotal = _dr_["StdApproveTotal"].ToString();
                ViewBag.StdApproveUG =   _dr_["StdApproveUG"].ToString();
                ViewBag.StdApprovePG =   _dr_["StdApprovePG"].ToString();
                ViewBag.StdApprovePHD =  _dr_["StdApprovePHD"].ToString();

                ViewBag.StdRejectTotal = _dr_["StdRejectTotal"].ToString();
                ViewBag.StdRejectUG = _dr_["StdRejectUG"].ToString();
                ViewBag.StdRejectPG = _dr_["StdRejectPG"].ToString();
                ViewBag.StdRejectPHD = _dr_["StdRejectPHD"].ToString();

                ViewBag.StdjoinTotal = _dr_["StdjoinTotal"].ToString();
                ViewBag.StdjoinUG = _dr_["StdjoinUG"].ToString();
                ViewBag.StdjoinPG = _dr_["StdjoinPG"].ToString();
                ViewBag.StdjoinPHD = _dr_["StdjoinPHD"].ToString();

                ViewBag.InsRejectTotal = _dr_["InsRejectTotal"].ToString();
                ViewBag.InsRejectUG = _dr_["InsRejectUG"].ToString();
                ViewBag.InsRejectPG = _dr_["InsRejectPG"].ToString();
                ViewBag.InsRejectPHD = _dr_["InsRejectPHD"].ToString();
            }
            #endregion

            #region AdmittedLanded Overview
            ReportsRepository _objRepo_ALO = new ReportsRepository();
            DataSet _ds_ALO = _objRepo.SELECT_PHASE2_KPI_AdmittedLanded_Overview("Count");
            ViewBag.HavePassport = 0;
            ViewBag.ApplyForPassport = 0;
            ViewBag.NepalPassport = 0;
            ViewBag.NoPassport = 0;

            ViewBag.BookedTicket = 0;
            ViewBag.NoBookedTicket = 0;
            ViewBag.SoonBookedTicket = 0;

            ViewBag.HaveVisa = 0;
            ViewBag.ApplyForVisa = 0;
            ViewBag.RejectedVisa = 0;

            ViewBag.StudentsRefusedToCome = 0;
            ViewBag.OnBoardingCompleted = 0;
            ViewBag.TravelFormalitiesInProcess = 0;

            if (_ds_ALO != null)
            {
                DataRow _dr_ALO = _ds_ALO.Tables[0].Rows[0];
                ViewBag.HavePassport = _dr_ALO["HavePassport"].ToString();
                ViewBag.ApplyForPassport = _dr_ALO["ApplyForPassport"].ToString();
                ViewBag.NepalPassport = _dr_ALO["NepalPassport"].ToString();
                ViewBag.NoPassport = _dr_ALO["NoPassport"].ToString();

                ViewBag.BookedTicket = _dr_ALO["BookedTicket"].ToString();
                ViewBag.NoBookedTicket = _dr_ALO["NoBookedTicket"].ToString();
                ViewBag.SoonBookedTicket = _dr_ALO["SoonBookedTicket"].ToString();

                ViewBag.HaveVisa = _dr_ALO["HaveVisa"].ToString();
                ViewBag.ApplyForVisa = _dr_ALO["ApplyForVisa"].ToString();
                ViewBag.RejectedVisa = _dr_ALO["RejectedVisa"].ToString();
                
                ViewBag.StudentsRefusedToCome = _dr_ALO["StudentsRefusedToCome"].ToString();
                ViewBag.OnBoardingCompleted = _dr_ALO["OnBoardingCompleted"].ToString();
                ViewBag.TravelFormalitiesInProcess = _dr_ALO["TravelFormalitiesInProcess"].ToString();
            }
            #endregion

            #region Round 2
            ReportsRepository _objRepo_R2 = new ReportsRepository();
            DataSet _ds_R2 = _objRepo_R2.SELECT_PHASE2_KPI_SecondRound_OverView("Count");
            ViewBag.PGStdParticapte_ = 0;
            ViewBag.PGStdStartFillingChoice = 0;
            ViewBag.PGStdSubmittedChoice = 0;

            ViewBag.PGStdSeatAlloted = 0;
            ViewBag.PGStdSeatNotAlloted = 0;

            if (_ds_R2 != null)
            {
                DataRow _dr_R2 = _ds_R2.Tables[0].Rows[0];
                ViewBag.PGStdParticapte_ = _dr_R2["PGStdParticapte_"].ToString();
                ViewBag.PGStdStartFillingChoice = _dr_R2["PGStdStartFillingChoice"].ToString();
                ViewBag.PGStdSubmittedChoice = _dr_R2["PGStdSubmittedChoice"].ToString();
                ViewBag.PGStdSeatAlloted = _dr_R2["PGStdSeatAlloted"].ToString();
                ViewBag.PGStdSeatNotAlloted = _dr_R2["PGStdSeatNotAlloted"].ToString();
            }
            #endregion

            #region Round 3
            ReportsRepository _objRepo_R3 = new ReportsRepository();
            DataSet _ds_R3 = _objRepo_R2.SELECT_PHASE2_KPI_ThirdRound_OverView("Count");
            ViewBag.UGStdR3Particapte_ = 0;
            ViewBag.UGStdR3StartFillingChoice = 0;
            ViewBag.UGStdR3SubmittedChoice = 0;

            ViewBag.UGStdR3SeatAlloted = 0;
            ViewBag.UGStdR3SeatNotAlloted = 0;

            if (_ds_R3 != null)
            {
                DataRow _dr_R3 = _ds_R3.Tables[0].Rows[0];
                ViewBag.UGStdR3Particapte_ = _dr_R3["UGStdR3Particapte_"].ToString();
                ViewBag.UGStdR3StartFillingChoice = _dr_R3["UGStdR3StartFillingChoice"].ToString();
                ViewBag.UGStdR3SubmittedChoice = _dr_R3["UGStdR3SubmittedChoice"].ToString();
                ViewBag.UGStdR3SeatAlloted = _dr_R3["UGStdR3SeatAlloted"].ToString();
                ViewBag.UGStdR3SeatNotAlloted = _dr_R3["UGStdR3SeatNotAlloted"].ToString();
            }
            #endregion

            return View();
        }
        public ActionResult Report(string id, string u = "", string c = "", string d=null)
        {
            try
            {
                if (id == "Registered")
                {
                    #region Export Registered Students
                    ReportsRepository _objRepo = new ReportsRepository();
                    DataSet _ds = _objRepo.SELECT_PHASE2_KPI_REGISTERED_STUDENTS("List", "RegisteredStudents");

                    DataTable _dt = _ds.Tables[0];
                    _dt.TableName = "Registered Students";
                    if (_dt.Rows.Count > 0)
                    {
                        _dt.Columns["StudentID"].ColumnName = "StudentID";
                        _dt.Columns["StudentName"].ColumnName = "Student Name";
                        _dt.Columns["Email"].ColumnName = "Email";
                        _dt.Columns["Mobile"].ColumnName = "Mobile";
                        _dt.Columns["Country_Name"].ColumnName = "Country";
                        _dt.Columns["RegistrationDate"].ColumnName = "Registration Date";
                        _dt.Columns["FilledChoices"].ColumnName = "Filled Choices";
                        _dt.Columns["SubmitChoiceFill"].ColumnName = "Submitted Choice Filling?";
                        _dt.Columns["SubmitChoiceFillingDate"].ColumnName = "Submission Date";
                        _dt.Columns["EditApplication"].ColumnName = "Edited Application?";
                        _dt.Columns["EditApplicationDate"].ColumnName = "Edited Date";
                        _dt.Columns["ImportedFromBackend"].ColumnName = "Imported From Backend?";
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(_dt);
                        wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        wb.Style.Font.Bold = true;

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=SII_Phase2_RegisteredStudents.xlsx");

                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    return RedirectToAction("Reports", "Phase2", new { Area = "Admin" });
                    #endregion
                }
                else if (id == "Country")
                {
                    if (u == "ApplicationReceived")
                    {
                        ViewBag.For = "CountryStudentRegistered";
                        c = StringCipher.Decrypt(c);
                        ViewBag.Value = c;
                        return View("_Phase2_CountryStudents");
                    }
                    else if (u == "ApplicationConsidered")
                    {
                        ViewBag.For = "CountryStudentConsidered";
                        c = StringCipher.Decrypt(c);
                        ViewBag.Value = c;
                        return View("_Phase2_CountryStudents");
                    }
                    else
                    {
                        return View("_Phase2_Country");
                    }
                }
                else if (id == "Considered")
                {
                    
                    return View("_Phase2_ConsideredStudents");
                }
                else if (id == "Allotted")
                {
                    return View("_Phase2_AllottedStudents");
                }
                else if (id == "SeatAlloted" || id == "StudentsConsidered")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.DisplayName = "";
                    if (c == "1" )
                    { ViewBag.DisplayName = "Students Allotted Seat "; }
                    if (c == "0")
                    { ViewBag.DisplayName = "Students not allotted seat"; }
                    if (c == "all")
                    { ViewBag.DisplayName = "Students considered "; }
                    if (c == "c" && u =="UG")
                    { ViewBag.DisplayName = "U.G. level counselling - Students not allotted seat but were allotted either PG or Ph.D."; }
                    if (c == "c" && u == "PG")
                    { ViewBag.DisplayName = "P.G. level counselling - Students not allotted seat but were allotted either UG or Ph.D."; }
                    if (c == "c" && u == "PHD")
                    { ViewBag.DisplayName = "Ph. D. level counselling - Students not allotted seat but were allotted either PG or UG"; }

                    return View("_Phase2_ConsideredStudentsPrograllevlwise");
                }
                else if (id == "Scholarship")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.DisplayName = "";
                    if (c == "SII")
                    { ViewBag.DisplayName = "SII Scholarships awarded "; }
                    if (c == "AFRICA")
                    { ViewBag.DisplayName = "Africa free education Scholarship"; }
                    if (c == "all")
                    { ViewBag.DisplayName = "Total Scholarship"; }
                    return View("_Phase2_ConsideredStudentsPrograllevlwise");
                }
                else if (id == "ScholarshipCountryWiseCount")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.DisplayName = "Country-wise scholarships";
                    return View("_Phase2_ScholarshipCountryWise");
                }
                else if (id == "ScholarshipCountryWiseList")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Country-wise scholarships-List";
                    return View("_Phase2_ConsideredStudentsPrograllevlwise");
                }

                else if (id == "InstituteList")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Institute-List";
                    return View("_Phase2_InstituteList");
                }
                else if (id == "Passport")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Passport";
                    return View("_Phase2_StudentPassport");
                }
                else if (id == "Ticket")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Ticket";
                    return View("_Phase2_StudentTicket");
                }
                else if (id == "Visa")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Visa";
                    return View("_Phase2_StudentVisa");
                }
                else if (id == "StudentsRefusedToCome")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Students Refused To Come";
                    return View("_Phase2_StudentVisa");
                }
                else if (id == "OnBoardingCompleted")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "On Boarding Completed";
                    return View("_Phase2_StudentVisa");
                }
                else if (id == "TravelFormalitiesInProcess")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Travel Formalities In Process";
                    return View("_Phase2_StudentVisa");
                }
                else if (id == "Student_list")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Country-wise scholarships-List";
                    return View("_Phase2_ConsideredStudentsInstituteWise");
                }
                else if (id == "PGStdParticapte" )
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Phase-2 || 2nd Mock Round - Students to be Consider";
                    return View("Round2Students");
                }
                else if (id == "PGStdStartFillingChoice" )
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Phase-2 || 2nd Mock Round - Students Start Filling Choices";
                    return View("Round2Students");
                }
                else if (id == "PGStdSubmittedChoice")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Phase-2 || 2nd Mock Round - Students Submited";
                    return View("Round2Students");
                }
                else if (id == "PGStdSeatAlloted")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Phase-2 || 2nd Mock Round -  Seat Allotted";
                    return View("Round2Students");
                }
                else if (id == "PGStdSeatNotAlloted")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    ViewBag.DisplayName = "Phase-2 || 2nd Mock Round - Seat Not Allotted";
                    return View("Round2Students");
                }
                else if (id == "UGStdR3Particapte" || id == "UGStdR3StartFillingChoice" || id == "UGStdR3SubmittedChoice" || id == "UGStdR3SeatAlloted" || id == "UGStdR3SeatNotAlloted")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    if (id == "UGStdR3Particapte")
                    { ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Participated Students"; }
                    if (id == "UGStdR3StartFillingChoice")
                    { ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Start Filled Choices"; }
                    if (id == "UGStdR3SubmittedChoice")
                    { ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Submitted Choices"; }
                    if (id == "UGStdR3SeatAlloted")
                    { ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Seat Allotted "; }
                    if (id == "UGStdR3SeatNotAlloted")
                    { ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Seat Not-Allotted "; }

                    return View("Round3Students");
                }
                else if (id == "Scholarship_UG" || id == "Scholarship_PG")
                {
                    ViewBag.Control = id;
                    ViewBag.Value = c;
                    ViewBag.For = u;
                    ViewBag.Value2 = d;
                    //if (id == "UGStdR3SeatNotAlloted")
                    //{ ViewBag.DisplayName = "Phase-2 || 3rd Round - UG - Seat Not-Allotted "; }
                    ViewBag.DisplayName = "Scholarship";
                    return View("_Phase2_ScholarshipCountryWiseAllRound");
                }
                else
                {
                    return View("Reports");
                }
            }
            catch (Exception)
            {
                return View("Reports");
            }
        }

        #endregion
    }
}