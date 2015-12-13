namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(ActivityTypeMap), Schema = "Log")]
    public class ActivityTypeMap
    {
        [Key]
        public long ActivityTypeMapId { get; set; }
    }
}
