

namespace YekanPedia.ManagementSystem.Console.Extensions
{
    using System;
    using System.Web.Mvc;
    using System.Linq;
    using InfraStructure.Extension;
    public static class EnumSelectList
    {
        public static SelectList Of<T>()
        {
            Type type = typeof(T);
            if (type.IsEnum)
            {
                var values = from Enum e in Enum.GetValues(type)
                             select new { ID = e, Name = e.GetDescription().ToString() };
                return new SelectList(values, "Id", "Name");
            }
            return null;
        }
    }
}