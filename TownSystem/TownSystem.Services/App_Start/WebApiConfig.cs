﻿namespace TownSystem.Services
{
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;

    public static class WebApiConfig
    {
        public static HttpConfiguration Config { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            Config = config;
        }
    }
}
