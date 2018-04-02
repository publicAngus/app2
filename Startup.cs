using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http;
using app2.DB.Models;

using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

namespace app2
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
            services.AddMvc();
            //services.AddTransient<Models.Providers.IProvider,Models.Providers.TestProvider>();
            /*
            services.AddTransient<Models.Providers.IProvider,Models.Providers.TestProvider>(ServiceProvider=>{
                return new Models.Providers.TestProvider("hello angus");
            });
            */

    
            var appsettings = Configuration.GetSection("Appsettings");
            services.Configure<app2.Models.App.Appsettings>(appsettings);
            
            services.AddDbContext<app2.DB.Models.jumpmanjiContext>((opt)=>{
                //opt.UseMySql("Server=localhost;User Id=beetles;Password=abc123!;Database=jumpmanji;");
                opt.UseMySql(appsettings.GetValue<string>("DBCon"));
            });

            //services.AddSingleton<Models.Providers.IProvider,Models.Providers.TestProvider>(ServiceProvider=>{
                //var appsettings = Configuration.Get<Models.App.Appsettings>();
                //return new Models.Providers.TestProvider("lalaal2018");
            //});
            //services.AddSingleton<Models.Providers.IProvider,Models.Providers.TestProvider>();
            services.AddScoped<Models.Providers.IProvider,Models.Providers.TestProvider>();
             //services.AddSingleton<Models.Providers.IProvider,Models.Providers.DiTestProvider>();
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /* 
            app.Use(async (context,next) =>{
                 await context.Response.WriteAsync("lalal");
                 await next.Invoke();
            });
           
            app.Use(async (context,next) =>{
                 await context.Response.WriteAsync("lalal2");
                 await next.Invoke();
            });
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?tabs=aspnetcore2x
            app.UseForwardedHeaders(new ForwardedHeadersOptions{
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

        }
    }
}
