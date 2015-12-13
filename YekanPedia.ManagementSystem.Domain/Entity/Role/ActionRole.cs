namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(ActionRole), Schema = "Acl")]
    public class ActionRole
    {
        [Key]
        public int ActionRoleId { get; set; }

        [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Controller))]
        [MaxLength(40, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Controller { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ActionName))]
        [MaxLength(40, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string ActionName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ActionName))]
        [MaxLength(40, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string ActionNameFa { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsFirstAction))]
        public bool IsFirstAction { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsVisible))]
        public bool IsVisible { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Icon))]
        [MaxLength(40, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Icon { get; set; }

        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}
