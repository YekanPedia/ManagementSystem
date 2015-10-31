namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;

    public class BaseUser
    {

        [Key]
        public Guid UserId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(FullName))]
        [MaxLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(45, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string FullName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Email))]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(DisplayError))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Picture { get; set; }

    }

    [Table("User", Schema = "dbo")]
    public class User : BaseUser
    {

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(BirthDate))]
        [Column(TypeName = "char")]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate(ErrorMessageResourceName =nameof(DisplayError.PersianDate),ErrorMessageResourceType =typeof(DisplayError))]
        public string BirthDate { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Sex))]
        [MaxLength(3, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Password))]
        [MaxLength(15, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(15, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public bool IsActive { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [NotMapped]
        public string LastLoginPersianDate => "";

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Mobile))]
        [MaxLength(11, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(11, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^09[1-4]\d{8}$", ErrorMessageResourceName = nameof(DisplayError.MobileError), ErrorMessageResourceType = typeof(DisplayError))]
        [MinLength(11, ErrorMessageResourceName = nameof(DisplayError.MinLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "char")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Latitude { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Longitude { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Twitter))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Twitter { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Facebook))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Facebook { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Telegram))]
        [ScaffoldColumn(false)]
        [MaxLength(15, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(15, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Telegram { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(AboutMe))]
        [MaxLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string AboutMe { get; set; }

        public bool IsRegisterCompleted()
        {
            return false;
        }

        public virtual ICollection<UserInClass> UserInClass { get; set; }
        public virtual ICollection<Class> Class { get; set; }
    }


}
