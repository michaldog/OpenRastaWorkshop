using System;
using System.Web;
using Microsoft.Web.Optimization;
using OrderManagement.Web.Bundling;

namespace OrderManagement.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var js = new Bundle("~/Scripts/app.js", typeof(JsNullTransform));
            js.AddDirectory("~/JavaScript/Models", "*.js", true);
            js.AddDirectory("~/JavaScript/Views", "*.js", true);
            js.AddFile("~/JavaScript/App.js");
            BundleTable.Bundles.Add(js);
        }
    }
}
