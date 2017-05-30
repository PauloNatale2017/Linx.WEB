using System.Web;
using System.Web.Optimization;

namespace Linx.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            #region   JS  INDEX

            bundles.Add(new ScriptBundle("~/Scripts/index").Include(
                                         "~/Scripts/jquery-1.10.2.js",
                                         "~/Scripts/angular.js",
                                         "~/Scripts/ui-grid.js",
                                         "~/Scripts/angular-cookies.js",
                                         "~/Scripts/angular-block-ui.js",
                                         "~/Scripts/line_reader.js"
                                         ));


            #endregion

            #region CSS  INDEX

            bundles.Add(new StyleBundle("~/Content/index").Include(
                                        "~/Content/bootstrap.css",
                                        "~/Content/bootstrap.min.css",
                                        "~/Content/site.css",
                                        "~/Content/styleIndex.css",
                                        "~/Content/ui-grid.css",
                                        "~/Content/angular-block-ui.css"));


            #endregion

        }
    }
}
