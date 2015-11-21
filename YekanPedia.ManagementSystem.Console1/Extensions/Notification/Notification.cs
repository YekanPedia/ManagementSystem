namespace YekanPedia.ManagementSystem.Console
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public enum NotificationStatus
    {
        [Description("error")]
        Error,
        [Description("warning")]
        Warning,
        [Description("success")]
        Success,
        [Description("info")]
        Information
    }

    public class Notification
    {
        public string Message { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
    }
}
