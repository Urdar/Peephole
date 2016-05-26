using System.Web.Mvc;

namespace Peephole.Areas.Redirect
{
    public class RedirectRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Redirect";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Redirect_default",
                "Redirect/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }


            );
            AreasHandling.insertInMenu(context.AreaName);
            
        }
    }
}