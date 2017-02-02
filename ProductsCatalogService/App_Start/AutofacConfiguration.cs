using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using ProductsCatalogService.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace ProductsCatalogService
{
    /// <summary>
    /// Registers type for dependency injection
    /// </summary>
    public class AutofacConfiguration
    {
        public static void InitializeDependencies(HttpConfiguration appConfiguration)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterWebApiFilterProvider(appConfiguration);
            containerBuilder.Register(a => HttpContext.Current.User).As<System.Security.Principal.IPrincipal>();
            containerBuilder.RegisterType<DAL.DataService.ProductService>().As<DAL.DataService.IProductService>();
            containerBuilder.RegisterType<ApplicationAccess>().As<IApplicationAccess>().SingleInstance();
            IContainer container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
            appConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}