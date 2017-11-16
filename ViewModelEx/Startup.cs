using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViewModelEx.Startup))]
namespace ViewModelEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
