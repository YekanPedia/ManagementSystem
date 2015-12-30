namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(SessionMaterial), Schema = "dbo")]
    public class SessionMaterial
    {
        [Key]
        public Guid SessionMaterilId { get; set; }

        public Guid ClassSessionId { get; set; }
        [ForeignKey(nameof(ClassSessionId))]
        public ClassSession ClassSession { get; set; }

        [MaxLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string DirectLink { get; set; }

        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Extension { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
