using SIIModel.StudentRegister;
using SIIRepository.Adminservice;
using System;
using System.Data;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class StudentDeclarationController : Controller
    {
        // GET: admission/StudentDeclaration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _BasicInformation()
        {
            return PartialView();
        }
        public ActionResult _AcademicInformation()
        {
            return PartialView();
        }
        public ActionResult _BackgroundInformation()
        {
            return PartialView();
        }
        public ActionResult _DocumentInformation()
        {
            return PartialView();
        }

        public JsonResult CheckDeclarations()
        {
            string FLAG_PROFILE = "";
            string FLAG_ACADEMIC = "";
            string FLAG_DOC = "";
            string FLAG_BACKGROUND = "";
            try
            {
                DeclarationRepository _objRepository = new DeclarationRepository();
                StudentDeclaration _obj = new StudentDeclaration();
                _obj.studentid = Session["studentid"].ToString();
                DataSet ds = _objRepository.Check_Declarations(_obj);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FLAG_PROFILE = ds.Tables[0].Rows[0]["FLAG_PROFILE"].ToString();
                        FLAG_ACADEMIC = ds.Tables[0].Rows[0]["FLAG_ACADEMIC"].ToString();
                        FLAG_DOC = ds.Tables[0].Rows[0]["FLAG_DOC"].ToString();
                        FLAG_BACKGROUND = ds.Tables[0].Rows[0]["FLAG_BACKGROUND"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new
            {
                FLAG_PROFILE = FLAG_PROFILE,
                FLAG_ACADEMIC = FLAG_ACADEMIC,
                FLAG_DOC = FLAG_DOC,
                FLAG_BACKGROUND = FLAG_BACKGROUND
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}