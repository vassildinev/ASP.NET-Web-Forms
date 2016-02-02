namespace YouTubePlaylistsSystem.Services.Data.Contracts
{
    using YouTubePlaylistsSystem.Data.Models;

    public interface IUsersService
    {
        User GetById(string userId);

        int SaveChanges();

        void UpdateUser(User currentUser);
    }
}
