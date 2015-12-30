namespace YekanPedia.ManagementSystem.Domain.Entity
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using System.Collections.Generic;

    [Table(nameof(ExamType), Schema = "IELTS")]
    public class ExamType
    {
        [Key]
        public int ExamTypeId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Type))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Type { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        public bool IsActive { get; set; }

        public virtual ICollection<IeltsMaterial> IeltsMaterial { get; set; }
    }
}
