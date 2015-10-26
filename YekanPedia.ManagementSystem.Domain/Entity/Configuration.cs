﻿namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class Configuration
    {
        [Key]
        public int ConfigurationId { get; set; }

        [MaxLength(150)]
        public string AvatarUrl { get; set; }

        public bool SendEmail { get; set; }

        public bool SendSMS { get; set; }

    }
}
