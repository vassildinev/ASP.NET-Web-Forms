using System.Linq;
using YouTubePlaylistsSystem.Data.Models;

namespace YouTubePlaylistsSystem.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        void Create(Category category);

        IQueryable<Category> All();

        int SaveChanges();
    }
}
