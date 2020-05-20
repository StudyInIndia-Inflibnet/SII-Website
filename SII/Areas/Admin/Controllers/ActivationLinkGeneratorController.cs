using Newtonsoft.Json;
using SIIModel.StudentRegister;
using SIIRepository.Institute;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    public class ActivationLinkGeneratorController : Controller
    {
        [SessionExpireAdmin]
        // GET: Admin/ActivationLinkGenerator
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Generate()
        {
            string Message = string.Empty, Code = string.Empty, Error = string.Empty;
            try
            {
                StudentRepository _objRepository = new StudentRepository();
                DataSet _dsInstituteListForGeneration = _objRepository.Opr_GenerateStudentDtl("SelectActivationLinkNotSent");
                if (_dsInstituteListForGeneration != null)
                {
                    if (_dsInstituteListForGeneration.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _dr in _dsInstituteListForGeneration.Tables[0].Rows)
                        {
                            DateTime _datetime = DateTime.Now;
                            #region Generate Link If Needed
                            _objRepository = new StudentRepository();
                            string studentid = _dr["studentid"].ToString();
                            string Email = _dr["Email"].ToString();
                            string StudentName = _dr["StudentName"].ToString();
                            string Country_Name = _dr["Country_Name"].ToString();

                            string AccessURL = "";
                            if (_dr["ActivationLink"].ToString() == "")
                            {
                                AccessURL = "https://www.studyinindia.gov.in/admission/login?eid=" + Encrypt_Decrypt.EncryptData(Email, "");
                            }
                            else
                            {
                                AccessURL = _dr["ActivationLink"].ToString();
                            }


                            DataSet _ds = _objRepository.Opr_GenerateStudentDtl("Update", studentid, AccessURL);
                            #endregion

                            #region Call PivotRoots Code
                            string strUrl = "https://pivotroots.com/clients/studyinindia/webhooks/user_events";
                            WebRequest request = HttpWebRequest.Create(strUrl);
                            request.Headers.Add("Request-Id", DateTime.Now.ToString("yyyyMMddhhmmss"));
                            request.Method = "POST";
                            request.ContentType = "application/json";
                            request.Headers.Add("Client-Id", "b7a51eff57749dc0e733b74342c8b512");
                            request.Headers.Add("Client-Access-Token", "dfdd5aa8ea4a1e2fb5999dc213476c2a9b68efa7");
                            mWebhookRequestRegistration _objJsonRequest = new mWebhookRequestRegistration()
                            {
                                timestamp = DateTime.Now.ToString("yyyyMMddhhmmss"),
                                user_id = studentid,
                                @event = "new_registration",
                                userName = StudentName,
                                emailID = Email,
                                activationLink = AccessURL,
                                Country = Country_Name
                            };
                            string data = JsonConvert.SerializeObject(_objJsonRequest);
                            byte[] dataStream = Encoding.UTF8.GetBytes(data);
                            request.ContentLength = dataStream.Length;
                            Stream r = request.GetRequestStream();
                            r.Write(dataStream, 0, dataStream.Length);
                            r.Close();
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream s = (Stream)response.GetResponseStream();
                            StreamReader readStream = new StreamReader(s);
                            string dataString = readStream.ReadToEnd();
                            mWebhook _response = JsonConvert.DeserializeObject<mWebhook>(dataString);
                            if (_response.reason == "SUCCESS")
                            {
                                DataSet dsMailSend = _objRepository.Opr_GenerateStudentDtl("ActivationLinkSent", studentid, AccessURL, "1", "Mail Sent", "");
                            }
                            response.Close();
                            s.Close();
                            readStream.Close();
                            #endregion

                            DateTime _NextDatetime = _datetime.AddSeconds(5);
                        g: { }
                            if (DateTime.Now <= _NextDatetime)
                            {
                                goto g;
                            }
                        }
                        Message = "Activation links sent!";
                        Code = "success";
                    }
                }
                else
                {
                    Message = "Error from server side. Kindly refresh the page and try again.";
                    Code = "servererror";
                }
            }
            catch (NullReferenceException ex)
            {
                Message = "Your session has been expired. Kindly login again.";
                Code = "sessionexpired";
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Message = "Error from server side. Kindly refresh the page and try again.";
                Code = "servererror";
                Error = ex.Message;
            }

            return Json(new
            {
                m = Message,
                c = Code,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
    }
}