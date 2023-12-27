using System.Web.Mvc;

namespace SachOnline3.Areas.admins
{
    public class adminsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admins_default",
                "admins/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}