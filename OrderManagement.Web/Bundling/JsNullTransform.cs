using System.Web;
using Microsoft.Web.Optimization;

namespace OrderManagement.Web.Bundling
{
    public class JsNullTransform : IBundleTransform
    {
        public void Process(BundleResponse bundle)
        {
            bundle.Cacheability = HttpCacheability.NoCache;
            bundle.ContentType = "text/javascript";
        }
    }
}