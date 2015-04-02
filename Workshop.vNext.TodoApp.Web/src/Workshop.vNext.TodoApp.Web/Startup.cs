using Microsoft.AspNet.Builder;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;
using System.Linq;
using Newtonsoft.Json.Serialization;

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
