using SIIModel.Institute;
using SIIRepository.Institute;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    public class LandingPageController : Controller
    {
        // GET: Institute/LandingPage
        public ActionResult Index(string InstituteID = "", string User_id = "0")
        {
            InstituteRepository _objRepository = new InstituteRepository();
            InstituteMaster _obj = new InstituteMaster();
            _obj.InstituteID = InstituteID;
            DataSet ds = _objRepository.Login_Institute(_obj);
            if (ds != null)
            {
                Session["IsChangePwd"] = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Session["InstituteID"] = dr["InstituteID"].ToString();
                    Session["InstituteName"] = dr["InstituteName"].ToString();
                    Session["Email"] = dr["Email"].ToString();
                    Session["User_id"] = User_id;
                    Session["IsAdminFLag"] = "True";
                    Session["IsAdminEdit"] = "True";
                    Session["IsNicheAllowed"] = dr["IsNicheAllowed"].ToString();
                    string localIP = "?";
                    localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    Session["localIP"] = localIP;
                    Session["ParticipatedYear"] = ConfigurationManager.AppSettings["ParticipatedYear"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[1].Rows)
                    {
                        Session["AR_StartDate"] = _dr["MinDate"].ToString();
                        Session["AR_EndDate"] = _dr["MaxDate"].ToString();
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _dr in ds.Tables[2].Rows)
                    {
                        Session["ParticipatedYear"] = _dr["ParticipatedYear"].ToString();
                    }
                }
                else
                {
                    Session["ParticipatedYear"] = "";
                }
            }
            //return RedirectToAction("Index", "Dashboard", new { area = "Institute" });
            return Redirect("~/Institute/ParticipationYears");
        }
    }
}