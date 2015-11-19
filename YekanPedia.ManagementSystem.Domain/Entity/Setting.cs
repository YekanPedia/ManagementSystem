namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Setting
    {
        [Key]
        public Guid SettingId { get; set; }

        public int FilesPersist { get; set; }
    }
}
