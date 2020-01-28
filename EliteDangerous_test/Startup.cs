using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EliteDangerous_test.Startup))]
namespace EliteDangerous_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
