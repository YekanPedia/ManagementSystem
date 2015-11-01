namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Optimization;
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            #region Scripts

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.LoginScripts, new JsMinify()).Include(
                           "~" + Links.Scripts.JQuery.jquery_1_10_2_min_js,
                           "~" + Links.Scripts.Bootstrap.bootstrap_min_js,
                           "~" + Links.Scripts.JQuery.NiceScroll.jquery_nicescroll_min_js,
                           "~" + Links.Scripts.JQuery.Wave.waves_min_js,
                           "~" + Links.Scripts.JQuery.Type.jQuery_Type_js,
                           "~" + Links.Scripts.functions_js,
                           "~" + Links.Scripts.JQuery.Validation.jquery_validate_js,
                           "~" + Links.Scripts.JQuery.Validation.jquery_validate_unobtrusive_js,
                           "~" + Links.Scripts.JQuery.Ajax.jquery_unobtrusive_ajax_js,
                            "~" + Links.Scripts.JQuery.Phoenix.Phoenix_core_js
                           ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.CoreScripts, new JsMinify()).Include(
                          "~" + Links.Scripts.JQuery.jquery_1_10_2_min_js,
                          "~" + Links.Scripts.Bootstrap.bootstrap_min_js,
                          "~" + Links.Scripts.JQuery.NiceScroll.jquery_nicescroll_min_js,
                          "~" + Links.Scripts.JQuery.Wave.waves_min_js,
                          "~" + Links.Scripts.JQuery.Type.jQuery_Type_js,
                           "~" + Links.Scripts.JQuery.Sweet.sweet_alert_min_js,
                          "~" + Links.Scripts.functions_js,
                          "~" + Links.Scripts.JQuery.Validation.jquery_validate_js,
                          "~" + Links.Scripts.JQuery.Validation.jquery_validate_unobtrusive_js,
                          "~" + Links.Scripts.JQuery.Ajax.jquery_unobtrusive_ajax_js,
                           "~" + Links.Scripts.JQuery.Phoenix.Phoenix_core_js
                          ));

            #endregion
            #region Styles
            bundles.Add(new StyleBundleOrderer(Links.Bundles.Styles.ContentCss, new CssMinify()).Include(
                           "~" + Links.Content.Styles.Ltr.AppStyle1_css,
                           "~" + Links.Content.Styles.Ltr.AppStyle2_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.ContentRtlCss).Include("~" + Links.Content.Styles.Rtl.AppStyle1_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.PublicCss).Include(
                          "~" + Links.Content.Styles.Public.Animate_css,
                          "~" + Links.Content.Styles.Public.LightGallery_css,
                           "~" + Links.Content.Styles.Public.Sweet_css,
                          "~" + Links.Content.Styles.Public.MaterialDesignIconicFont_css));
            #endregion
        }
    }
}

