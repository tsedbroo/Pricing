using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chipoltle.Startup))]
namespace chipoltle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
