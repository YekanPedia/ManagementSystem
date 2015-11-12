namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(Feedback), Schema = "Info")]
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string AppCodeName { get; set; }

        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string AppName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string AppVersion { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string CookieEnabled { get; set; }

        public bool OnLine { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string UserAgent { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string CurrentUrl { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string ScreenSnapshot { get; set; }

        [MaxLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Note { get; set; }

        public DateTime SendFeedbackDate { get; set; }
    }
}
