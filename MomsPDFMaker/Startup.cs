using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MomsPDFMaker.Startup))]
namespace MomsPDFMaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
