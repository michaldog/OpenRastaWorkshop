using Microsoft.Web.Optimization;

namespace OrderManagement.Web.Bundles
{
    public class JsNullTransform : IBundleTransform
    {
        public void Process(BundleResponse bundle)
        {
           bundle.ContentType = "text/javascript";
        }
    }
}