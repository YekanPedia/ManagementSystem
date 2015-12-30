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

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Topic))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Topic { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Book))]
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }


        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ExamType))]
        public int ExamTypeId { get; set; }
        [ForeignKey(nameof(ExamTypeId))]
        public ExamType ExamType { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TestNumber))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string TestNumber { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Page))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public int Page { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(File))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string File { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(File))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Path { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsComplete))]
        public bool IsComplete { get; set; }

        public DateTime SendDateMi { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(SendDateSh))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string SendDateSh { get; set; }

        public void Rebind()
        {
            SendDateMi = DateTime.Now;
            SendDateSh = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
        }
    }
}
