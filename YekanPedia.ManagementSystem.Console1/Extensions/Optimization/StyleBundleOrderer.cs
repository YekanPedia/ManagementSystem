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
        public StyleBundleOrderer(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
            base.Orderer = new AsIsBundleOrderer();
        }
    }
}
