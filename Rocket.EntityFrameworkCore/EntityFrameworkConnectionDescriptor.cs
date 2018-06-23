using System;
using System.Linq;
using Rocket.API;
using Rocket.API.Configuration;
using Rocket.Core.Configuration;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkConnectionDescriptor : IEntityFrameworkConnectionDescriptor
    {
        private readonly IRuntime _runtime;
        private readonly IConfiguration _config;
        private ConfigurationContext _context;

        public EntityFrameworkConnectionDescriptor(IRuntime runtime, IConfiguration config)
        {
            _runtime = runtime;
            _config = config;
        }

        public ConnectionProviderInfo ConnectionProviderInfo
        {
            get
            {
                if (_context == null)
                {
                    _context = new ConfigurationContext(_runtime.WorkingDirectory, "Rocket.EntityFramework");
                    _config.Load(_context, new EntityFrameworkProvidersConfiguration());
                }
                var conf = _config.Get<EntityFrameworkProvidersConfiguration>();
                return conf.ConnectionProviders.FirstOrDefault(c =>
                    c.ProviderName.Equals(conf.SelectedProvider, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    public class EntityFrameworkProvidersConfiguration
    {
        public string SelectedProvider = "MySQL";

        [ConfigArray(ElementName = "ConnectionProvider")]
        public ConnectionProviderInfo[] ConnectionProviders { get; set; } =
        {
            new ConnectionProviderInfo
            {
                ProviderName = "MySQL",
                ConnectionString = "SERVER=localhost; DATABASE=unturned; UID=myUsername; PASSWORD=myPassword",
            },
            new ConnectionProviderInfo
            {
                ProviderName = "SQLite",
                ConnectionString = "Data Source={PluginDir}\\Plugin.db;Version=3;",
            }
        };
    }
}