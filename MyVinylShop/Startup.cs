using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyVinylShop.Startup))]
namespace MyVinylShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
