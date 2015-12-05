namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(AboutUs), Schema = "Info")]
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(CompanyName))]
        [MaxLength(30, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string CompanyName { get; set; }


        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Telphone))]
        [MaxLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Telphone { get; set; }

        [MaxLength(50, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Email))]
        [StringLength(50, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceName = nameof(Email), ErrorMessageResourceType = typeof(DisplayError))]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Address))]
        public string Address { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Description))]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Latitude))]
        [Column(TypeName = "varchar")]
        [MaxLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Latitude { get; set; }


        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Longitude))]
        [Column(TypeName = "varchar")]
        [MaxLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(20, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Longitude { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Twitter))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Twitter { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Facebook))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Facebook { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(GooglePlus))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string GooglePlus { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(LinkedIn))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string LinkedIn { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Telegram))]
        [MaxLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(90, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Telegram { get; set; }
    }
}
