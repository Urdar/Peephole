using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Peephole.Startup))]
namespace Peephole
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
