using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    public class StudentChoiceFillingNicheController : Controller
    {
        // GET: admission/StudentChoiceFillingNiche
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Index()
        {
            return View();
        }
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Basic()
        {
            return View();
        }
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult SelectDisciplines()
        {
            return View();
        }
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult ChoiceFilling()
        {
            return View();
        }
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult UploadDocs()
        {
            return View();
        }
        [NoDirectAccessLearner]
        [CloseStudentChoiceFilling]
        [SessionExpireStudent]
        public ActionResult Submit()
        {
            return View();
        }
    }
}