
namespace YekanPedia.ManagementSystem.InfraStructure.Extension
{
    public static class FullTimeFormat
    {
        public static string ToFullTimeFormat(this int value)
        {
            if (value < 10)
            {
                return $"0{value}";
            }
            return value.ToString();
        }
    }
}
