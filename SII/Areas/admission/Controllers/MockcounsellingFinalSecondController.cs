using SIIModel.StudentRegister;
using SIIRepository.StudentRegService;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    [NoDirectAccessLearner]
    public class MockcounsellingFinalSecondController : Controller
    {
        // GET: admission/MockcounsellingFinalSecond
        public ActionResult Index(string PrgId = null, string Discipline_Id = null)
        {
            Session["ProgramlevelId"] = PrgId;
            Session["Discipline_Id"] = Discipline_Id;
            return View();
        }
        public JsonResult Select_Filled_Institute(Mockcounselling obj)
        {
            MockResultRepository objRep = new MockResultRepository();
            obj.Type = "FilledChoice";
            obj.studentid = Session["studentid"].ToString();
            obj.ProgramLevel_Id = Session["ProgramlevelId"].ToString();
            obj.Discipline_ID = Session["Discipline_Id"].ToString();
            DataSet ds = objRep.Select_InstituteList(obj);
            List<Mockcounselling> _list = new List<Mockcounselling>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Mockcounselling objChoice = new Mockcounselling();
                        objChoice.ID = row["ID"].ToString();//Primary key
                        objChoice.InstituteID = row["Institute_Id"].ToString();
                        objChoice.InstituteName = row["InstituteName"].ToString();
                        objChoice.SequenceNumber = row["SequenceNumber"].ToString();
                        objChoice.Natureofcourse = row["NoC"].ToString();
                        objChoice.ProgramLevel = row["ProgramLevel"].ToString();
                        objChoice.BranchName = row["BranchName"].ToString();
                        objChoice.Discipline = row["Discipline"].ToString();
                        objChoice.SeatWaivertype = row["SeatWaivertype"].ToString();
                        objChoice.Isalloted = row["Isalloted"].ToString();
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

        public JsonResult Select_Result(Mockcounselling obj)
        {
            MockResultRepository objRep = new MockResultRepository();
            obj.Type = "AllotedSeat";
            obj.studentid = Session["studentid"].ToString();
            obj.ProgramLevel_Id = Session["ProgramlevelId"].ToString();
            obj.Discipline_ID = Session["Discipline_Id"].ToString();
            DataSet ds = objRep.Select_InstituteList(obj);
            List<Mockcounselling> _list = new List<Mockcounselling>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Mockcounselling objChoice = new Mockcounselling();
                        objChoice.ID = row["ID"].ToString();//Primary key
                        objChoice.InstituteID = row["Institute_Id"].ToString();
                        objChoice.InstituteName = row["InstituteName"].ToString();
                        objChoice.SequenceNumber = row["SequenceNumber"].ToString();
                        objChoice.Natureofcourse = row["NoC"].ToString();
                        objChoice.ProgramLevel = row["ProgramLevel"].ToString();
                        objChoice.BranchName = row["BranchName"].ToString();
                        objChoice.Discipline = row["Discipline"].ToString();
                        objChoice.SeatWaivertype = row["SeatWaivertype"].ToString();
                        objChoice.Isalloted = row["Isalloted"].ToString();
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
    }
}