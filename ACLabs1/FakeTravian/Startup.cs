using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeTravian.Startup))]
namespace FakeTravian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
