using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenGateLogistics.Startup))]
namespace OpenGateLogistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
