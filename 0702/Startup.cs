using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_0702.Startup))]
namespace _0702
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
