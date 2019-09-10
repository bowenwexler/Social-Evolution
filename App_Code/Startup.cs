using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BRDR_Capstone.Startup))]
namespace BRDR_Capstone
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
