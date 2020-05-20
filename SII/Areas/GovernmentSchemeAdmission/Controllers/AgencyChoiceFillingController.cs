using SIIModel.Master;
using SIIModel.StudentRegister;
using SIIRepository.Masterservice;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission.Controllers
{
    [SessionExpiregov]
    public class AgencyChoiceFillingController : Controller
    {
        // GET: GovernmentSchemeAdmission/AgencyChoiceFilling
        public ActionResult Index(string Id = "")
        {
            int chk_flag = 0;
            Session["studentid"] = Id;
            chk_flag = studentdata_submitted(Session["studentid"].ToString());
            if (chk_flag == 1)
            {
                return RedirectToAction("index", "AgencyChoiceFillingList", new { area = "GovernmentSchemeAdmission" });
            }
            if (Session["agency_uniq_id"].ToString() != "SII-A-0012")
            {
                DashboardRepository _objRepository = new DashboardRepository();
                DataSet _ds = _objRepository.Get_Dashboard_Data(Session["studentid"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            ViewBag.StudentProfile = _dr["StudentProfile"].ToString();
                            ViewBag.Academic = _dr["Academic"].ToString();
                            ViewBag.Doc = _dr["Doc"].ToString();
                            ViewBag.Background = _dr["Background"].ToString();
                        }
                    }
                }
                if (ViewBag.Academic != "100")
                {
                    ViewBag.flag = "1";
                    //return RedirectToAction("index", "StudentAcademicInformation", new { area = "admission" });
                }
                else if (ViewBag.StudentProfile == "0")
                {
                    ViewBag.flag = "1";
                }
                else if (ViewBag.Doc == "0")
                {
                    ViewBag.flag = "1";
                }
                else if (ViewBag.Background == "0")
                {
                    ViewBag.flag = "1";
                }
                else
                {
                    ViewBag.flag = "0";
                }
            }
            else
            {
                ViewBag.flag = "0";
            }
            SelectDropdown();
            return View();
        }
        #region FillDropdown
        public int studentdata_submitted(string studentid)
        {
            int flag = 0;
            Student_Register _obj = new Student_Register();
            _obj.studentid = studentid;
            StudentRepository _objRepository = new StudentRepository();
            DataSet ds = _objRepository.Login_Student(_obj);
            if (ds != null)
            {
                //Session["IsChangePwd"] = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (dr["submitChoiceFill"].ToString().ToLower() == "true")
                    {
                        Session["submitChoiceFill"] = dr["submitChoiceFill"].ToString();
                        flag = 1;
                    }
                }
            }
            return flag;
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
        #endregion


        #region Save Select and Delete CourseOffers

        public JsonResult SelectInstitute(ChoiceFilling obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            obj.Type = "GridDetails";
            obj.studentid = Session["studentid"].ToString();
            obj.CreatedBy = Session["studentid"].ToString();
            DataSet ds = objRep.Select_InstituteList(obj);
            List<ChoiceFilling> _list = new List<ChoiceFilling>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ChoiceFilling objChoice = new ChoiceFilling();
                        //objChoice.ID = row["ID"].ToString();
                        objChoice.tbl_InstituteCourse_ID = row["tbl_InstituteCourse_ID"].ToString();
                        objChoice.InstituteID = row["InstituteId"].ToString();
                        //objChoice.Discipline = row["Discipline"].ToString();
                        objChoice.Natureofcourse = row["Natureofcourse"].ToString();
                        //objChoice.ProgramLevel = row["ProgramLevel"].ToString();
                        //   objChoice.BranchName = row["BranchName"].ToString();
                        objChoice.InstituteName = row["InstituteName"].ToString();
                        // objChoice.DisplayName = row["DisplayName"].ToString();
                        objChoice.state_name = row["state_name"].ToString();
                        objChoice.G1SeatWaiver = row["G1SeatWaiver"].ToString();
                        objChoice.G2SeatWaiver = row["G2SeatWaiver"].ToString();
                        objChoice.G3SeatWaiver = row["G3SeatWaiver"].ToString();
                        objChoice.G4SeatWaiver = row["G4SeatWaiver"].ToString();
                        _list.Add(objChoice);
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
        public ActionResult SelectInstitutePaging(ChoiceFilling obj)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            string search = Request.Form.GetValues("search[value]").FirstOrDefault();
            // var data="";
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            obj.Type = "GridDetails";
            obj.studentid = Session["studentid"].ToString();
            obj.CreatedBy = Session["studentid"].ToString();
            List<ChoiceFilling> _list = new List<ChoiceFilling>();
            DataSet ds = objRep.Select_InstituteList(obj);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ChoiceFilling objChoice = new ChoiceFilling();
                        objChoice.tbl_InstituteCourse_ID = row["tbl_InstituteCourse_ID"].ToString();
                        objChoice.InstituteID = row["InstituteId"].ToString();
                        objChoice.Natureofcourse = row["Natureofcourse"].ToString();
                        objChoice.InstituteName = row["InstituteName"].ToString();
                        objChoice.state_name = row["state_name"].ToString();
                        objChoice.G1SeatWaiver = row["G1SeatWaiver"].ToString();
                        objChoice.G2SeatWaiver = row["G2SeatWaiver"].ToString();
                        objChoice.G3SeatWaiver = row["G3SeatWaiver"].ToString();
                        objChoice.G4SeatWaiver = row["G4SeatWaiver"].ToString();
                        _list.Add(objChoice);
                    }

                }
            }
            List<ChoiceFilling> list = new List<ChoiceFilling>();
            if (search == null)
            {
                list = _list;
            }
            else
            {
                // simulate search
                foreach (ChoiceFilling dataItem in _list)
                {
                    if (dataItem.InstituteName.ToUpper().Contains(search.ToUpper()) ||
                        dataItem.Natureofcourse.ToString().Contains(search.ToUpper()))
                    {
                        list.Add(dataItem);
                    }
                }
            }
            var v = list;
            recordsTotal = v.Count();
            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Insert_InstituteList(ChoiceFilling _obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            _obj.studentid = Session["studentid"].ToString();
            _obj.CreatedBy = Session["studentid"].ToString();
            _obj.CreatedIp = Request.ServerVariables["REMOTE_ADDR"].ToString(); ;
            DataSet _ds = objRep.Insert_InstituteList_New(_obj);
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
        public JsonResult Select_Filled_Institute(ChoiceFilling obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            obj.Type = "FilledChoice";
            obj.studentid = Session["studentid"].ToString();
            DataSet ds = objRep.Select_InstituteList(obj);
            List<ChoiceFilling> _list = new List<ChoiceFilling>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ChoiceFilling objChoice = new ChoiceFilling();
                        objChoice.ID = row["ID"].ToString();//Primary key
                        //objChoice.tbl_InstituteCourse_ID = row["tbl_InstituteCourse_ID"].ToString();
                        objChoice.InstituteID = row["Institute_Id"].ToString();
                        //objChoice.Discipline = row["Discipline"].ToString();
                        objChoice.Natureofcourse = row["Natureofcourse"].ToString();
                        //objChoice.ProgramLevel = row["ProgramLevel"].ToString();
                        //objChoice.BranchName = row["BranchName"].ToString();
                        objChoice.InstituteName = row["InstituteName"].ToString();
                        //objChoice.DisplayName = row["DisplayName"].ToString();
                        // objChoice.state_name = row["state_name"].ToString();
                        objChoice.SequenceNumber = row["SequenceNumber"].ToString();
                        objChoice.SeatWaivertype = row["SeatWaivertype"].ToString();
                        _list.Add(objChoice);
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
        [SessionExpireStudent]
        public JsonResult Delete_InstituteList(string ID = "")
        {
            bool flag = false;
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            DataSet _ds = objRep.Delete_InstituteList(ID, Session["studentid"].ToString());
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
        public JsonResult UpdateSequenceNumber_swap_move(ChoiceFilling obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            //obj.Type = "SWAP";
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            obj.CreatedIp = localIP;
            obj.studentid = Session["studentid"].ToString();
            DataSet _ds = objRep.UpdateSequenceNumber_swap_move(obj);
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
        public JsonResult update_StudentChoiceFilling(string ID = "")
        {
            bool flag = false;
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            DataSet _ds = objRep.update_StudentChoiceFilling(ID, Session["studentid"].ToString());
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
        public JsonResult student_submit_choice_filling(ChoiceFilling obj)
        {
            ChoiceFillingRepository objRep = new ChoiceFillingRepository();
            //obj.Type = "SWAP";
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            obj.CreatedIp = localIP;
            obj.studentid = Session["studentid"].ToString();
            DataSet _ds = objRep.student_submit_choice_filling(obj);
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
    }
}