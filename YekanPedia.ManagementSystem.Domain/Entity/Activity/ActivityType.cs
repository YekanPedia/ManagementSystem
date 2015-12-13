namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(ActivityType), Schema = "Log")]
    public class ActivityType
    {
        [Key]
        public long ActivityTypeId { get; set; }
    }
}
