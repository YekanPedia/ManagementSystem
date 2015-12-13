namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(Work), Schema = "Overview")]
    public class Work
    {
        [Key]
        public int WorkId { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Company))]
        [MaxLength(60, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(60, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Company { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Position))]
        [MaxLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Position { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Description))]
        [MaxLength(250, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(250, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(WorkCurrently))]
        public bool WorkCurrently { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(WorkStartYear))]
        public string WorkStartYear { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(WorkFinishYear))]
        public int WorkFinishYear { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsPublic))]
        public bool IsPublic { get; set; }
    }
}
