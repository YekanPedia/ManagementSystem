namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(Education), Schema = "Overview")]
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(School))]
        [MaxLength(60, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(60, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string School { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Field))]
        [MaxLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Field { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Description))]
        [MaxLength(250, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(250, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Graduated))]
        public bool Graduated { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(EducateStartYear))]
        public int EducateStartYear { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(EducateFinishYear))]
        public int EducateFinishYear { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsPublic))]
        public bool IsPublic { get; set; }
    }
}
