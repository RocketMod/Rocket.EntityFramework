using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rocket.API.DependencyInjection;
using Rocket.API.Plugins;
using Rocket.Core.Plugins;
using Rocket.EntityFrameworkCore;

namespace ExamplePlugin
{
    public class EFCoreExamplePlugin : Plugin
    {
        public EFCoreExamplePlugin(IDependencyContainer container) : base("EFExample", container)
        {
        }

        protected override void OnLoad(bool isFromReload)
        {
            base.OnLoad(isFromReload);

            this.AddEntityFrameworkCore()
                .EnableAutoCreation();

            var context = this.GetDbContext<MyDbContext>();

            var toAdd = new TestClass
            {
                Name = Guid.NewGuid().ToString()
            };

            Logger.Log($"Adding: \"{toAdd.Name}\" to database");
            context.TestEntries.Add(toAdd);
            context.SaveChanges();

            var entries = context.TestEntries.ToList();
            Logger.Log("Entry count: " + entries.Count);
            foreach (var entry in entries)
            {
                Logger.Log($"[{entry.Id}] \"{entry.Name}\"");
            }
        }
    }

    public class MyDbContext : PluginDbContext
    {
        public virtual DbSet<TestClass> TestEntries { get; set; }

        public MyDbContext(IPlugin plugin, IEntityFrameworkConnectionDescriptor descriptor) : base(plugin, descriptor)
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }

    public class TestClass
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
