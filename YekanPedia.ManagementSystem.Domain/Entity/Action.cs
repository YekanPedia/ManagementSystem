namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(Action), Schema = "Acl")]
    public class Action
    {
        [Key]
        public int ActionId { get; set; }

        [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
        public Guid RoleId { get; set; }
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

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsFirstAction))]
        public bool IsFirstAction { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Icon))]
        [MaxLength(40, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string Icon { get; set; }

        public int ParentId { get; set; }
    }
}
