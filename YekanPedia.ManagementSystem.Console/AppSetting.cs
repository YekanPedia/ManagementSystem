 namespace YekanPedia.ManagementSystem.Console
{
    using System.Configuration;
    public static class AppSettings {
        public static string GoogleClientId => ConfigurationManager.AppSettings["GoogleClientId"];
        public static string GoogleClientSecret => ConfigurationManager.AppSettings["GoogleClientSecret"];
        public static bool ClientValidationEnabled => bool.Parse(ConfigurationManager.AppSettings["ClientValidationEnabled"]);
        public static bool UnobtrusiveJavaScriptEnabled => bool.Parse(ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]);
    }
}