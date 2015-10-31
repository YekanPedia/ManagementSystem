namespace YekanPedia.ManagementSystem.InfraStructure.Validation
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class PersianDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            return Regex.IsMatch(value.ToString(), @"^1[34][0-9][0-9]\/((1[0-2])|(0[1-9]))\/(([12][0-9])|(3[01])|(0[1-9]))$"); ;
        }
    }
}
