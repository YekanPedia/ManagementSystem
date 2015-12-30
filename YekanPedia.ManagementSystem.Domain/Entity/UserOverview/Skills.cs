namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(Skills), Schema = "Overview")]
    public class Skills
    {
        [Key]
        public int SkillsId { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Topic))]
        public string Topic { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Percent))]
        [Range(0, 100, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DisplayError))]
        public int Percent { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsPublic))]
        public bool IsPublic { get; set; }
    }
}
