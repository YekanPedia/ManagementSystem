namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(SessionMaterial), Schema = "dbo")]
    public class SessionMaterial
    {
        [Key]
        public Guid SessionMaterilId { get; set; }

        public Guid ClassSessionId { get; set; }
        [ForeignKey(nameof(ClassSessionId))]
        public ClassSession ClassSession { get; set; }

        public string DirectLink { get; set; }
        public string Extension { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
