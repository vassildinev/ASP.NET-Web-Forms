namespace YouTubePlaylistsSystem.Web.App.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Data.Models;
    using ImageResizer;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Edit : Page
    {
        [Inject]
        public IUsersService Users { get; set; }

        public User CurrentUser { get; private set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string userIdToLoad = this.Request.Params["UserId"];
            if (string.IsNullOrEmpty(userIdToLoad))
            {
                this.Response.Redirect("~/Home");
            }
            else
            {
                string currentUserId = this.User.Identity.GetUserId();
                if (currentUserId != userIdToLoad)
                {
                    this.Response.Redirect("~/Errors/Forbidden.aspx");
                }
                else
                {
                    this.CurrentUser = this.Users.GetById(currentUserId);
                    if (this.CurrentUser == null)
                    {
                        this.Response.Redirect("~/Errors/NotFound.aspx");
                    }
                    else
                    {
                        this.FirstName.Text = this.CurrentUser.FirstName;
                        this.LastName.Text = this.CurrentUser.LastName;
                        this.FacebookAccountUrl.Text = this.CurrentUser.FacebookAccountUrl;
                        this.YouTubeAccountUrl.Text = this.CurrentUser.YouTubeAccountUrl;
                    }
                }
            }
        }

        protected void EditUserClick(object sender, EventArgs e)
        {
            string currentUserId = this.User.Identity.GetUserId();
            User user = this.Users.GetById(currentUserId);

            user.FirstName = this.Server.HtmlEncode(this.FirstName.Text);
            user.LastName = this.Server.HtmlEncode(this.LastName.Text);
            user.FacebookAccountUrl = this.Server.HtmlEncode(this.FacebookAccountUrl.Text);
            user.YouTubeAccountUrl = this.Server.HtmlEncode(this.YouTubeAccountUrl.Text);

            this.Users.UpdateUser(user);
            this.Users.SaveChanges();

            this.SaveProfileImageToServer();
            
            this.Response.Redirect("~/Account/Profile.aspx");
        }

        protected void CancelClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Account/Profile.aspx");
        }

        private void SaveProfileImageToServer()
        {
            foreach (string fileKey in this.Context.Request.Files.Keys)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[fileKey];
                if (file.ContentLength <= 0)
                {
                    continue;
                }

                string fileExtension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
                string userEmail = this.CurrentUser.Email;

                var job = new ImageJob(
                    file,
                    "~/Images/" + userEmail + "/avatar." + fileExtension,
                    new Instructions("width=250;height=250;format=" + fileExtension + ";mode=max;"));
                job.CreateParentDirectory = true;
                job.Build();
            }
        }
    }
}