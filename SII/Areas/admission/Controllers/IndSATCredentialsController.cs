using iTextSharp.text;
using iTextSharp.text.pdf;
using SIIRepository.StudentRegService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.admission.Controllers
{
    [SessionExpireStudent]
    public class IndSATCredentialsController : Controller
    {
        // GET: admission/IndSATCredentials
        public ActionResult Index()
        {
            #region Country Wise Time
            if (Session["CountryID"].ToString() == "4")
            {
                ViewBag.ReportingTime = "1400 HRS";
                ViewBag.ExaminationTime = "1430 HRS";
            }
            else if (Session["CountryID"].ToString() == "5")
            {
                ViewBag.ReportingTime = "1400 HRS";
                ViewBag.ExaminationTime = "1430 HRS";
            }
            else if (Session["CountryID"].ToString() == "8")
            {
                ViewBag.ReportingTime = "1100 HRS";
                ViewBag.ExaminationTime = "1130 HRS";
            }
            else if (Session["CountryID"].ToString() == "16")
            {
                ViewBag.ReportingTime = "1345 HRS";
                ViewBag.ExaminationTime = "1415 HRS";
            }
            else if (Session["CountryID"].ToString() == "19")
            {
                ViewBag.ReportingTime = "1000 HRS";
                ViewBag.ExaminationTime = "1030 HRS";
            }
            else if (Session["CountryID"].ToString() == "21")
            {
                ViewBag.ReportingTime = "1330 HRS";
                ViewBag.ExaminationTime = "1400 HRS";
            }
            else if (Session["CountryID"].ToString() == "25")
            {
                ViewBag.ReportingTime = "1100 HRS";
                ViewBag.ExaminationTime = "1130 HRS";
            }
            else if (Session["CountryID"].ToString() == "128")
            {
                ViewBag.ReportingTime = "1500 HRS";
                ViewBag.ExaminationTime = "1530 HRS";
            }
            else if (Session["CountryID"].ToString() == "137")
            {
                ViewBag.ReportingTime = "1100 HRS";
                ViewBag.ExaminationTime = "1130 HRS";
            }
            else if (Session["CountryID"].ToString() == "159")
            {
                ViewBag.ReportingTime = "1200 HRS";
                ViewBag.ExaminationTime = "1230 HRS";
            }
            else if (Session["CountryID"].ToString() == "239")
            {
                ViewBag.ReportingTime = "1100 HRS";
                ViewBag.ExaminationTime = "1130 HRS";
            }
            else if (Session["CountryID"].ToString() == "250")
            {
                ViewBag.ReportingTime = "1000 HRS";
                ViewBag.ExaminationTime = "1030 HRS";
            }
            else if (Session["CountryID"].ToString() == "252")
            {
                ViewBag.ReportingTime = "1330 HRS";
                ViewBag.ExaminationTime = "1400 HRS";
            }
            #endregion

            DataSet _ds = (new StudentRepository()).CHECK_UG_PG_PHD_STUDENT_CH(Session["studentid"].ToString());
            if (_ds != null)
            {
                if (_ds.Tables[2].Rows.Count > 0)
                {
                    ViewBag.PL = _ds.Tables[2].Rows[0]["PL"].ToString();
                    if (_ds.Tables[2].Rows[0]["PL"].ToString().ToLower() == "phd")
                    {
                        return Redirect("~/admission/dashboard");
                    }
                }
            }
            

            return View();
        }
        public ActionResult GeneratePDF()
        {
            string path = "";
            string fileName = "";
            string fullPath = "";
            try
            {
                #region Create PDF File
                MemoryStream workStream = new MemoryStream();
                StringBuilder status = new StringBuilder();
                DateTime dTime = DateTime.Now;
                //string InstituteID = Session["studentid"].ToString();
                Document _doc = new Document();
                _doc.SetMargins(12f, 12f, 10f, 10f);
                _doc.SetPageSize(PageSize.A4);

                //string pdffilename = Session["studentid"].ToString();
                string pdffilename = Session["studentid"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss");

                string physicalPath = "~/Uploads/IndSATCredential/";
                path = Server.MapPath(physicalPath + pdffilename + ".pdf");
                fullPath = physicalPath + "/" + pdffilename + ".pdf";
                fileName = Server.MapPath(physicalPath);

                if (!Directory.Exists(fileName))
                {
                    Directory.CreateDirectory(fileName);
                }
                else
                {
                    string[] curentfiles = Directory.GetFiles(fileName);
                    foreach (string curentfile in curentfiles)
                    {
                        if (curentfile.IndexOf(pdffilename + ".pdf") >= 0)
                            System.IO.File.Delete(curentfile);
                    }
                }
                PdfWriter.GetInstance(_doc, new FileStream(Server.MapPath(physicalPath + pdffilename + ".pdf"), FileMode.Create));
                #endregion
                try
                {
                    _doc.Open();
                    _doc.AddTitle("Ind-SAT 2020");
                    _doc.AddAuthor("Ind-SAT 2020");
                    _doc.AddCreationDate();
                    _doc.AddCreator("Ind-SAT 2020");
                    _doc.AddHeader("Ind-SAT 2020", "Ind-SAT 2020");

                    #region PDF Header
                    PdfPTable tableLayout = new PdfPTable(3);
                    tableLayout.WidthPercentage = 100;


                    #region MHRD Logo
                    Image MHRD_Logo = Image.GetInstance(Server.MapPath("~/") + "img/IndSAT/MHRD_PDF.png");
                    MHRD_Logo.WidthPercentage = 10;
                    tableLayout.AddCell(new PdfPCell(MHRD_Logo)
                    {
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });
                    #endregion

                    #region SII Logo
                    Image SII_Logo = Image.GetInstance(Server.MapPath("~/") + "img/IndSAT/SII_PDF.png");
                    SII_Logo.WidthPercentage = 10;
                    tableLayout.AddCell(new PdfPCell(SII_Logo)
                    {
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });
                    #endregion


                    #region NTA Logo
                    Image NTA_Logo = Image.GetInstance(Server.MapPath("~/") + "img/IndSAT/NTA_PDF.png");
                    NTA_Logo.WidthPercentage = 20;
                    tableLayout.AddCell(new PdfPCell(NTA_Logo)
                    {
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });
                    #endregion


                    tableLayout.AddCell(new PdfPCell()
                    {
                        Colspan = 3,
                        Border = 0,
                        BorderWidthTop = 1,
                        PaddingBottom = 25,
                    });
                    
                    _doc.Add(tableLayout);
                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _doc.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Redirect(fullPath);
        }
        #region PDF Cell Methods
        private static void AddCellForPageHeader(PdfPTable tableLayout, string pageTitle)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(pageTitle, new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, new BaseColor(0, 33, 71))))
            {
                Colspan = 24,
                Border = 0,
                PaddingTop = 15,
                PaddingBottom = 3,
                HorizontalAlignment = Element.ALIGN_LEFT
            });
            //if (pageSubTitle != "")
            //{
            //    tableLayout.AddCell(new PdfPCell(new Phrase(pageSubTitle, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, new BaseColor(0, 33, 71))))
            //    {
            //        Colspan = 24,
            //        Border = 0,
            //        PaddingTop = 0,
            //        PaddingBottom = 5,
            //        HorizontalAlignment = Element.ALIGN_LEFT
            //    });
            //}
            tableLayout.AddCell(new PdfPCell()
            {
                Colspan = 24,
                Border = 0,
                BorderWidthTop = 1,
                PaddingBottom = 25,
            });
        }

        private static void AddCellToHeader(PdfPTable tableLayout, string cellText, int rowSpan = 1, int colSpan = 1)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, new BaseColor(255, 255, 255))))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Rowspan = rowSpan,
                Colspan = colSpan,
                Padding = 5,
                BackgroundColor = new BaseColor(0, 33, 71)
            });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText, int index, int align = 0, int FontWeight = 0, int rowSpan = 1, int colSpan = 1, int fontSize = 7)
        {
            if (index % 2 == 0)
            {
                tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, fontSize, FontWeight, iTextSharp.text.BaseColor.BLACK)))
                {
                    HorizontalAlignment = align,
                    Padding = 5,
                    Rowspan = rowSpan,
                    Colspan = colSpan,
                    BackgroundColor = new iTextSharp.text.BaseColor(239, 239, 239)
                });
            }
            else
            {
                tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, fontSize, FontWeight, iTextSharp.text.BaseColor.BLACK)))
                {
                    HorizontalAlignment = align,
                    Padding = 5,
                    Rowspan = rowSpan,
                    Colspan = colSpan,
                    BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
                });
            }
        }
        private static void AddCellToBodyNA(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD, iTextSharp.text.BaseColor.RED)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }

        #endregion
    }
    public class mExaminationTime
    {
        public string Country_id { get; set; }
        public string ReportingTime { get; set; }
        public string ExaminationTime { get; set; }
    }

}