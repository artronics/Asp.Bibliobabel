using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bibliobabel.Web.Plumbing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;


namespace Bibliobabel.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            BootstrapContainer(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //BootstrapContainer();

        }

        protected void Application_End()
        {
            container.Dispose();
            base.Dispose();
        }
        private static void BootstrapContainer(HttpConfiguration configuration)
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
