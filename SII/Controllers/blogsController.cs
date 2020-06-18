using SIIRepository.Adminservice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Controllers
{
    public class blogsController : Controller
    {
        // GET: blogs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Page(string id = "")
        {
            if (id == "")
            {
                return Redirect("~/blogs");
            }
            else
            {
                try
                {
                    BlogPost_Repository _obRepo = new BlogPost_Repository();
                    DataSet _ds = _obRepo.SELECT_BLOGPOST_BY_UNIQUECODE(id);
                    if (_ds != null)
                    {
                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            ViewBag.UniqueCode = _dr["UniqueCode"].ToString();
                            ViewBag.BlogTitle = _dr["BlogTitle"].ToString();
                            ViewBag.BlogContent = _dr["BlogContent"].ToString();
                            ViewBag.BlogImage = _dr["BlogImage"].ToString();

                            ViewBag.BlogMetaTags = _dr["BlogMetaTags"].ToString();
                            ViewBag.BlogMetaTags = _dr["BlogMetaTags"].ToString();
                            ViewBag.BlogMetaDescription = _dr["BlogMetaDescription"].ToString();
                            ViewBag.CreatedDate = Convert.ToDateTime(_dr["CreatedDate"].ToString()).ToString("dd-MMM-yy");
                            ViewBag.CreatedTime = Convert.ToDateTime(_dr["CreatedDate"].ToString()).ToString("hh:mm tt");

                            string[] BlogTag;
                            BlogTag = _dr["BlogTag"].ToString().Split(',');
                            ViewBag.BlogTag = BlogTag;
                        }
                    }
                    else
                    {
                        return Redirect("~/blogs");
                    }
                }
                catch (Exception)
                {
                    return Redirect("~/blogs");
                }
            }
            return View();
        }
    }
}