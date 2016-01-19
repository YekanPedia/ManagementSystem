namespace YekanPedia.ManagementSystem.Domain.Entity
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using System.Collections.Generic;

    [Table(nameof(Book), Schema = "IELTS")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Type))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(400, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Type { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(IsActive))]
        public bool IsActive { get; set; }

        [MaxLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(150, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Picture { get; set; }

        public virtual ICollection<Topic> Topic { get; set; }
    }
}
