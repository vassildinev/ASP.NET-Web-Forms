namespace YouTubePlaylistsSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Playlist> playlists;

        public Category()
        {
            this.playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category name cannot be more than 50 characters")]
        public string Name { get; set; }

        public virtual ICollection<Playlist> Playlists
        {
            get { return this.playlists; }
            set { this.playlists = value; }
        }
    }
}
