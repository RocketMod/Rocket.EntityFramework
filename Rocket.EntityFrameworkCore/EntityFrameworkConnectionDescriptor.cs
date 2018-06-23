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
                    c.ConnectionName.Equals(conf.DefaultConnection, StringComparison.OrdinalIgnoreCase))
                    ?? throw new Exception("Could not find connection settings for: " + conf.DefaultConnection);
            }
        }
    }

    public class EntityFrameworkProvidersConfiguration
    {
        [Comment("The connection provider to use.")]
        public string DefaultConnection = "DefaultMySqlConnection";

        [ConfigArray(ElementName = "ConnectionProvider")]
        [Comment("For connection strings, please have a look at https://www.connectionstrings.com/.")]
        public ConnectionProviderInfo[] Connections { get; set; } =
        {
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultInMemoryConnection",
                ProviderName = "InMemory",
                ConnectionString = "MyDatabaseName"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultMySqlConnection",
                ProviderName = "MySql",
                ConnectionString = "SERVER=localhost; DATABASE=myDataBase; UID=myUsername; PASSWORD=myPassword"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultPostgreSqlConnection",
                ProviderName = "PostgreSql",
                ConnectionString = "User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqliteConnection",
                ProviderName = "Sqlite",
                ConnectionString = "Data Source={PluginDir}\\Plugin.db;Version=3;"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqlServerConnection",
                ProviderName = "SqlServer",
                ConnectionString = "Server=localhost;Database=myDataBase;User Id=myUsername;Password=myPassword;"
            },
            new ConnectionProviderInfo
            {
                ConnectionName = "DefaultSqlServerCompactConnection",
                ProviderName = "SqlServerCompact",
                ConnectionString = "Data Source={PluginDir}\\Plugin.sdf;Persist Security Info=False;"
            }
        };
    }
}