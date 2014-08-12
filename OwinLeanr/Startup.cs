using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OwinLeanr.Startup))]
namespace OwinLeanr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
