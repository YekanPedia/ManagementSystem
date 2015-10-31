namespace YekanPedia.ManagementSystem.InfraStructure.Validation
{
    using System.ComponentModel.DataAnnotations;
    public class IntAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            int result = 0;
            int.TryParse(value.ToString(), out result);
            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
