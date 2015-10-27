namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Optimization;
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.CoreScripts).Include(
                           "~" + Links.Scripts.JQuery.jquery_min_js,
                           "~" + Links.Scripts.Bootstrap.bootstrap_min_js,
                           "~" + Links.Scripts.JQuery.NiceScroll.jquery_nicescroll_min_js,
                           "~" + Links.Scripts.JQuery.Wave.waves_min_js,
                           "~" + Links.Scripts.JQuery.Type.jQuery_Type_js));
            #endregion
            #region Styles
            bundles.Add(new StyleBundle(Links.Bundles.Styles.ContentCss).Include(
                           "~" + Links.Content.Styles.Ltr.AppStyle1_css,
                           "~" + Links.Content.Styles.Ltr.AppStyle2_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.ContentRtlCss).Include("~" + Links.Content.Styles.Rtl.AppStyle1_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.PublicCss).Include(
                          "~" + Links.Content.Styles.Public.Animate_css,
                          "~" + Links.Content.Styles.Public.lightGallery_css,
                          "~" + Links.Content.Styles.Public.MaterialDesignIconicFont_css));
            #endregion
        }
    }
}

