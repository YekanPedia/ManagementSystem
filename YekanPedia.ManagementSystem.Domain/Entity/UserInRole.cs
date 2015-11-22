namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(UserInRole), Schema = "Acl")]
    public class UserInRole
    {
        [Key]
        public Guid UserInRoleId { get; set; }

        [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
        public Guid RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(StartRoleSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]

        public string StartRoleSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(StartRoleSh))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public DateTime StartRoleMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(FinishRoleSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string FinishRoleSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(FinishRoleSh))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public DateTime FinishRoleMi { get; set; }
    }
}
