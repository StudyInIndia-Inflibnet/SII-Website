using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class LandingController : Controller
    {
        // GET: admission/Landing
        public ActionResult Index(string id = "")
        {
            if (id == "")
            {
                return Redirect("~/");
            }
            Student_Register _obj = new Student_Register()
            {
                Email = id,
                studentid = id
            };
            StudentRepository _objRepository = new StudentRepository();
            DataSet ds = _objRepository.Login_Student(_obj);
            if (ds != null)
            {
                Session["IsChangePwd"] = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Session["studentid"] = dr["studentid"].ToString();


                    Session["studentname"] = dr["studentname"].ToString();
                    Session["Email"] = dr["Email"].ToString();
                    Session["Mobile"] = dr["Mobile"].ToString();
                    Session["StudentProfilePic"] = "/assets/img/avatar.png";
                    Session["submitChoiceFill"] = dr["submitChoiceFill"].ToString();
                    Session["submitchoiceDate"] = dr["submitchoiceDate"].ToString();
                    Session["EditApplication"] = dr["EditApplication"].ToString();
                    //Session["submitChoiceFill"] = "false";
                    Session["IsPasswordChanged"] = dr["IsPasswordChanged"].ToString();
                    Session["ischangedpassword"] = dr["ischangedpassword"].ToString();
                    Session["IsSeatAlloted"] = dr["IsSeatAlloted"].ToString();
                    Session["IsAllowEditData"] = dr["IsAllowEditData"].ToString();
                    Session["AllowChoiceFilling"] = dr["AllowChoiceFilling"].ToString();
                    Session["CountryID"] = dr["CountryID"].ToString();
                    Session["RegistrationPhase"] = dr["RegistrationPhase"].ToString();
                    //RegistrationPhase = dr["RegistrationPhase"].ToString();
                    Session["OpenChoiceFilling_"] = dr["OpenChoiceFilling_"].ToString();
                    Session["IndividualOpenChoiceFilling_"] = dr["IndividualOpenChoiceFilling_"].ToString();
                    Session["ApplyingForCourse"] = dr["ApplyingForCourse"].ToString();
                    Session["isTestStudent"] = dr["isTestStudent"].ToString();
                    Session["Photo"] = dr["Photo"].ToString();
                    Session["Signature"] = dr["Signature"].ToString();
                    Session["IsTestCentreCountry"] = dr["IsTestCentreCountry"].ToString();
                    Session["IsIndSATStudent"] = dr["IsIndSATStudent"].ToString();
                    //if (dr["student_path"]!= null)
                    //{
                    //    if (dr["student_path"].ToString() != "")
                    //    {
                    //        Session["StudentProfilePic"] = dr["student_path"].ToString();
                    //    }
                    //}
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
            return Redirect("~/admission/Dashboard");
        }
    }
}