using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityAndOAuth.Startup))]
namespace IdentityAndOAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
