using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book_Rental.Startup))]
namespace Book_Rental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
