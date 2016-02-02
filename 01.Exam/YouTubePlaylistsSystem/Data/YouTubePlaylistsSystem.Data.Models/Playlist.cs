namespace YouTubePlaylistsSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Playlist
    {
        private ICollection<Video> videos;
        private ICollection<Rating> ratingsReceived;

        public Playlist()
        {
            this.videos = new HashSet<Video>();
            this.ratingsReceived = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage= "Title cannot be more than 30 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Description cannot be more than 150 characters")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        public virtual ICollection<Rating> RatingsReceived
        {
            get { return this.ratingsReceived; }
            set { this.ratingsReceived = value; }
        }
    }
}
