using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sinal.Startup))]
namespace sinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
