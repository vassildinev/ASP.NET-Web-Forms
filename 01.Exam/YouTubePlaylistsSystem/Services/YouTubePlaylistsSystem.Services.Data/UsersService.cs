namespace YouTubePlaylistsSystem.Services.Data
{
    using Contracts;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Repositories.Contracts;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public void UpdateUser(User user)
        {
            this.users.Update(user);
        }

        public int SaveChanges()
        {
            return this.users.SaveChanges();
        }
    }
}
