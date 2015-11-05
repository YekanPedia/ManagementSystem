namespace YekanPedia.ManagementSystem.Service
{
    using System;
    public static class IntExtension
    {
        public static bool ToBool(this int value)
        {
            return value != -1;
        }
        public static string ToMessage(this int value, string message)
        {
            return value != -1 ? string.Empty : message;
        }
    }
}
