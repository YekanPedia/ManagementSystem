namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using System.Collections.Generic;

    [Table("Course", Schema = "Base")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CourseName))]
        [MaxLength(30, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string CourseName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CodeName))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string CodeName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        public bool IsActive { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
