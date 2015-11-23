namespace YekanPedia.ManagementSystem.Domain.Entity
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

        public bool IsFinishable { get; set; }

        public DateTime FinishDateMi { get; set; }
    }

    public enum ProgressbarType
    {
        [Description("progress-bar progress-bar-warning")]
        Warning = 5,

        [Description("progress-bar progress-bar-success")]
        Success = 4,

        [Description("progress-bar progress-bar-info")]
        Info = 3,

        [Description("progress-bar progress-bar-danger")]
        Danger = 2,

        [Description("progress-bar")]
        Primary = 1
    }
    public enum TaskType
    {
        Profile,
        Practice
    }
}
