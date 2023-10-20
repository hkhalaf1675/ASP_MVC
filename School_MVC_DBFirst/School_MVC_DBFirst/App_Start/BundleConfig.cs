using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace School_MVC_DBFirst
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/BootstrapCss").Include(
                  "~/Content/bootstrap.css"
                ));

            bundles.Add(new Bundle("~/BootstrapJs").Include(
                    "~/Scripts/jquery-3.4.1.js",
                    "~/Scripts/bootstrap.js"
                ));

            //bundles.Add(new ScriptBundle("") Not Working --------------------->>>>
            bundles.Add(new Bundle("~/ValidationJs").Include(
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            //---------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
