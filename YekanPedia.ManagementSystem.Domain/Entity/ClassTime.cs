namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YekanPedia.ManagementSystem.Domain.Properties;
    using YekanPedia.ManagementSystem.InfraStructure.Validation;
    [Table("ClassTime", Schema = "dbo")]
    public class ClassTime
    {
        [Key]
        public int ClassTimeId { get; set; }

        public Guid ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Day))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string DayFa { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Day))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [ScaffoldColumn(false)]
        public string DayEn { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [ScaffoldColumn(false)]
        public int Day { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TimeFrom))]
        [MaxLength(6, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Time]
        public string TimeFrom { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TimeTo))]
        [MaxLength(6, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Time]
        public string TimeTo { get; set; }
    }

    public enum Day
    {
        [Description("شنبه")]
        Sat = 1,
        [Description("یک شنبه")]
        Sun = 2,
        [Description("دو شنبه")]
        Mon = 3,
        [Description("سه شنبه")]
        Tue = 4,
        [Description("چهار شنبه")]
        Wed = 5,
        [Description("پنجشنبه")]
        Thu = 6,
        [Description("جمعه")]
        Fri = 7
    }
}
