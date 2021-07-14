using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            var output = new StringWriter();
            builder.RegisterInstance(output).As<TextWriter>();
            builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();
           
            


            builder.RegisterType<ConsoleLogger>();
            builder.RegisterType(typeof(ConfigReader));
            var container = builder.Build();

            using (var scope=container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<IConfigReader>();
            }

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }

    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }


    public class StringWriter : TextWriter
    {
        public override Encoding Encoding => throw new NotImplementedException();
    }

    public interface IConfigReader
    { }

    public class ConfigReader
    {
        private string _mySection;

        public ConfigReader(string mySection)
        {
            _mySection = mySection;
        }
    }

    public class MyComponet
    {
        private ILogger _logger;
        private IConfigReader _reader;

        public MyComponet()
        {

        }
        public MyComponet(ILogger logger)
        {
            _logger = logger;
        }
        public MyComponet(ILogger logger,IConfigReader reader)
        {
            _logger = logger;
            _reader = reader;
        }
    }
}
