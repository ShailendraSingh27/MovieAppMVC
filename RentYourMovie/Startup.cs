using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentYourMovie.Startup))]
namespace RentYourMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
