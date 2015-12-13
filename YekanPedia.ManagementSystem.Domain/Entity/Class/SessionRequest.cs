namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using InfraStructure.Validation;
    using Properties;
    using InfraStructure.Date;

    [Table(nameof(SessionRequest), Schema = "dbo")]
    public class SessionRequest
    {
        [Key]
        public Guid SessionRequestId { get; set; }

        public Guid ClassSessionId { get; set; }
        [ForeignKey(nameof(ClassSessionId))]
        public ClassSession ClassSession { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RquestDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [PersianDate(ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string RquestDateSh { get; set; } = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(RquestDateSh))]
        [ScaffoldColumn(false)]
        public DateTime RquestDateMi { get; set; }
        public void Rebind() => RquestDateMi = PersianDateTime.Parse(RquestDateSh).ToDateTime();
    }
}
