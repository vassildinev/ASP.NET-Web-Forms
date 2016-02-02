namespace YouTubePlaylistsSystem.Services.Data
{
    using System.Linq;

    using Contracts;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Repositories.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public void Create(Category category)
        {
            this.categories.Add(category);
        }

        public int SaveChanges()
        {
            return this.categories.SaveChanges();
        }
    }
}
