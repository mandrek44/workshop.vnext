using System;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.OptionsModel;
using Workshop.vNext.TodoApp.Web.Models;

namespace Workshop.vNext.TodoApp.Web.Infrastructure
{
    public class TodosContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptions dbOptions)
        {
            // TODO: Inject options, make it pretty
            var configuration = new Configuration();
            configuration.AddJsonFile("persistenceConfig.json");
            var persistenceConfig = new PersistenceConfig();
            OptionsServices.ReadProperties(persistenceConfig, configuration);

            if (persistenceConfig.Provider == "InMemory")
            {
                dbOptions.UseInMemoryStore();
            }
            else
            {
                throw new Exception($"Unknown persistence provider: {persistenceConfig.Provider}");
            }

            base.OnConfiguring(dbOptions);
        }
    }
}
