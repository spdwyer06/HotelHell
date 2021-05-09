using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelHell_Web.Startup))]
namespace HotelHell_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
