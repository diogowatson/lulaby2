using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api_version01
{
    public static class WebApiConfig
    {
        public static object Properties { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // config.EnableCors(); -> this enable cors
            //the followingo code enable core for all settings
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
           
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
