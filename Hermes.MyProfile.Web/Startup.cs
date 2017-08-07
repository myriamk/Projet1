using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.WebApi;
using Microsoft.Owin.Cors;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
//using System.Web.Mvc;
//using System.Web.Routing;
//using System.Web.Optimization;

namespace Hermes.MyProfile.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
           WebApiConfig.Register(config);

            //GlobalConfiguration.Configure(WebApiConfig.Register);
          //  AreaRegistration.RegisterAllAreas();

           FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAuth(app);
           app.UseCors(CorsOptions.AllowAll);

            // register the WebApi Middleware within the Owin context
            app.UseWebApi(config);
            

        }
    }
}
