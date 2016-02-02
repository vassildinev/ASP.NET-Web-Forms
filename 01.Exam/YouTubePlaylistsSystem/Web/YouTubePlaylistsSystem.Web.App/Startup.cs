[assembly: Microsoft.Owin.OwinStartup(typeof(YouTubePlaylistsSystem.Web.App.Startup))]
namespace YouTubePlaylistsSystem.Web.App
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
