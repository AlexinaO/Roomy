using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Roomy
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            this.Configuration = builder.Build();
            Debug.WriteLine($"connection string: {this.Configuration.GetConnectionString("DefaultConnection")}");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(
                    culture: this.Configuration.GetSection("languages")["langue"],
                    uiCulture: this.Configuration.GetSection("languages")["langue"])
            });

            app.Use(async(context, next) => {
                var statusCode = context.Request.Query["statuscode"];
                Debug.WriteLine($"Code: {statusCode}");
                if(!string.IsNullOrWhiteSpace(statusCode))
                {
                    await Task.FromResult(0);
                }
                else
                {
                    context.Response.StatusCode = 305;
                    await next();
                }
            });

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoute);

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello world!");
            });*/
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
