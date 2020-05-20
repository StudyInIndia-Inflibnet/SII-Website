using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIRepository.Adminservice;

namespace SII.Areas.Admin.Controllers
{
    public class ConvertBase64ToImageController : Controller
    {
        // GET: Admin/ConvertBase64ToImage
        public ActionResult Index()
        {
            Phase3_Repository _objRepo = new Phase3_Repository();
            DataSet _ds = _objRepo.Opr_ConvertImages("SELECT");
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        string studentid = _dr["studentid"].ToString();
                        string path = "Uploads/StudentPhotoSignature/" + studentid + "/";
                        string AbsolutePath = Server.MapPath("~/" + path);
                        string filename = "Photo" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                        string savingFilePhoto = "Photo" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                        string savingFileSignature = "Signature" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                        if (!Directory.Exists(AbsolutePath))
                        {
                            Directory.CreateDirectory(AbsolutePath);
                        }
                        DataSet _dsStudent = _objRepo.Opr_ConvertImages("SELECTSTUD", studentid);
                        if (_dsStudent != null)
                        {
                            if (_dsStudent.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow _drStudent in _dsStudent.Tables[0].Rows)
                                {
                                    ConvertImage(_drStudent["Photo"].ToString(), path, savingFilePhoto);
                                    ConvertImage(_drStudent["Signature"].ToString(), path, savingFileSignature);
                                }
                                DataSet _dsUpdate = _objRepo.Opr_ConvertImages("UPDATE", studentid, path + savingFilePhoto, path + savingFileSignature);
                            }
                        }

                    }
                }
            }
            return View();
        }
        private void ConvertImage(string base64, string path, string filename)
        {
            byte[] imageBytes = Convert.FromBase64String(base64);

            //Save the Byte Array as Image File.
            string filePath = Server.MapPath("~/" + path + filename);
            System.IO.File.WriteAllBytes(filePath, imageBytes);
        }
    }
}