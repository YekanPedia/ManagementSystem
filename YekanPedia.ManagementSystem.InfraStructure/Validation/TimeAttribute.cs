namespace YekanPedia.ManagementSystem.InfraStructure.Validation
{
    using System.ComponentModel.DataAnnotations;

    public  class TimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
