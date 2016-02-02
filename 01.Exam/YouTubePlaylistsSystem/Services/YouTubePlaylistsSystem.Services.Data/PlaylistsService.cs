namespace YouTubePlaylistsSystem.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Repositories.Contracts;

    public class PlaylistsService : IPlaylistsService
    {
        private readonly IRepository<Playlist> playlists;

        public PlaylistsService(IRepository<Playlist> playlists)
        {
            this.playlists = playlists;
        }

        public void Create(Playlist playlist)
        {
            this.playlists.Add(playlist);
        }

        public void CreatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Playlist> GetAll()
        {
            return this.playlists.All();
        }

        public IQueryable<Playlist> GetByCategoryId(int categoryId)
        {
            return this.playlists.All().Where(p => p.Category.Id == categoryId);
        }

        public Playlist GetById(int id)
        {
            return this.playlists.GetById(id);
        }

        public int SaveChanges()
        {
            return this.playlists.SaveChanges();
        }
    }
}
