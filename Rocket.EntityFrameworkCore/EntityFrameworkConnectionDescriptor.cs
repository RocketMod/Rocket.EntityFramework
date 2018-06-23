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
                return conf.Connections.FirstOrDefault(c =>
                    c.ConnectionName.Equals(conf.DefaultConnection, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    public class EntityFrameworkProvidersConfiguration
    {
        [Comment("The connection provider to use.")]
        public string DefaultConnection = "MySQL";

        [ConfigArray(ElementName = "ConnectionProvider")]
        [Comment("For connection strings, please have a look at https://www.connectionstrings.com/.")]
        public ConnectionProviderInfo[] Connections { get; set; } =
        {
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultInMemory",
                ProviderName = "InMemory",
                ConnectionString = "MyDatabaseName"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultMySql",
                ProviderName = "MySql",
                ConnectionString = "SERVER=localhost; DATABASE=unturned; UID=myUsername; PASSWORD=myPassword"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultPostgreSql",
                ProviderName = "PostgreSql",
                ConnectionString = "MyDatabaseName"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqlite",
                ProviderName = "Sqlite",
                ConnectionString = "Data Source={PluginDir}\\Plugin.db;Version=3;"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqlServer",
                ProviderName = "SqlServer",
                ConnectionString = "Server=localhost;Database=myDataBase;User Id=myUsername;Password=myPassword;"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqlServerCompact",
                ProviderName = "SqlServerCompact",
                ConnectionString = "Data Source={PluginDir}\\Plugin.sdf;Persist Security Info=False;"
            }
        };
    }
}