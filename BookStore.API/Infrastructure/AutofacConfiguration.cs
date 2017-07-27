using Autofac;
using BookStore.Logging.Abstract;
using BookStore.Logging.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.API.Infrastructure
{
    public static class AutofacConfiguration
    {
        public static void Configure()
        {
            SetupAutofac();
        }

        private static void SetupAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            
            var container = builder.Build();
            //TODO: end resolving
        }
    }
}