using System.Web;
using System.Web.Optimization;

namespace SII.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery.min.js",
                "~/js/bootstrap.min.js",
                "~/js/jquery.slicknav.min.js",
                "~/js/inview.js",
                "~/js/counter.js",
                "~/js/jquery.nice-select.min.js",
                "~/js/wow.min.js",
                "~/js/bootstrap-hover-dropdown.js",
                "~/js/owl.carousel.min.js",
                "~/js/active.js"
                ));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/nice-select.css",
                      "~/css/material-design-iconic-font.min.css",
                      "~/css/font-awesome.css",
                      "~/css/slicknav.min.css",
                      "~/css/hover.min.css",
                      "~/css/owl.carousel.css",
                      "~/css/nice-select.css",
                      "~/css/animate.min.css",
                      "~/css/style.default.css",
                      "~/css/style.css",
                      "~/css/responsive.css"
                      ));
        }
    }
}