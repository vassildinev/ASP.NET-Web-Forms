namespace YouTubePlaylistsSystem.Web.App.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using Common.Helpers;
    using Data.Models;
    using ImageResizer;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.Request.IsAuthenticated)
                {
                    this.Response.Redirect("~/Home.aspx");
                }
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            this.SaveProfileImageToServer();
            ApplicationUserManager manager = this.Context
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            ApplicationSignInManager signInManager = this.Context
                .GetOwinContext()
                .Get<ApplicationSignInManager>();

            string userEmail = this.Server.HtmlEncode(this.Email.Text);
            string imageUrl = "~/Images/";
            if (!string.IsNullOrEmpty(this.Request.Files[0].FileName))
            {
                HttpPostedFile file = this.Request.Files[0];
                int indexOfFileExtensionBeginning = file.FileName.LastIndexOf('.');
                string extensionIncludingDot = file.FileName.Substring(indexOfFileExtensionBeginning);

                imageUrl = string.Concat(imageUrl, userEmail, "/avatar", extensionIncludingDot);
            }
            else
            {
                imageUrl = string.Concat(imageUrl, "default.jpg");
            }

            var user = new User()
            {
                FirstName = this.Server.HtmlEncode(this.FirstName.Text),
                LastName = this.Server.HtmlEncode(this.LastName.Text),
                UserName = userEmail,
                Email = userEmail,
                ProfileImageUrl = imageUrl,
                FacebookAccountUrl = this.Server.HtmlEncode(this.FacebookAccountUrl.Text),
                YouTubeAccountUrl = this.Server.HtmlEncode(this.YouTubeAccountUrl.Text)
            };


            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                this.ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
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
                string userEmail = this.Server.HtmlEncode(this.Email.Text);

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