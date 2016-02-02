namespace YouTubePlaylistsSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class YouTubePlaylistsSystemDbContext : IdentityDbContext<User>, IYouTubePlaylistsSystemDbContext
    {
        private const string DbConnectionName = "DefaultConnection";

        public YouTubePlaylistsSystemDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Video> Videos { get; set; }

        public IDbSet<Playlist> Playlists { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public static YouTubePlaylistsSystemDbContext Create()
        {
            return new YouTubePlaylistsSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
