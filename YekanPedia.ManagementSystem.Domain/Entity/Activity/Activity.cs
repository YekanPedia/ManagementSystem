namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Activity), Schema = "Log")]
    public class Activity
    {
        [Key]
        public long ActivityId  { get; set; }

        public DateTime EventTime { get; set; }
    }
}
