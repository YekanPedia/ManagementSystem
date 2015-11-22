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
        public int UserInRoleId { get; set; }

        [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
