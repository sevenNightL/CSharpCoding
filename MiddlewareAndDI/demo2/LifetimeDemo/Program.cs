using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // var host= 
                CreateHostBuilder(args).Build().Run();
            //using (var serviceScope=host.Services.CreateScope())
            //{
            //    var services = serviceScope.ServiceProvider;

            //    try
            //    {
            //        var myDependency = services.GetRequiredService<IMyDependency>();
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
