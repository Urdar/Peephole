using System.Web.Mvc;

namespace Peephole.Areas.TransferFunds
{
    public class TransferFundsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TransferFunds";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TransferFunds_default",
                "TransferFunds/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            AreasHandling.insertInMenu(context.AreaName);
        }
    }
}