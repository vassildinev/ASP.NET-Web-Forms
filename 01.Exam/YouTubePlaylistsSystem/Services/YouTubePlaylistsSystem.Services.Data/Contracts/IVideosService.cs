namespace YouTubePlaylistsSystem.Services.Data.Contracts
{
    using YouTubePlaylistsSystem.Data.Models;

    public interface IVideosService
    {
        Video GetByUrl(string url);

        int SaveChanges();
    }
}
