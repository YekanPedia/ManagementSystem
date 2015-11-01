﻿namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using System.ComponentModel;

    [Table("Tasks", Schema = "dbo")]
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int Progress { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Subject))]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Subject { get; set; }

        public TaskType Type { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Link))]
        [Column(TypeName = "varchar")]
        [MaxLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Link { get; set; }

        public ProgressbarType ProgressbarType { get; set; }
    }

    public enum ProgressbarType
    {
        [Description("progress-bar progress-bar-warning")]
        Warning,

        [Description("progress-bar progress-bar-success")]
        Success,

        [Description("progress-bar progress-bar-info")]
        Info,

        [Description("progress-bar progress-bar-danger")]
        Danger,

        [Description("progress-bar")]
        Primary
    }
    public enum TaskType
    {
        Profile
    }
}
