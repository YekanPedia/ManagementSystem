namespace System.Web.Optimization
{
    public class ScriptBundleOrderer : Bundle
    {
        public ScriptBundleOrderer(string virtualPath)
            : base(virtualPath)
        {
            base.Orderer = new AsIsBundleOrderer();
        }
        public ScriptBundleOrderer(string virtualPath, string cdnPath)
            : base(virtualPath)
        {
            base.Orderer = new AsIsBundleOrderer();
        }

        public ScriptBundleOrderer(string virtualPath,params IBundleTransform[] transforms)
           : base(virtualPath, transforms)
        {
            base.Orderer = new AsIsBundleOrderer();
        }
    }

}