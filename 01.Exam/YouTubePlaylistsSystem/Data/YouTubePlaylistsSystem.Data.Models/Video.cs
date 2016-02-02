namespace YouTubePlaylistsSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        private ICollection<Playlist> playlists;

        public Video()
        {
            this.playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Video url cannot be more than 100 characters")]
        public string Url { get; set; }

        public virtual ICollection<Playlist> Playlists
        {
            get { return this.playlists; }
            set { this.playlists = value; }
        }
    }
}
