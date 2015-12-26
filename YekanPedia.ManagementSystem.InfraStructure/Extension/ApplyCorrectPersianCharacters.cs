namespace YekanPedia.ManagementSystem.InfraStructure.Extension
{
    using System.Data;
    using System.Data.Common;
    /// <summary>
    /// کلاس استاتیک تبدیل حروف عربی به حروف فارسی
    /// </summary>
    public static class CorrectPersianCharacters
    {
        /// <summary>
        /// مقدار کاراکتری حرف ي در عربی
        /// </summary>
        public const char ArabicYeChar = (char)1610;
        /// <summary>
        /// مقدار کاراکتری حرف ی در فارسی
        /// </summary>
        public const char PersianYeChar = (char)1740;
        /// <summary>
        /// مقدار کاراکتری حرف ک در عربی
        /// </summary>
        public const char ArabicKeChar = (char)1603;
        /// <summary>
        /// مقدار کاراکتری حرف ک در فارسی
        /// </summary>
        public const char PersianKeChar = (char)1705;

        /// <summary>
        /// تبدیل حروف ي به ی و ک عربی به ک فارسی
        /// </summary>
        /// <param name="data">داده ورودی جهت بازنشانی</param>
        /// <returns>داده ارسالی با حروف تبدیل شده عربی به فارسی</returns>
        public static string ApplyCorrectPersianCharacters(this object data)
        {
            return data == null ? null : ApplyCorrectPersianCharacters(data.ToString());
        }

        /// <summary>
        /// تبدیل حروف ي به ی و ک عربی به ک فارسی
        /// </summary>
        /// <param name="data">داده ورودی جهت بازنشانی</param>
        /// <returns>داده ارسالی با حروف تبدیل شده عربی به فارسی</returns>
        public static string ApplyCorrectPersianCharacters(this string data)
        {
            return string.IsNullOrWhiteSpace(data) ?
                        string.Empty :
                        data.Replace(ArabicYeChar, PersianYeChar).Replace(ArabicKeChar, PersianKeChar).Trim();
        }

        /// <summary>
        /// تبدیل حروف ي به ی و ک عربی به ک فارسی
        /// </summary>
        /// <param name="command">داده ورودی جهت بازنشانی</param>
        /// <returns>داده ارسالی با حروف تبدیل شده عربی به فارسی</returns>
        public static void ApplyCorrectPersianCharacters(this DbCommand command)
        {
             command.CommandText = command.CommandText.ApplyCorrectPersianCharacters();
            foreach (DbParameter parameter in command.Parameters)
            {
                switch (parameter.DbType)
                {
                    case DbType.AnsiString:
                    case DbType.AnsiStringFixedLength:
                    case DbType.String:
                    case DbType.StringFixedLength:
                    case DbType.Xml:
                        parameter.Value = parameter.Value.ToString().ApplyCorrectPersianCharacters();
                        break;
                }
            }
        }
    }

}
