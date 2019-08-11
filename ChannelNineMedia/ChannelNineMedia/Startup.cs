using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChannelNineMedia.Startup))]
namespace ChannelNineMedia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
