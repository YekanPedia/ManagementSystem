namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Configuration", Schema = "Base")]
    public class Configuration
    {
        [Key]
        public int ConfigurationId { get; set; }
        public bool Sms { get; set; }
        public bool Telegram { get; set; }
        public bool Email { get; set; }
    }
}
