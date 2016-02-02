using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Services.Data.Contracts;

namespace YouTubePlaylistsSystem.Web.App.Categories
{
    public partial class All : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesService Categories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<YouTubePlaylistsSystem.Data.Models.Category> CategoriesGridView_GetData()
        {
            return this.Categories.All().OrderBy(c => c.Id);
        }
    }
}