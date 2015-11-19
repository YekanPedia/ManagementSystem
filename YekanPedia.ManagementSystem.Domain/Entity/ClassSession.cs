namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;
    using InfraStructure.Date;
    using System.Collections.Generic;

    [Table(nameof(ClassSession), Schema = "dbo")]
    public class ClassSession
    {
        [Key]
        public Guid ClassSessionId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Class))]
        public Guid ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Subject))]
        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Subject { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Description))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ClassSessionDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate(ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string ClassSessionDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(ClassSessionDateSh))]
        [ScaffoldColumn(false)]
        public DateTime ClassSessionDateMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsCanceled))]
        public bool IsCanceled { get; set; }

        public void ReBind() => ClassSessionDateMi = PersianDateTime.Parse(ClassSessionDateSh).ToDateTime();

        public virtual ICollection<SessionRequest> SessionRequest { get; set; }
        public virtual ICollection<SessionMaterial> SessionMaterial { get; set; }
    }
}
