using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeriaDelLibro2.Startup))]
namespace FeriaDelLibro2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
