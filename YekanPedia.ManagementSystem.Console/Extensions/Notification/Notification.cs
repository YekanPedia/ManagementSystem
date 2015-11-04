namespace YekanPedia.ManagementSystem.Console
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public enum NotificationStatus
    {
        [Description("zmdi zmdi-alert-circle")]
        Error,
        [Description("zmdi zmdi-alert-circle")]
        Warning,
        [Description("zmdi zmdi-alert-circle")]
        Success,
        [Description("zmdi zmdi-alert-circle")]
        Information
    }

    public class Notification
    {
        public string Message { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
    }
}
