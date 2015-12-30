namespace Links
{
    /// <summary>
    ///Boundle در  StronglyType کلاسی برای استفاده 
    /// </summary>
    public static partial class Bundles
    {
        /// <summary>
        ///Scripts در  StronglyType کلاسی برای استفاده 
        /// </summary>
        public static partial class Scripts
        {
            /// <summary>
            /// باندل تمامیه اسکریپت ها
            /// </summary>
            public static readonly string CoreScripts = "~/Scripts/js";
            public static readonly string LoginScripts = "~/LoginScripts/js";
            public static readonly string BasicInfoScripts = "~/BasicInfoScripts/js";
            public static readonly string FullCalendarScripts = "~/FullCalendarScripts/js";
            public static readonly string AdminPanelScripts = "~/Admin/js";
            public static readonly string AccountScripts = "~/Account/js";
            public static readonly string OverviewScripts = "~/Overview/js";
            public static readonly string CVScripts = "~/CV/js";
        }

        /// <summary>
        ///Styles در  StronglyType کلاسی برای استفاده 
        /// </summary>
        public static class Styles
        {
            /// <summary>
            /// باندل تمامیه استایل ها
            /// </summary>
            public static readonly string ContentCss = "~/Content/Ltr";
            public static readonly string ContentRtlCss = "~/Content/Rtl";
            public static readonly string PublicCss = "~/Content/Public";
            public static readonly string FullCalednar = "~/Content/FullCalednar";
            public static readonly string CV = "~/Content/CV";
        }
    }
}
