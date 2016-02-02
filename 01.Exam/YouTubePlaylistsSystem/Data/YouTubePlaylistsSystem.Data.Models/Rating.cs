using System.ComponentModel.DataAnnotations;

namespace YouTubePlaylistsSystem.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating cannot be less than 1 or more than 5 inclusive")]
        public int Value { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
