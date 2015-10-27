namespace System.Web.Optimization
{
    public class StyleBundleOrderer : Bundle
    {
        public StyleBundleOrderer(string virtualPath)
            : base(virtualPath)
        {
            base.Orderer = new AsIsBundleOrderer();
        }
        public StyleBundleOrderer(string virtualPath, string cdnPath)
            : base(virtualPath)
        {
            base.Orderer = new AsIsBundleOrderer();
        }
    }
}
