using Microsoft.AspNet.Builder;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Http;
using System;

namespace Workshop.vNext.TodoApp.Web
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().Configure<MvcOptions>(options =>
            {
                options.OutputFormatters
                    .Where(f => f.Instance is JsonOutputFormatter)
                    .Select(f => f.Instance as JsonOutputFormatter)
                    .First()
                    .SerializerSettings
                    .ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Allo CORS
            app.Use((context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "*" });
                return next();
            });

            // Log requests
            app.Use((context, next) =>
            {
                Console.WriteLine(context.Request.Method + " " + context.Request.ContentType  + " " + context.Request.Path + context.Request.QueryString );
                return next();
            });

            app.UseErrorPage();

            app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = false
            });

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}
