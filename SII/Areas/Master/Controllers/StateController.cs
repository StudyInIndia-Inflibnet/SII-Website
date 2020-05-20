using SIIModel.Master;
using SIIRepository.Masterservice;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Master.Controllers
{
    public class StateController : Controller
    {
        // GET: Master/State
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Select_State(State _obj)
        {

            StateRepository objRep = new StateRepository();
            DataSet ds = objRep.select_state(_obj);
            List<State> _list = new List<State>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        State objstate = new State();
                        objstate.state_id = row["state_id"].ToString();
                        objstate.state_name = row["state_name"].ToString();
                        objstate.country_id = row["COUNTRY_NAME"].ToString();
                        //objstate.COUNTRY_ID = row["COUNTRY_ID"].ToString();
                        _list.Add(objstate);
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
    }
}