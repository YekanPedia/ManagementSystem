namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table("Notification", Schema = "Base")]
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(NotificationType))]
        public NotificationType NotificationType { get; set; }

        public bool Sms { get; set; }
        public bool Telegram { get; set; }
        public bool Email { get; set; }
        public bool Website { get; set; }
    }
    public enum NotificationType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ResetPassword))]
        ResetPassword = 1,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(PrivateMessage))]
        PrivateMessage = 2,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CanceledClass))]
        CanceledClass = 3,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(AddSession))]
        AddSession = 4,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(BirthDate))]
        BirthDate = 5
    }
}
