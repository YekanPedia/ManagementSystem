namespace System.Web.Optimization
{
    using System.Collections.Generic;
    /// <summary>
    ///نحوه مرتب سازی باندل کردن اسکریپت ها و استایل ها
    /// </summary>
    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }

}
