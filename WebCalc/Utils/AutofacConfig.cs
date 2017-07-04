﻿using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using EF = DomainModels.EntityFramework;
using DomainModels.Repository;

namespace WebCalc
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<EF.UserRepository>().As<IUserRepository>();
            builder.RegisterType<EF.ORRepository>().As<IORRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

 
