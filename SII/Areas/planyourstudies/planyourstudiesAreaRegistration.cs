using System.Web.Mvc;

namespace SII.Areas.planyourstudies
{
    public class planyourstudiesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "planyourstudies";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "planyourstudies_default",
                "planyourstudies/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}