using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace AppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sample1
            //var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();


            //var output = new StringWriter();
            //builder.RegisterInstance(output).As<TextWriter>();
            //builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();

            //var container = builder.Build();
            //using (var scope=container.BeginLifetimeScope())
            //{
            //    var reader = scope.Resolve<IConfigReader>();
            //}
            #endregion

            #region Register by type
            //var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleLogger>();
            //builder.RegisterType(typeof(ConfigReader));
            #endregion

            #region sample3

            //var builder = new ContainerBuilder();
            //builder.RegisterType<MyComponent>();
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();
            //var container = builder.Build();

            //using (var scope=container.BeginLifetimeScope())
            //{
            //    var component = scope.Resolve<MyComponent>();
            //}

            #endregion

            #region sample4
            //var builder = new ContainerBuilder();
            //builder.RegisterType<MyComponent>();
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();
            //var container = builder.Build();
            //using (var scope=container.BeginLifetimeScope())
            //{
            //    var component = scope.Resolve<MyComponent>();
            //}
            #endregion

            #region specifying a Constructor
            //var builder = new ContainerBuilder();
            //builder.RegisterType<MyComponent>()
            //    .UsingConstructor(typeof(ILogger), typeof(IConfigReader));
            //var container = builder.Build();
            //using (var scope=container.BeginLifetimeScope())
            //{
            //    var component = scope.Resolve<MyComponent>();
            //}
            #endregion

            #region Instance Components
            var builder = new ContainerBuilder();
            var output = new StringWriter();
            builder.RegisterInstance(output).As<TextWriter>();
            #endregion

            Console.WriteLine("Hello World!");
            testss();
            int i = 5;
            
        }

        public static void testss()
        {
            int sdf = 9;
        }
    }





   
}
