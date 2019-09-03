using jim.Frontal.infraestructura;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jim.Frontal.Startup))]
namespace jim.Frontal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ManagerMenus.GenerarListaControladores();
        }

        
    }
}
