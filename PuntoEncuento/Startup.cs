using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PuntoEncuento.Startup))]
namespace PuntoEncuento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
