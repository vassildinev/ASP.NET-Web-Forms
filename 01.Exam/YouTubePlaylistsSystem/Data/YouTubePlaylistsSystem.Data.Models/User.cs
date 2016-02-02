namespace YouTubePlaylistsSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Playlist> playlists;
        private ICollection<Rating> ratingsMade;

        public User()
            : base()
        {
            this.playlists = new HashSet<Playlist>();
            this.ratingsMade = new HashSet<Rating>();
        }

        [Required]
        [MaxLength(30, ErrorMessage = "First name cannot be more than 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Last name cannot be more than 30 characters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Profile image url cannot be more than 100 characters")]
        public string ProfileImageUrl { get; set; }

        [MaxLength(100, ErrorMessage = "Facebook account url cannot be more than 100 characters")]
        public string FacebookAccountUrl { get; set; }

        [MaxLength(100, ErrorMessage = "YouTube account url cannot be more than 100 characters")]
        public string YouTubeAccountUrl { get; set; }

        public virtual ICollection<Playlist> Playlists
        {
            get { return this.playlists; }
            set { this.playlists = value; }
        }

        public virtual ICollection<Rating> RatingsMade
        {
            get { return this.ratingsMade; }
            set { this.ratingsMade = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            ClaimsIdentity userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
