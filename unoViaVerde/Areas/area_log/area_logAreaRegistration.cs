using System.Web.Mvc;

namespace unoViaVerde.Areas.area_log
{
    public class area_logAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "area_log";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "area_log_default",
                "area_log/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}