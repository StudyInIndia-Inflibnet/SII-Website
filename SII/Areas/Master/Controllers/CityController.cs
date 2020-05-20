using SIIModel.Master;
using SIIRepository.Masterservice;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.Master.Controllers
{
    public class CityController : Controller
    {
        // GET: Master/City
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Select_City(City _obj)
        {

            CityRepository objRep = new CityRepository();
            DataSet ds = objRep.select_city(_obj);
            List<City> _list = new List<City>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        City objcity = new City();
                        objcity.city_id = row["city_id"].ToString();
                        objcity.state_id = row["state_id"].ToString();
                        objcity.country_id = row["country_id"].ToString();
                        objcity.city_name = row["city_name"].ToString();
                        _list.Add(objcity);
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