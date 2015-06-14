using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bibliobabel.Data;
using Bibliobabel.Data.Repositories;
using Bibliobabel.Domain.Models;
using Bibliobabel.Web.Areas.Api.Controllers;
using Bibliobabel.Web.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bibliobabel.Web.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());
            container.Register(Component.For<IDbContext>().ImplementedBy<ApplicationDbContext>());
            container.Register(Component.For<IRepository<Post>>().ImplementedBy<Repository<Post>>());
            //container.Register(Component.For<IAppUser>().ImplementedBy<Data.User>());
        }
    }
}