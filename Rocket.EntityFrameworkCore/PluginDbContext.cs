using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rocket.API;
using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public abstract class PluginDbContext : DbContext
    {
        private readonly IPlugin _plugin;
        private bool _createdFromOptions;
        protected PluginDbContext(DbContextOptions options) : base(options)
        {
            _createdFromOptions = true;
        }

        protected PluginDbContext(IPlugin plugin, IEntityFrameworkConnectionDescriptor descriptor)
        {
            ConnectProviderInfo = descriptor.ConnectionInfo;
            _plugin = plugin;
        }

        public EntityFrameworkConnectionInfo ConnectProviderInfo { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_createdFromOptions)
                return;

            var databaseProvider = _plugin.Container.ResolveAll<IEntityFrameworkDatabaseProvider>()
                .FirstOrDefault(c => c.ProviderName.Equals(ConnectProviderInfo.ProviderName, StringComparison.OrdinalIgnoreCase));

            if (databaseProvider == null)
                throw new Exception("Failed to resolve database provider: " + ConnectProviderInfo.ProviderName);

            var connectionString = ConnectProviderInfo.ConnectionString
                .Replace("{PluginDir}", _plugin.WorkingDirectory)
                .Replace("{PluginName}", _plugin.Name)
                .Replace("{Game}", _plugin.Container.Resolve<IHost>().Name)
                .Replace("{RocketDir}", _plugin.Container.Resolve<IRuntime>().WorkingDirectory);

            databaseProvider.UseFor(optionsBuilder, connectionString);
        }
    }
}