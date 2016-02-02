namespace YouTubePlaylistsSystem.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Repositories.Contracts;

    public class VideosService : IVideosService
    {
        private readonly IRepository<Video> videos;

        public VideosService(IRepository<Video> videos)
        {
            this.videos = videos;
        }

        public Video GetByUrl(string url)
        {
            return this.videos.All().Where(v => v.Url == url).FirstOrDefault();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
