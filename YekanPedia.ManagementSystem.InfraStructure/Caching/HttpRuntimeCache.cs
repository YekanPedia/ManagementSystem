namespace YekanPedia.ManagementSystem.InfraStructure.Caching
{
    using System;
    using System.Web;
    using System.Web.Caching;

    public class HttpRuntimeCache : ICacheProvider
    {
        public object GetItem(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public void InvalidateItem(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public void InvalidateSets(string[] entitySets)
        {
            foreach (var rootCacheKey in entitySets)
            {
                if (string.IsNullOrWhiteSpace(rootCacheKey)) continue;
                InvalidateItem(rootCacheKey);
            }
        }

        public void PutItem(string cacheKey, object value, string[] dependentEntitySets, DateTime absoluteExpiration)
        {
            HttpRuntime.Cache.Insert(
                 cacheKey,
                 value,
                 new CacheDependency(null, dependentEntitySets),
                 absoluteExpiration,
                 Cache.NoSlidingExpiration,
                 CacheItemPriority.Normal,
                 null);
        }
    }
}
