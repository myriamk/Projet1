using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity.WebApi;
using Hermes.MyProfile.Web.App_Start;
using Microsoft.Owin.Security.OAuth;

namespace Hermes.MyProfile.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityResolver(container);

            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
