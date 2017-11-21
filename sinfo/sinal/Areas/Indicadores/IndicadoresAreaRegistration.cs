using System.Web.Mvc;

namespace sinal.Areas.Indicadores
{
    public class IndicadoresAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Indicadores";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Indicadores_default",
                "Indicadores/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "sinal.Areas.Indicadores.Controllers" }
            );
        }
    }
}