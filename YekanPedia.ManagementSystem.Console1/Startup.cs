using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YekanPedia.ManagementSystem.Console.Startup))]
namespace YekanPedia.ManagementSystem.Console
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
