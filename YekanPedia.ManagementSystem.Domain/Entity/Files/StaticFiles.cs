namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;

    [Table(nameof(StaticFiles), Schema = "Files")]
    public class StaticFiles
    {
        [Key]
        public int StaticFilesId { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Name))]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string DirectLink { get; set; }

        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [Column(TypeName = "varchar")]
        public string Extension { get; set; }

        public int? ParentId { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(LastUpdateDateSh))]
        [MaxLength(100, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        public string LastUpdateDateSh { get; set; }

    }
}
