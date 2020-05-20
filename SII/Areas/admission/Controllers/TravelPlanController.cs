using SIIModel.StudentRegister;
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
    public class TravelPlanController : Controller
    {
        // GET: admission/TravelPlan
        #region Travel Plan
        [SessionExpireStudent]
        public ActionResult Index()
        {
            ChoiceFillingRepository _objRepository = new ChoiceFillingRepository();
            DataSet _ds = _objRepository.SELECT_tbl_Student_Ch_Basic(Session["studentid"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        Session["ApplicationNo"] = _dr["ApplicationNo"].ToString();
                    }
                }
            }
            return View();
        }
        #endregion

        #region Passport
        [SessionExpireStudent]
        public ActionResult Passport()
        {
            return View();
        }
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SavePassport(mTravelPlanPassport _obj)
        {
            string path = "";
            string folderPath = "";
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        folderPath = "Uploads/studentDocument/TravelPlan/" + Session["studentid"].ToString() + "/";
                        path = AppDomain.CurrentDomain.BaseDirectory + folderPath;
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        filename = Session["ApplicationNo"].ToString() + "_Passport_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(file.FileName);
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
                                {
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                    System.IO.File.Delete(path: curentfile);
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                }
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/" + folderPath), filename);
                        file.SaveAs(fname);
                        if (_obj.HaveValidPassport == "Yes, I have")
                        {
                            _obj.PassportDocument = folderPath + filename;
                        }
                        else if (_obj.HaveValidPassport == "Applied for a passport")
                        {
                            _obj.ApplicationDocument = folderPath + filename;
                        }
                        else if (_obj.HaveValidPassport == "I have Nepalese citizenship document")
                        {
                            _obj.CitizenshipDocument = folderPath + filename;
                        }
                    }
                }
                _obj.CreatedIP = Session["localIP"].ToString();
                _obj.StudentID = Session["StudentID"].ToString();
                _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                TravelPlanRepository _objRepository = new TravelPlanRepository();
                DataSet _ds = _objRepository.INSERT_UPDATE_StudentTravelPlanPassport(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Details saved successfully!";
                        Code = "success";
                        Session["HasPassportDetails"] = "True";
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
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectPassport()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanPassport> _list = new List<mTravelPlanPassport>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_StudentTravelPlanPassport(Session["studentid"].ToString(), Session["ApplicationNo"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mTravelPlanPassport
                            {
                                ID = _dr["ID"].ToString(),
                                HaveValidPassport = (_dr["HaveValidPassport"] != null ? _dr["HaveValidPassport"].ToString() : ""),
                                PassportNumber = (_dr["PassportNumber"] != null ? _dr["PassportNumber"].ToString() : ""),
                                PassportExpiryDate = (_dr["PassportExpiryDate"] != null ? (_dr["PassportExpiryDate"].ToString() != "" ? Convert.ToDateTime(_dr["PassportExpiryDate"].ToString()).ToString("dd-MM-yyyy") : "") : ""),
                                PassportDocument = (_dr["PassportDocument"] != null ? _dr["PassportDocument"].ToString() : ""),
                                ApplicationNumber = (_dr["ApplicationNumber"] != null ? _dr["ApplicationNumber"].ToString() : ""),
                                ApplicationDocument = (_dr["ApplicationDocument"] != null ? _dr["ApplicationDocument"].ToString() : ""),
                                CitizenshipNumber = (_dr["CitizenshipNumber"] != null ? _dr["CitizenshipNumber"].ToString() : ""),
                                CitizenshipIssueDate = (_dr["CitizenshipIssueDate"] != null ? (_dr["CitizenshipIssueDate"].ToString() != "" ? Convert.ToDateTime(_dr["CitizenshipIssueDate"].ToString()).ToString("dd-MM-yyyy") : "") : ""),
                                CitizenshipDocument = (_dr["CitizenshipDocument"] != null ? _dr["CitizenshipDocument"].ToString() : "")
                            });
                        }
                        Message = "Data filled.";
                        Code = "success";
                    }
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
                List = _list
            },
                   JsonRequestBehavior.AllowGet
               );
        }
        #endregion

        #region Air Ticket
        [SessionExpireStudent]
        public ActionResult AirTicket()
        {
            return View();
        }
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveAirTicket(mTravelPlanAirTicket _obj)
        {
            string path = "";
            string folderPath = "";
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        folderPath = "Uploads/studentDocument/TravelPlan/" + Session["studentid"].ToString() + "/";
                        path = AppDomain.CurrentDomain.BaseDirectory + folderPath;
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        filename = Session["ApplicationNo"].ToString() + "_AirTicket_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(file.FileName);
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
                                {
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                    System.IO.File.Delete(path: curentfile);
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                }
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/" + folderPath), filename);
                        file.SaveAs(fname);
                        if (_obj.HaveBookedTicket == "Yes, I have booked air ticket")
                        {
                            _obj.ETicket = folderPath + filename;
                        }
                    }
                }
                _obj.CreatedIP = Session["localIP"].ToString();
                _obj.StudentID = Session["StudentID"].ToString();
                _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                TravelPlanRepository _objRepository = new TravelPlanRepository();
                DataSet _ds = _objRepository.INSERT_UPDATE_StudentTravelPlanAirTicket(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Details saved successfully!";
                        Code = "success";
                        Session["HasAirTicketDetails"] = "True";
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
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectAirTicket()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanAirTicket> _list = new List<mTravelPlanAirTicket>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_StudentTravelPlanAirTicket(Session["studentid"].ToString(), Session["ApplicationNo"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mTravelPlanAirTicket
                            {
                                ID = _dr["ID"].ToString(),
                                HaveBookedTicket = (_dr["HaveBookedTicket"] != null ? _dr["HaveBookedTicket"].ToString() : ""),
                                LandingDate = (_dr["LandingDate"] != null ? (_dr["LandingDate"].ToString() != "" ? Convert.ToDateTime(_dr["LandingDate"].ToString()).ToString("dd-MM-yyyy") : "") : ""),
                                LandingTime = (_dr["LandingTime"] != null ? _dr["LandingTime"].ToString() : ""),
                                OriginCountry = (_dr["OriginCountry"] != null ? _dr["OriginCountry"].ToString() : ""),
                                OriginAirport = (_dr["OriginAirport"] != null ? _dr["OriginAirport"].ToString() : ""),
                                DestinationCountry = (_dr["DestinationCountry"] != null ? _dr["DestinationCountry"].ToString() : ""),
                                DestinationAirport = (_dr["DestinationAirport"] != null ? _dr["DestinationAirport"].ToString() : ""),
                                OtherOriginAirport = (_dr["OtherOriginAirport"] != null ? _dr["OtherOriginAirport"].ToString() : ""),
                                OtherDestinationAirport = (_dr["OtherDestinationAirport"] != null ? _dr["OtherDestinationAirport"].ToString() : ""),
                                ETicket = (_dr["ETicket"] != null ? _dr["ETicket"].ToString() : "")
                            });
                        }
                        Message = "Data filled.";
                        Code = "success";
                    }
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
                List = _list
            },
                   JsonRequestBehavior.AllowGet
               );
        }
        public JsonResult SeletAirports(string Country_id = "0")
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanAirports> _list = new List<mTravelPlanAirports>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_COUNTRY_WISE_AIRPORTS(Country_id);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mTravelPlanAirports
                            {
                                ID = _dr["ID"].ToString(),
                                name = (_dr["name"] != null ? _dr["name"].ToString() : ""),
                                Country = (_dr["Country"] != null ? _dr["Country"].ToString() : ""),
                                Region = (_dr["Region"] != null ? _dr["Region"].ToString() : ""),
                                iso_country = (_dr["iso_country"] != null ? _dr["iso_country"].ToString() : ""),
                            });
                        }
                        Message = "Data filled.";
                        Code = "success";
                    }
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
                List = _list
            },
                   JsonRequestBehavior.AllowGet
               );
        }
        #endregion

        #region Visa
        [SessionExpireStudent]
        public ActionResult Visa()
        {
            return View();
        }
        [SessionExpireStudent]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveVisa(mTravelPlanVisa _obj)
        {
            string path = "";
            string folderPath = "";
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                string filename = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        folderPath = "Uploads/studentDocument/TravelPlan/" + Session["studentid"].ToString() + "/";
                        path = AppDomain.CurrentDomain.BaseDirectory + folderPath;
                        filename = Path.GetFileName(Request.Files[0].FileName);
                        HttpPostedFileBase file = files[0];
                        filename = Session["ApplicationNo"].ToString() + "_Visa_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(file.FileName);
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
                                {
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                    System.IO.File.Delete(path: curentfile);
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                                }
                            }
                        }

                        fname = Path.Combine(Server.MapPath("~/" + folderPath), filename);
                        file.SaveAs(fname);
                        if (_obj.HaveIndianStudentVisa == "Yes, I have received the visa")
                        {
                            _obj.VisaDocument = folderPath + filename;
                        }
                        else if (_obj.HaveIndianStudentVisa == "I have applied for the visa. It is in-process")
                        {
                            _obj.VisaApplicationDocument = folderPath + filename;
                        }
                    }
                }
                _obj.CreatedIP = Session["localIP"].ToString();
                _obj.StudentID = Session["StudentID"].ToString();
                _obj.ApplicationNo = Session["ApplicationNo"].ToString();
                TravelPlanRepository _objRepository = new TravelPlanRepository();
                DataSet _ds = _objRepository.INSERT_UPDATE_StudentTravelPlanVisa(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        Message = "Details saved successfully!";
                        Code = "success";
                        Session["HasVisaDetails"] = "True";
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
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectVisa()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            List<mTravelPlanVisa> _list = new List<mTravelPlanVisa>();
            try
            {
                TravelPlanRepository _objRepo = new TravelPlanRepository();
                DataSet _ds = _objRepo.SELECT_StudentTravelPlanVisa(Session["studentid"].ToString(), Session["ApplicationNo"].ToString());
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _list.Add(new mTravelPlanVisa
                            {
                                ID = _dr["ID"].ToString(),
                                HaveIndianStudentVisa = (_dr["HaveIndianStudentVisa"] != null ? _dr["HaveIndianStudentVisa"].ToString() : ""),
                                VisaNumber = (_dr["VisaNumber"] != null ? _dr["VisaNumber"].ToString() : ""),
                                ExpiryDate = (_dr["ExpiryDate"] != null ? (_dr["ExpiryDate"].ToString() != "" ? Convert.ToDateTime(_dr["ExpiryDate"].ToString()).ToString("dd-MM-yyyy") : "") : ""),
                                VisaType = (_dr["VisaType"] != null ? _dr["VisaType"].ToString() : ""),
                                VisaDocument = (_dr["VisaDocument"] != null ? _dr["VisaDocument"].ToString() : ""),
                                VisaApplicationNumber = (_dr["VisaApplicationNumber"] != null ? _dr["VisaApplicationNumber"].ToString() : ""),
                                VisaApplicationDocument = (_dr["VisaApplicationDocument"] != null ? _dr["VisaApplicationDocument"].ToString() : "")
                            });
                        }
                        Message = "Data filled.";
                        Code = "success";
                    }
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
                List = _list
            },
                   JsonRequestBehavior.AllowGet
               );
        }
        #endregion

        #region Institute Spoc
        [SessionExpireStudent]
        public ActionResult InstituteSpoc()
        {
            return View();
        }
        #endregion
    }
}