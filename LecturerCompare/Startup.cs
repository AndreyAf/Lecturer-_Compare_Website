using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LecturerCompare.Startup))]
namespace LecturerCompare
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
