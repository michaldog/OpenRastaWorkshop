using System;
using System.Web;
using Microsoft.Web.Optimization;
using OrderManagement.Web.Bundles;

namespace OrderManagement.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var js = new Bundle("~/Scripts/app.js", typeof(JsNullTransform));
            js.AddDirectory("~/JavaScript", "*.js", true);
            BundleTable.Bundles.Add(js);
        }
    }
}
