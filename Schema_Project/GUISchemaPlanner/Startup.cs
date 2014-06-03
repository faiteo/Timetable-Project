using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GUISchemaPlanner.Startup))]
namespace GUISchemaPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
