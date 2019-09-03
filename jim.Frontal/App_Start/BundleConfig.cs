using System.Web;
using System.Web.Optimization;

namespace jim.Frontal
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Scripts js
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/Scripts/jquery-{version}.js",
                                "~/Scripts/jquery-ui.js",
                                "~/Scripts/jquery.validate.min.js",
                                "~/Scripts/jquery.validate.unobtrusive.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/budles/moment")
                .Include("~/Scripts/moment.js"));


            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                    .IncludeDirectory("~/Scripts/App", "*.js", true));
            #endregion

            #region CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css",
                     "~/Content/Themes/base/all.css"));
            #endregion

        }
    }
}
