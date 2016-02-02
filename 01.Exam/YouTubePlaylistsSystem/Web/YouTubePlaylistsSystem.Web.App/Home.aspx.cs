namespace YouTubePlaylistsSystem.Web.App
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Home : Page
    {
        [Inject]
        public IPlaylistsService Playlists { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Playlist> TopPlaylistsGridView_GetData()
        {
            return this.Playlists
                .GetAll()
                .OrderByDescending(p => Math.Round((double)p.RatingsReceived
                                    .Sum(r => r.Value) / p.RatingsReceived.Count, 1))
                .Take(10);
        }
    }
}