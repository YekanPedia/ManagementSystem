namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Configuration", Schema = "Base")]
    public class Configuration
    {
        [Key]
        public int ConfigurationId { get; set; }
        public string Key { get; set; }
        public string KeyFa { get; set; }
        public bool IsActive { get; set; }
    }
}
