namespace YouTubePlaylistsSystem.Services.Data.Contracts
{
    using System.Linq;

    using YouTubePlaylistsSystem.Data.Models;

    public interface IPlaylistsService
    {
        IQueryable<Playlist> GetAll();

        Playlist GetById(int id);

        void CreatePlaylist(Playlist playlist);

        int SaveChanges();

        IQueryable<Playlist> GetByCategoryId(int categoryId);
        void Create(Playlist playlist);
    }
}
