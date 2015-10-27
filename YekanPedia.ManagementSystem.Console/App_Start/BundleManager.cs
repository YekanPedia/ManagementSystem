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
        }

        /// <summary>
        ///Styles در  StronglyType کلاسی برای استفاده 
        /// </summary>
        public static partial class Styles
        {
            /// <summary>
            /// باندل تمامیه استایل ها
            /// </summary>
            public static readonly string ContentCss = "~/Content/Styles/Ltr";
            public static readonly string ContentRtlCss = "~/Content/Styles/Rtl";
            public static readonly string PublicCss = "~/Content/Styles/Public";
        }
    }
}
