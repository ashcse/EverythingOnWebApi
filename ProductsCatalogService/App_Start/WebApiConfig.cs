using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac.Integration.WebApi;


namespace ProductsCatalogService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnableCors();
            // attribute routes
            config.MapHttpAttributeRoutes();
            AutofacConfiguration.InitializeDependencies(config);
        }
    }
}
