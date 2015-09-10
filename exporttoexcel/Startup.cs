using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(exporttoexcel.Startup))]
namespace exporttoexcel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
