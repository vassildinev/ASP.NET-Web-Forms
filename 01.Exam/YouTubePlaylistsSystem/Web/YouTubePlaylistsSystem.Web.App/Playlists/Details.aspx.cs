namespace YouTubePlaylistsSystem.Web.App.Playlists
{
    using Ninject;
    using System;
    using System.Web.UI;
    using Services.Data.Contracts;
    using Data.Models;
    using System.Collections.Generic;
    using Data.Helpers;

    public partial class Details : Page
    {
        [Inject]
        public IPlaylistsService Playlists { get; set; }

        public UrlHelper UrlHelper { get; set; }

        public Playlist Playlist { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UrlHelper = new UrlHelper();
            string playlistId = this.Request.QueryString["PlaylistId"];
            if (string.IsNullOrEmpty(playlistId))
            {
                this.Response.Redirect("~/Home.aspx");
            }
            else
            {
                Playlist playlist = this.Playlists.GetById(int.Parse(playlistId));
                this.Playlist = playlist;
                if (playlist == null)
                {
                    this.Response.Redirect("~/Error/NotFound.aspx");
                }
            }
        }

        public Playlist PrjectDetailsView_GetItem(int? id)
        {
            int playlistId = int.Parse(this.Request.QueryString["PlaylistId"]);
            return this.Playlists.GetById(playlistId);
        }

        public IEnumerable<Video> VideosRepeater_GetData()
        {
            return this.Playlist.Videos;
        }
    }
}