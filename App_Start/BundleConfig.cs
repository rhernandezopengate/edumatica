using System.Web;
using System.Web.Optimization;

namespace OpenGateLogistics
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"                       
                        ));

            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/vendors/bootstrap/dist/css/bootstrap.min.css",
                      "~/vendors/font-awesome/css/font-awesome.min.css",
                      "~/vendors/nprogress/nprogress.css",
                      "~/vendors/iCheck/skins/flat/green.css",
                      "~/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                      "~/vendors/jqvmap/dist/jqvmap.min.css",
                      "~/vendors/bootstrap-daterangepicker/daterangepicker.css",
                      "~/build/css/custom.min.css"));
        }
    }
}
