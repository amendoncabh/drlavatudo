using System.Web.Mvc;

namespace ns.drlavatudo.Areas.Pedidos
{
    public class PedidosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pedidos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pedidos_default",
                "Pedidos/{controller}/{action}/{id}",
                new { controller = "Pedidos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}