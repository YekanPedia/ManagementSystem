namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;
    using InfraStructure.Date;

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
        [PersianDate(ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
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

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RegisterDate))]
        public DateTime RegisterDate { get; set; }

        [NotMapped]
        public string RegisterPersianDate => PersianDateTime.GetRelativeTime(RegisterDate);

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(LastLoginDate))]
        public DateTime LastLoginDate { get; set; }

        [NotMapped]
        public string LastLoginPersianDate => PersianDateTime.GetRelativeTime(LastLoginDate);


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

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsTeacher))]
        public bool IsTeacher { get; set; }
        public bool IsResetPassword { get; set; }
        public int ProgressRegisterCompleted()
        {
            int progress = 0;
            if (!string.IsNullOrEmpty(AboutMe))
                progress += 30;
            if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Sex) & !string.IsNullOrEmpty(BirthDate))
                progress += 35;
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Mobile) && !string.IsNullOrEmpty(Twitter) & !string.IsNullOrEmpty(Facebook))
                progress += 35;
            return progress;
        }

        public virtual ICollection<UserInClass> UserInClass { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Class))]
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
