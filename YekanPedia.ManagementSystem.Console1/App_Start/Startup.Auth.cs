namespace YekanPedia.ManagementSystem.Console
{
    using Microsoft.Owin.Security.Google;
    using Owin;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            // {
            //     ClientId = AppSettings.GoogleClientId,
            //     ClientSecret = AppSettings.GoogleClientSecret
            // });
        }
    }
}