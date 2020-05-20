using SIIModel.Admin;
using SIIModel.Master;
using SIIRepository.Adminservice;
using SIIRepository.StudentRegService;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class AgencyDetailsController : Controller
    {
        // GET: Admin/AgencyDetails
        public ActionResult Index(string ID = "0")
        {
            if (ID == "")
            {
                TempData["agencyid"] = 0;
                //  ViewBag.agencyid = ID;
            }
            else
            {
                TempData["agencyid"] = ID;
                // ViewBag.agencyid = ID;
            }
            selectDropdown();
            return View();
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
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Country _objcountry = new Country();
                        _objcountry.Country_id = (row["Country_id"].ToString());
                        _objcountry.Country_Name = row["Country_Name"].ToString();
                        _objcountry.country_code = row["country_code"].ToString() + " (" + row["Country_Name"].ToString() + ")";
                        _Country.Add(_objcountry);
                    }
                }
            }
            ViewBag.Nationality = _Nationality;
            ViewBag.Country = _Country;
        }

        #region agency master
        public JsonResult SaveAgencymaster(Agencymaster _obj)
        {
            AgencyRepository objRepository = new AgencyRepository();
            SendEmail _objseedemail = new SendEmail();
            string localIP = "?";
            localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            _obj.createdip = localIP;
            string password = Membership.GeneratePassword(8, 1);
            _obj.password = password;

            DataSet _ds = objRepository.insert_update_agency(_obj);
            bool flag = false;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["counts"].ToString() == "1")
                    {
                        TempData["agencyid"] = _ds.Tables[0].Rows[0]["id"].ToString();
                        TempData.Keep("agencyid");
                        flag = true;
                        if (_obj.email.ToString() != "")
                        {
                            string strform = System.Configuration.ConfigurationManager.AppSettings["Emailusername"];
                            string Subject = "Agency Registration";
                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("<br/>Dear " + _obj.nameofagency + ",<br/>");
                            MailBody.Append("<br/>You have been registered with Study in India as a"+_obj.typeofagency);
                            MailBody.Append("<br/>Your login credentials are:");
                            MailBody.Append("<br/>Agency ID: " + _ds.Tables[0].Rows[0]["agency_uniq_id"].ToString());
                            MailBody.Append("<br/>Password: " + password.ToString()+ "(System Generated)");
                            MailBody.Append("<br/><br/><a target='_blank' href='" + FullyQualifiedApplicationPath(ControllerContext.RequestContext.HttpContext.Request) + "GovernmentSchemeAdmission/Login/index' style='color:blue;'>click here</a> to login for the first time and reset your password." + "<br/>");
                            MailBody.Append("<br/>After resetting the password, kindly login to<a target='_blank' href='https://www.studyinindia.gov.in/channel'>https://www.studyinindia.gov.in/channel</a>");
                            MailBody.Append("<br/>Please note: This is an auto generated mail.<br/>");
                            MailBody.Append("<br/>Regards,<br/>");
                            MailBody.Append("Study in India Cell<br/>");
                            string bcc = "";
                            string cc = "";
                            _objseedemail.SendEmailInBackgroundThread(strform, _obj.email, bcc, cc, Subject, MailBody.ToString(), "", true);
                           }
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
        public JsonResult SelectAgencymaster(string ID = "")
        {
            AgencyRepository objRep = new AgencyRepository();
            DataSet ds = objRep.select_Agency_master(TempData.Peek("agencyid").ToString());
            TempData.Keep("agencyid");
            List<Agencymaster> _list = new List<Agencymaster>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Agencymaster objBasic = new Agencymaster();
                        objBasic.agencyid = row["agencyid"].ToString();
                        objBasic.agency_uniq_id = row["agency_uniq_id"].ToString();
                        objBasic.nameofagency = row["nameofagency"].ToString();
                        objBasic.agencyaddress = row["agencyaddress"].ToString();
                        objBasic.email = row["email"].ToString();
                        objBasic.password = row["password"].ToString();
                        objBasic.countrycode = row["countrycode"].ToString();
                        objBasic.mobile = row["mobile"].ToString();
                        objBasic.typeofagency = row["typeofagency"].ToString();
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
        public JsonResult delete_tbl_Agency_master(string ID = "")
        {
            bool flag = false;
            AgencyRepository objRep = new AgencyRepository();
            DataSet _ds = objRep.delete_tbl_Agency_master(ID);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
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

        #region  agency  detail
        public JsonResult SaveAgencyDetail(AgencyDetail _obj)
        {
            AgencyRepository objRepository = new AgencyRepository();
            _obj.agencyid = TempData.Peek("agencyid").ToString();
            TempData.Keep("agencyid");
            DataSet _ds = objRepository.insert_update_agency_detail(_obj);
            bool flag = false;
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Counts"].ToString() == "1")
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
        public JsonResult SelectAgencyDetail(string ID = "")
        {
            AgencyRepository objRep = new AgencyRepository();
            DataSet ds = objRep.select_tbl_Agency_detail(TempData.Peek("agencyid").ToString());
            TempData.Keep("agencyid");
            List<AgencyDetail> _list = new List<AgencyDetail>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AgencyDetail objBasic = new AgencyDetail();
                        objBasic.id = row["id"].ToString();
                        objBasic.agencyid = row["agencyid"].ToString();
                        objBasic.nameofentitlename = row["nameofentitlename"].ToString();
                        objBasic.fee_g1 = row["fee_g1"].ToString();
                        objBasic.fee_g2 = row["fee_g2"].ToString();
                        objBasic.fee_g3 = row["fee_g3"].ToString();
                        objBasic.fee_g4 = row["fee_g4"].ToString();
                        objBasic.countryid = row["countryid"].ToString();
                        objBasic.noofstudent = row["noofstudent"].ToString();
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
        public JsonResult delete_tbl_Agency_detail(string ID = "")
        {
            bool flag = false;
            AgencyRepository objRep = new AgencyRepository();
            DataSet _ds = objRep.delete_tbl_Agency_detail(ID);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
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
    }
}