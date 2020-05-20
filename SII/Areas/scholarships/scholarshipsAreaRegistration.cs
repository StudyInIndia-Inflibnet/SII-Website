using System.Web.Mvc;

namespace SII.Areas.scholarships
{
    public class scholarshipsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "scholarships";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "scholarships_default",
                "scholarships/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}