using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");
            List<testDate> dateTimes = new List<testDate>();
            var testdate1 = new testDate();
            testdate1.startTime = DateTime.Now.Date.AddDays(-1).AddHours(18);
            testdate1.stopTime = DateTime.Now.Date.AddHours(18);
            var testdate2 = new testDate();
            testdate2.startTime = DateTime.Now.Date.AddHours(18);
            testdate2.stopTime = DateTime.Now.Date.AddDays(1).AddHours(18);
            dateTimes.Add(testdate1);
            dateTimes.Add(testdate2);


           var channel = 0 == 0 && dateTimes?.Count > 0
             ? dateTimes.OrderBy(x => x.startTime).First()
             : dateTimes.Count == 2
                 ? dateTimes.OrderBy(x => x.startTime).Last()
                 : null;

            string strtg = "46AXRBQU,BIGCOU5,BIGCOU10";
            
       

            var time = (channel.stopTime - DateTime.Now).TotalHours > 1
              ? TimeSpan.FromHours(1)
              : channel.stopTime - DateTime.Now;

            var date1 = DateTime.Now.Date.AddHours(18);
            services.AddSingleton<ConnectionMultiplexer>(c => ConnectionMultiplexer.Connect("127.0.0.1:6379"));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }


    public class testDate
    {
        public DateTime stopTime  { get; set; }
        public DateTime startTime { get; set; }
    }
}
