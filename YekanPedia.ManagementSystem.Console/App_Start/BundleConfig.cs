namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Optimization;
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            #region Scripts

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.AccountScripts, new JsMinify()).Include(
                        "~" + Links.Scripts.JQuery.Croper.cropper_min_js,
                        "~" + Links.Scripts.Application.AccountController_min_js,
                        "~" + Links.Scripts.JQuery.FileInput.fileinput_min_js
                        ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.AdminPanelScripts, new JsMinify()).Include(
                         "~" + Links.Scripts.Application.SchedulerController_js,
                         "~" + Links.Scripts.JQuery.SparkLine.jquery_sparkline_min_js,
                         "~" + Links.Scripts.JQuery.PieChart.jquery_easypiechart_min_js,
                         "~" + Links.Scripts.Application.ChartController_min_js
                         ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.LoginScripts, new JsMinify()).Include(
                           "~" + Links.Scripts.JQuery.jquery_1_10_2_min_js,
                           "~" + Links.Scripts.JQuery.Bootstrap.bootstrap_min_js,
                           "~" + Links.Scripts.JQuery.NiceScroll.jquery_nicescroll_min_js,
                           "~" + Links.Scripts.JQuery.Wave.waves_min_js,
                           "~" + Links.Scripts.JQuery.Type.jQuery_Type_js,
                           "~" + Links.Scripts.JQuery.PersianCalendar.PersianCalendar_js,
                           "~" + Links.Scripts.functions_js,
                           "~" + Links.Scripts.JQuery.Validation.jquery_validate_js,
                           "~" + Links.Scripts.JQuery.Validation.jquery_validate_unobtrusive_js,
                           "~" + Links.Scripts.JQuery.Ajax.jquery_unobtrusive_ajax_js,
                            "~" + Links.Scripts.JQuery.Phoenix.Phoenix_core_js
                           ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.CoreScripts, new JsMinify()).Include(
                          "~" + Links.Scripts.JQuery.jquery_1_10_2_min_js,
                          "~" + Links.Scripts.JQuery.Bootstrap.bootstrap_min_js,
                          "~" + Links.Scripts.JQuery.NiceScroll.jquery_nicescroll_min_js,
                          "~" + Links.Scripts.JQuery.Wave.waves_min_js,
                          "~" + Links.Scripts.JQuery.Type.jQuery_Type_js,
                           "~" + Links.Scripts.JQuery.Sweet.sweet_alert_min_js,
                           "~" + Links.Scripts.JQuery.PersianCalendar.PersianCalendar_js,
                           "~" + Links.Scripts.JQuery.InputMask.input_mask_min_js,
                           "~" + Links.Scripts.JQuery.Select.BootstrapSelect_js,
                           "~" + Links.Scripts.JQuery.BootGrid.jquery_bootgrid_min_js,
                           "~" + Links.Scripts.JQuery.LightGallery.lightGallery_min_js,
                          "~" + Links.Scripts.functions_js,
                          "~" + Links.Scripts.JQuery.Validation.jquery_validate_js,
                          "~" + Links.Scripts.JQuery.Validation.jquery_validate_unobtrusive_js,
                          "~" + Links.Scripts.JQuery.Ajax.jquery_unobtrusive_ajax_js,
                          "~" + Links.Scripts.JQuery.NProgressbar.nprogress_js,
                           "~" + Links.Scripts.JQuery.Phoenix.Phoenix_core_js,
                           "~" + Links.Scripts.JQuery.Feedback.html2canvas_js,
                           "~" + Links.Scripts.JQuery.Feedback.feedback_js,
                           "~" + Links.Scripts.Application.TaskController_js
                           ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.FullCalendarScripts, new JsMinify()).Include(
                       "~" + Links.Scripts.JQuery.FullCalendar.moment_min_js,
                       "~" + Links.Scripts.JQuery.FullCalendar.fullcalendar_min_js,
                       "~" + Links.Scripts.JQuery.FullCalendar.fa_js
                       ));

            bundles.Add(new ScriptBundleOrderer(Links.Bundles.Scripts.BasicInfoScripts, new JsMinify()).Include(
                        "~" + Links.Scripts.Application.BasicInfoController_js));
            #endregion
            #region Styles
            bundles.Add(new StyleBundleOrderer(Links.Bundles.Styles.ContentCss, new CssMinify()).Include(
                           "~" + Links.Content.Styles.Ltr.AppStyle1_css,
                           "~" + Links.Content.Styles.Ltr.AppStyle2_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.ContentRtlCss).Include("~" + Links.Content.Styles.Rtl.AppStyle1_css));
            bundles.Add(new StyleBundle(Links.Bundles.Styles.FullCalednar).Include("~" + Links.Content.Styles.Public.Fullcalendar_css));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.PublicCss).Include(
                          "~" + Links.Content.Styles.Public.Animate_css,
                          "~" + Links.Content.Styles.Public.LightGallery_css,
                           "~" + Links.Content.Styles.Public.Sweet_css,
                          "~" + Links.Content.Styles.Public.MaterialDesignIconicFont_css,
                          "~" + Links.Content.Styles.Public.PersianCalendar_css,
                           "~" + Links.Content.Styles.Public.Fullcalendar_css,
                          "~" + Links.Content.Styles.Public.Bootgrid_css,
                          "~" + Links.Content.Styles.Public.BootstrapSelect_css,
                          "~" + Links.Content.Styles.Public.Feedback_rtl_css,
                          "~" + Links.Content.Styles.Public.NProgress_css,
                           "~" + Links.Content.Styles.Public.cropper_css
                          ));
            #endregion
        }
    }
}

