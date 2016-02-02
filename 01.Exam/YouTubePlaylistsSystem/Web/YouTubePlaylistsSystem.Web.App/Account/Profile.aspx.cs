namespace YouTubePlaylistsSystem.Web.App.Account
{
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;
    using System.Collections.Generic;

    public partial class Profile : Page
    {
        [Inject]
        public IUsersService Users { get; set; }

        public User UserDetailsView_GetItem(int? id)
        {
            string userId = this.User.Identity.GetUserId();
            return this.Users.GetById(userId);
        }

        public IEnumerable<Playlist> UserPlaylistsRepeater_GetData()
        {
            string userId = this.User.Identity.GetUserId();
            this.ProfileImageUrl.ImageUrl = this.Users.GetById(userId).ProfileImageUrl;
            return this.Users.GetById(userId).Playlists;
        }
    }
}