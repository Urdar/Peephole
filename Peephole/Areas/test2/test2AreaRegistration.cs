using System.Web.Mvc;

namespace Peephole.Areas.test2
{
    public class test2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "test2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "test2_default",
                "test2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}