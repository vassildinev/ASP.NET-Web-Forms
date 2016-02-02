namespace YouTubePlaylistsSystem.Web.App.Playlists
{
    using System;
    using System.Web.UI;
    using Services.Data.Contracts;
    using Ninject;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    public partial class Create : Page
    {
        [Inject]
        public IPlaylistsService Playlists { get; set; }

        [Inject]
        public IVideosService Videos { get; set; }

        [Inject]
        public ICategoriesService Categories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var categories = this.Categories.All().Select(c => c.Name).ToList();
            this.CategorySelect.DataSource = categories;
            this.CategorySelect.SelectedIndex = 0;
            this.CategorySelect.DataBind();
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            var playlist = new Playlist()
            {
                Title = this.Server.HtmlEncode(this.TitleTextBox.Text),
                Description = this.Server.HtmlEncode(this.Description.Text),
                CreationDate = DateTime.UtcNow,
                CreatorId = this.User.Identity.GetUserId()
            };

            Video video = this.Videos.GetByUrl(this.Server.HtmlEncode(this.Url.Text));
            if (video == null)
            {
                video = new Video()
                {
                    Url = this.Server.HtmlEncode(this.Url.Text)
                };
            }

            Category category = this.Categories.All().Where(c => c.Name == this.CategorySelect.SelectedItem.Text).FirstOrDefault();

            playlist.Category = category;
            playlist.Videos.Add(video);

            this.Playlists.Create(playlist);
            this.Playlists.SaveChanges();
        }
    }
}