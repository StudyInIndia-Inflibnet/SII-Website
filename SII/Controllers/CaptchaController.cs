using SRVTextToImage;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public FileResult GetCaptchaImage()
        {
            this.Session.Remove("CaptchaImageText");
            CaptchaRandomImage CI = new CaptchaRandomImage();
            Random random = new Random();
            //string combination = "123456789ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            string combination = "0123456789";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 4; i++)
#pragma warning disable SCS0005 // Weak random generator
                captcha.Append(combination[random.Next(combination.Length)]);
#pragma warning restore SCS0005 // Weak random generator
            this.Session["CaptchaImageText"] = captcha.ToString();
            CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75);
            MemoryStream stream = new MemoryStream();
            CI.Image.Save(stream, ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "image/png");
        }
    }
}