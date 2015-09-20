using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoryBook.Startup))]
namespace StoryBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
