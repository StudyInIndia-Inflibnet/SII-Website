using System.Web.Mvc;

namespace SII.Areas.planyourstay
{
    public class planyourstayAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "planyourstay";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "planyourstay_default",
                "planyourstay/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}