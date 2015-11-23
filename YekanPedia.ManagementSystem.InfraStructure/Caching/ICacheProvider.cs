namespace YekanPedia.ManagementSystem.InfraStructure.Caching
{
    using System;
    
    /// <summary>
    /// اینترفیس پرووایدر سیستم کش
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// دریافت نمودن آیتم به کش
        /// </summary>
        /// <param name="key">کلید کش</param>
        /// <returns>مقدار کش شده</returns>
        object GetItem(string key);
        
        /// <summary>
        /// اضافه نمودن به کش
        /// </summary>
        /// <param name="cacheKey">کلید</param>
        /// <param name="value">مقدار</param>
        /// <param name="dependentEntitySets">ریشه کلید کش</param>
        /// <param name="absoluteExpiration">زمان دقیق انقضاء کش</param>
        void PutItem(string cacheKey, object value, string[] dependentEntitySets, DateTime absoluteExpiration);

        /// <summary>
        /// باطل کردن کش
        /// </summary>
        /// <param name="entitySets">مجموعه موجودیت ها</param>
        void InvalidateSets(string[] entitySets);

        /// <summary>
        /// باطل کردن کش
        /// </summary>
        /// <param name="key">کلید</param>
        void InvalidateItem(string key);
    }
}
