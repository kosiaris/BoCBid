using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoCBid.Startup))]
namespace BoCBid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
