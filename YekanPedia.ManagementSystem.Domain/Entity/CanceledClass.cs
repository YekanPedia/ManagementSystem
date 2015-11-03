namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;

    [Table("CanceledClass", Schema = "dbo")]
    public class CanceledClass
    {
        [Key]
        public int CanceledClassId { get; set; }

        public Guid ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CanceledDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate(ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string CanceledDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CanceledDateSh))]
        [ScaffoldColumn(false)]
        public DateTime CanceledDateMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Description))]
        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Description { get; set; }
    }
}
