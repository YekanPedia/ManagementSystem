namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using Properties;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Setting), Schema = "Base")]
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Range(1, 100, ErrorMessage = nameof(FilesPersistance), ErrorMessageResourceType = typeof(DisplayError))]
        public int FilesPersistance { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(BirthDateText))]
        [MaxLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [StringLength(300, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string BirthDateText { get; set; }
    }
}
