namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Mvc;
    /// <summary>
    /// کلاس الحاقی برای ثبت و دریافت پیام ها
    /// </summary>
    public static class NotificationExtensions
    {
        /// <summary>
        /// متد الحاقی برای دریافت نمونه ای از کلاس پیام برای اضافه نمودن پیام
        /// </summary>
        /// <param name="controller">کنترلر پدر تمام کنترلر های برنامه</param>
        /// <returns>یک نمونه از کلاس PNotify</returns>
        public static NotificationController NotificationController(this ControllerBase controller)
        {
            return new NotificationController(controller.TempData);
        }


        /// <summary>
        /// متد الحاقی برای دریافت پیام های اضافه شده 
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <returns>یک نمونه از کلاس PNotify</returns>

        public static NotificationController NotificationController(this HtmlHelper htmlHelper)
        {
            return new NotificationController(htmlHelper.ViewContext.TempData);
        }
    }
}
