namespace YekanPedia.ManagementSystem.Domain.Entity 
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Date;
    using System.Collections.Generic;

    [Table("Topic", Schema = "IELTS")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Subject))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(450, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Subject { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TopicCode))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string TopicCode { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Book))]
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ExamType))]
        public int ExamTypeId { get; set; }
        [ForeignKey(nameof(ExamTypeId))]
        public ExamType ExamType { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TestNumber))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(5, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string TestNumber { get; set; }

        [Column(TypeName = "varchar")]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TaskNumber))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(5, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string TaskNumber { get; set; }

        public ICollection<IeltsMaterial> IeltsMaterial { get; set; }
    }
}
