using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Repositories;
using DotKreida.Contracts.Services;
using DotKreida.Services;

namespace DotKreida.App_Start {
    public static class AutofacConfig {
        public static void Configure() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<HomeService>().As<IHomeService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}