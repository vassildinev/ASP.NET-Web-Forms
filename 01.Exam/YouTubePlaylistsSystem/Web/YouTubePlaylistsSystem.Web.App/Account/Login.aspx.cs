namespace YouTubePlaylistsSystem.Web.App.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Common.Helpers;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            string returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ApplicationUserManager manager = this.Context
                    .GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();

                ApplicationSignInManager signinManager = this.Context
                    .GetOwinContext()
                    .GetUserManager<ApplicationSignInManager>();

                SignInStatus result = signinManager
                    .PasswordSignIn(this.Email.Text, this.Password.Text, this.RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper
                            .RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(string.Format(
                            "/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                            Request.QueryString["ReturnUrl"],
                            RememberMe.Checked),
                            true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        this.FailureText.Text = "Invalid login attempt";
                        this.ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}