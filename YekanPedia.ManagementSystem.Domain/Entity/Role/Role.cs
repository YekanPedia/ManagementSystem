namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using System.Collections.Generic;

    [Table(nameof(Role), Schema = "Acl")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RoleNameFa))]
        [MaxLength(30, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string RoleNameFa { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RoleNameFa))]
        [MaxLength(30, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string RoleNameEn { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RolePriority))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public RolePriority RolePriority { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        public bool IsActive { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsDefault))]
        public bool IsDefault { get; set; }

        public virtual ICollection<ActionRole> ActionRole { get; set; }
        public virtual ICollection<UserInRole> UserInRole { get; set; }
    }
    public enum RolePriority
    {
        ProjectManager = 1,
        Sir = 2,
        WebSiteManager = 3,
        Student = 4,
        User = 5
    }
}
