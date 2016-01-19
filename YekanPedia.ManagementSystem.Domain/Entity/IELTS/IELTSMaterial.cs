namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Date;

    [Table("Material", Schema = "IELTS")]
    public class IeltsMaterial
    {
        [Key]
        public Guid IeltsMaterialId { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TopicId))]
        public int TopicId { get; set; }
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(File))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string File { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(File))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Path { get; set; }
        public DateTime SendDateMi { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(SendDateSh))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string SendDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsComplete))]
        public bool IsComplete { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Score))]
        public float Score { get; set; }

        public DateTime SendFeedbackDateMi { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(SendFeedbackDateSh))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string SendFeedbackDateSh { get; set; }

        public void Rebind()
        {
            Score = 0;
            SendFeedbackDateMi = SendDateMi = DateTime.Now;
            SendFeedbackDateSh = SendDateSh = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
        }
    }
}
