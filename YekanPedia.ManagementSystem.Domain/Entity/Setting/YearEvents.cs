namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Properties;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(YearEvents), Schema = "Event")]
    public class YearEvents : IValidatableObject
    {
        [Key]
        public int YearEventsId { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Month))]
        [Range(1, 12, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DisplayError))]
        public byte Month { get; set; }
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Day))]
        [Range(1, 31, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DisplayError))]
        public byte Day { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Topic))]
        public string Topic { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Text))]
        public string Text { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Month > 6 && Day > 30)
                yield return new ValidationResult(DisplayError.DayValueError, new[] { nameof(Day) });

            if (Month == 12 && Day > 29)
                yield return new ValidationResult(DisplayError.DayValueError, new[] { nameof(Day) });
        }
    }
}
