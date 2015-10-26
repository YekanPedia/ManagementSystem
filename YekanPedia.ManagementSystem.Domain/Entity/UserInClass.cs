namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;

    [Table("UserInClass", Schema = "dbo")]
    public class UserInClass
    {
        [Key]
        public int UserInClassId { get; set; }

        public int? ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ContributeStartDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate]
        public string ContributeStartDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ContributeStartDateSh))]
        [ScaffoldColumn(false)]
        public DateTime ContributeStartDateMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(SessionCount))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public int SessionCount { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Price))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public int Price { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(TransactionCode))]
        public long TransactionCode { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(PaymentDate))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate]
        public string PaymentDate { get; set; }
        public bool IsFinished { get; set; }
    }
}
