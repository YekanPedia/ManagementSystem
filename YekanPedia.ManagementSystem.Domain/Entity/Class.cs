﻿namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Properties;
    using InfraStructure.Validation;
    using System.Collections.Generic;
    using InfraStructure.Date;
    using System.Linq;


    [Table("Class", Schema = "dbo")]
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }

        [Display(Name = nameof(ClassTypeId), ResourceType = typeof(DisplayNames))]
        public int ClassTypeId { get; set; }
        [ForeignKey(nameof(ClassTypeId))]
        public ClassType ClassType { get; set; }

        [Display(Name = nameof(CourseId), ResourceType = typeof(DisplayNames))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Display(Name = "IsTeacher", ResourceType = typeof(DisplayNames))]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ScaffoldColumn(false)]
        public DateTime StartDateMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(StartDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string StartDateSh { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FinishDateMi { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(FinishDateSh))]
        [Column(TypeName = "char")]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        public string FinishDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(JustificationDateSh))]
        [Column(TypeName = "char")]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayError.MaxLength), ErrorMessageResourceType = typeof(DisplayError))]
        [RegularExpression(@"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$", ErrorMessageResourceName = nameof(DisplayError.PersianDate), ErrorMessageResourceType = typeof(DisplayError))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        public string JustificationDateSh { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(SessionCount))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Int(ErrorMessageResourceName = nameof(DisplayError.Int), ErrorMessageResourceType = typeof(DisplayError))]
        public int SessionCount { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Price))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Int(ErrorMessageResourceName = nameof(DisplayError.Int), ErrorMessageResourceType = typeof(DisplayError))]
        public int Price { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(Capacity))]
        [Required(ErrorMessageResourceName = nameof(DisplayError.Required), ErrorMessageResourceType = typeof(DisplayError))]
        [Int(ErrorMessageResourceName = nameof(DisplayError.Int), ErrorMessageResourceType = typeof(DisplayError))]
        public int Capacity { get; set; }

        public bool IsFinished { get; set; }

        [NotMapped]
        public string ClassInformaion
        {
            get
            {
                var time = ClassTime?.FirstOrDefault();
                return $"{User?.FullName} : {Course?.CourseName} , {time.DayFa} , ({time?.TimeFrom} تا {time?.TimeTo})";
            }
        }

        public void ReBind()
        {
            FinishDateMi = PersianDateTime.Parse(FinishDateSh).ToDateTime();
            StartDateMi = PersianDateTime.Parse(StartDateSh).ToDateTime();
        }

        public virtual ICollection<ClassTime> ClassTime { get; set; }
        public virtual ICollection<CanceledClass> CanceledClass { get; set; }
        public virtual ICollection<UserInClass> UserInClass { get; set; }
    }
}
