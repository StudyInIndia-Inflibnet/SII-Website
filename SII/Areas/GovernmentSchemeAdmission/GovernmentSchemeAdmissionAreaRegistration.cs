using System.Web.Mvc;

namespace SII.Areas.GovernmentSchemeAdmission
{
    public class GovernmentSchemeAdmissionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GovernmentSchemeAdmission";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GovernmentSchemeAdmission_default",
                "GovernmentSchemeAdmission/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}