﻿namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Extension;

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
        [LocalizeDescriptionEnum("MessageOnResetPassword", typeof(DisplayNames))]
        ResetPassword = 1,

        [LocalizeDescriptionEnum("MessageOnPrivateMessage", typeof(DisplayNames))]
        PrivateMessage = 2,

        [LocalizeDescriptionEnum("MessageOnCanceledClass", typeof(DisplayNames))]
        CanceledClass = 3,

        [LocalizeDescriptionEnum("MessageOnAddSession", typeof(DisplayNames))]
        AddSession = 4,

        [LocalizeDescriptionEnum("MessageOnBirthDate", typeof(DisplayNames))]
        BirthDate = 5
    }
}
