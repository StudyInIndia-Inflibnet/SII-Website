using SIIModel.Institute;
using SIIRepository.Institute;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    [SessionExpireInstitute]
    [NoDirectAccess]
    public class HowToReachController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // GET: Institute/HowToReach
        public ActionResult Index()
        {
            TempData["ActiveMainTabInstitute"] = "HowToReach";
            return View();
        }
        public JsonResult Select_Institute_How_To_Reach(string ID = "")
        {
            List<mInstituteHowToReach> _list = new List<mInstituteHowToReach>();
            InstituteHowToReachRepository _objRepository = new InstituteHowToReachRepository();
            // using (IInstituteHowToReach _objRepository = new RInstituteHowToReach())
            {
                DataSet ds = _objRepository.Select_Institute_How_To_Reach(ID, Session["InstituteID"].ToString());
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            mInstituteHowToReach _objList = new mInstituteHowToReach();
                            _objList.ID = row["ID"].ToString();
                            _objList.InstituteID = row["InstituteID"].ToString();
                            _objList.ReachBy = row["ReachBy"].ToString();
                            _objList.NearByStationName = row["NearByStationName"].ToString();
                            _objList.remarks = row["remarks"].ToString();
                            _objList.ApproxTime = row["ApproxTime"].ToString();
                            _objList.ApproxTimeType = row["ApproxTimeType"].ToString();
                            _objList.Distance = row["Distance"].ToString();
                            _objList.DistanceType = row["DistanceType"].ToString();
                            _list.Add(_objList);
                        }
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
        public JsonResult Save_Institute_How_To_Reach(mInstituteHowToReach _obj)
        {
            bool flag = false;
            InstituteHowToReachRepository _objRepository = new InstituteHowToReachRepository();
            // using (IInstituteHowToReach _objRepository = new RInstituteHowToReach())
            {
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                _obj.InstituteID = Session["InstituteID"].ToString();
                _obj.Edited_by = Session["User_id"].ToString();
                DataSet _ds = _objRepository.Save_Institute_How_To_Reach(_obj);
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
            }

            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult Delete_Institute_How_To_Reach(string ID = "")
        {
            bool flag = false;
            InstituteHowToReachRepository _objRepository = new InstituteHowToReachRepository();
            // using (IInstituteHowToReach _objRepository = new RInstituteHowToReach())
            {
                DataSet _ds = _objRepository.Delete_Institute_How_To_Reach(ID);
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
            }

            return Json(new
            {
                flag = flag
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}