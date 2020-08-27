using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCRUD1._1.Startup))]
namespace WebCRUD1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
