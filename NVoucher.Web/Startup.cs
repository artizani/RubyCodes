using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NVoucher.Web.Startup))]
namespace NVoucher.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
