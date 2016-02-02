namespace YouTubePlaylistsSystem.Web.App.Playlists
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Ninject;
    using Services.Data.Contracts;

    public partial class All : Page
    {
        [Inject]
        public IPlaylistsService Playlists { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Playlist> AllPlaylistsGridView_GetData()
        {
            string categoryId = this.Server.HtmlEncode(this.Request.QueryString["CategoryId"]);
            string searchText = this.Server.HtmlEncode(this.Request.QueryString["Search"]);
            if (!string.IsNullOrEmpty(categoryId))
            {
                return this.Playlists.GetByCategoryId(int.Parse(categoryId)).OrderBy(p => p.Id);
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                return this.Playlists
                    .GetAll()
                    .Where(p => p.Title.IndexOf(searchText) > -1 || p.Description.IndexOf(searchText) > -1)
                    .OrderBy(p => p.Id);
            }

            return this.Playlists.GetAll().OrderBy(p => p.Id);
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            string toSearch = this.Server.HtmlEncode(this.SearchTextBox.Text);
            this.Response.Redirect("~/Playlists/All.aspx?Search=" + toSearch);
        }
    }
}