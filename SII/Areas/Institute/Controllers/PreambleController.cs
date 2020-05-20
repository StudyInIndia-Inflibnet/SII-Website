using SII.Models;
using SIIModel.Institute;
using SIIRepository.Institute;
using System;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace SII.Areas.Institute.Controllers
{
    public class PreambleController : Controller
    {
        // GET: Institute/Preamble
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index(string u = "")
        {
            ViewBag.InstituteAvailable = "No";
            try
            {
                string InstituteID = StringCipher.Decrypt(u);
                InstituteRepository _objRepository = new InstituteRepository();
                DataSet _dsInstituteListForGeneration = _objRepository.Select_Institute_By_InstituteID(InstituteID);
                if (_dsInstituteListForGeneration != null)
                {
                    if (_dsInstituteListForGeneration.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _dsInstituteListForGeneration.Tables[0].Rows)
                        {
                            ViewBag.ID = _dr["ID"].ToString();
                            ViewBag.InstituteID = _dr["InstituteID"].ToString();
                            ViewBag.InstituteName = _dr["InstituteName"].ToString();

                            ViewBag.InstituteAvailable = "Yes";
                        }
                    }
                }

            }
            catch (Exception)
            {
                ViewBag.InstituteAvailable = "No";
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save_Nodal_Head_Details(mNodalHeadOfficers _obj)
        {
            string flag = "0";
            try
            {

                #region Encript Password
                Random rn = new Random();
#pragma warning disable SCS0005 // Weak random generator
                int month = rn.Next(1, 6);
#pragma warning restore SCS0005 // Weak random generator
                StringBuilder hashPassword = new StringBuilder();
                string new_password = _obj.Password;
                switch (month)
                {
                    case 1:
                        hashPassword.Append(Helper.ComputeHash(new_password, "MD5", null));
                        break;

                    case 2:
                        hashPassword.Append(Helper.ComputeHash(new_password, "SHA1", null));
                        break;

                    case 3:
                        hashPassword.Append(Helper.ComputeHash(new_password, "SHA256", null));
                        break;

                    case 4:
                        hashPassword.Append(Helper.ComputeHash(new_password, "SHA384", null));
                        break;

                    case 5:
                        hashPassword.Append(Helper.ComputeHash(new_password, "SHA512", null));
                        break;
                }
                _obj.Password = hashPassword.ToString();
                #endregion
                //_obj.Password = StringCipher.Encrypt(_obj.Password);
                InstituteRepository _objRepository = new InstituteRepository();
                string localIP = "?";
                localIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                _obj.CreatedIP = localIP;
                DataSet _ds = _objRepository.Save_Preamble_Data(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        flag = _ds.Tables[0].Rows[0]["FLAG"].ToString();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
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