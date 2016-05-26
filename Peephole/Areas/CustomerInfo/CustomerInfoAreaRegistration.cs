using System.Web.Mvc;

namespace Peephole.Areas.CustomerInfo
{
    public class CustomerInfoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerInfo_default",
                "CustomerInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            AreasHandling.insertInMenu(context.AreaName);
        }
    }
}