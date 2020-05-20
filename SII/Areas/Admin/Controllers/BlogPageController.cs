using SIIModel.Admin;
using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SII.Areas.Admin.Controllers
{
    [SessionExpireAdmin]
    public class BlogPageController : Controller
    {
        // GET: Admin/BlogPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Page(string id = "0")
        {
            ViewBag.Blog_Id = id;
            return View();
        }
        [HttpPost]
#pragma warning disable SCS0017 // Request validation is disabled
        [ValidateInput(false)]
#pragma warning restore SCS0017 // Request validation is disabled
        [ValidateAntiForgeryToken]
        public JsonResult SaveBlog(mBlogPost _obj)
        {
            bool flag = false;
            string path = "";
            string filename = "";
            string fname = "";
            string Message = string.Empty, Code = string.Empty, Error= string.Empty;
            try
            {
                if (Request.Files.Count > 0)
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        path = AppDomain.CurrentDomain.BaseDirectory + "img/blogs/";
                        filename = _obj.UniqueCode + Path.GetExtension(Request.Files[0].FileName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {
                            string[] curentfiles = Directory.GetFiles(path);
                            //Directory.Delete(path + "/" + filename);
                        }
                        HttpPostedFileBase file = files[0];
                        filename = _obj.UniqueCode + Path.GetExtension(file.FileName);
                        fname = Path.Combine(Server.MapPath("~/img/blogs/"), filename);
                        file.SaveAs(fname);
                        _obj.BlogImage = "img/blogs/" + filename;
                    }
                    else
                    {
                        _obj.BlogImage = "";
                    }
                }
                else
                {
                    _obj.BlogImage = "";
                }
                _obj.CreatedBy = Session["User_id"].ToString();
                _obj.CreatedIP = Session["localIP"].ToString();
                BlogPost_Repository _objRepo = new BlogPost_Repository();
                DataSet _ds = _objRepo.INSERT_UPDATE_BLOGPOST(_obj);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "1")
                        {
                            Message = "Blog details has been successfully saved!";
                            Code = "success";
                            flag = true;
                        }
                        else if (_ds.Tables[0].Rows[0]["COUNTS"].ToString() == "-1")
                        {
                            Message = "Blog's unique code details are already exists!";
                            Code = "alreadyexists";
                        }
                    }
                    else
                    {
                        Message = "Error from server side. Kindly refresh the page and try again.";
                        Code = "servererror";
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
                flag = flag,
                m = Message,
                c = Code,
                e = Error
            },
                JsonRequestBehavior.AllowGet
            );
        }
        public JsonResult SelectBlog(mBlogPost _obj)
        {
            string Message = string.Empty, Code = string.Empty;
            List<mBlogPost> _list = new List<mBlogPost>();
            try
            {
                BlogPost_Repository _objRepo = new BlogPost_Repository();
                DataSet _ds = _objRepo.SELECT_BLOGPOST(_obj);
                if (_ds != null)
                {
                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _list.Add(new mBlogPost
                        {
                            Blog_Id = _dr["Blog_Id"].ToString(),
                            BlogTitle = _dr["BlogTitle"].ToString(),
                            UniqueCode = _dr["UniqueCode"].ToString(),
                            BlogContent = _dr["BlogContent"].ToString(),
                            BlogImage = _dr["BlogImage"].ToString(),
                            BlogTag = _dr["BlogTag"].ToString(),
                            BlogMetaTags = _dr["BlogMetaTags"].ToString(),
                            BlogMetaDescription = _dr["BlogMetaDescription"].ToString(),
                            CreatedBy = _dr["CreatedBy"].ToString()
                        });
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {

            }
            var jsonResult = Json(new
            {
                m = Message,
                c = Code,
                List = _list
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}