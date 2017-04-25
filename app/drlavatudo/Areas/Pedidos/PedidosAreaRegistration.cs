using System.Web.Mvc;

namespace app.drlavatudo.Areas.Pedidos
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
                name:"Pedidos_default",
                url: "Pedidos/{controller}/{action}/{id}",
                defaults: new { controller = "Pedidos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}