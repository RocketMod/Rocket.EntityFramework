using Rocket.Core.Configuration;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkProvidersConfiguration
    {
        [Comment("The connection provider to use.")]
        public string DefaultConnection = "DefaultMySqlConnection";

        [ConfigArray(ElementName = "ConnectionProvider")]
        [Comment("For connection strings, please have a look at https://www.connectionstrings.com/.")]
        public EntityFrameworkConnectionInfo[] Connections { get; set; } =
        {
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultInMemoryConnection",
                ProviderName = "InMemory",
                ConnectionString = "MyDatabaseName"
            },
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultMySqlConnection",
                ProviderName = "MySql",
                ConnectionString = "SERVER=localhost; DATABASE=myDataBase; UID=myUsername; PASSWORD=myPassword"
            },
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultPostgreSqlConnection",
                ProviderName = "PostgreSql",
                ConnectionString = "User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;"
            },
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultSqliteConnection",
                ProviderName = "Sqlite",
                ConnectionString = "Data Source={PluginDir}\\Plugin.db;Version=3;"
            },
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultSqlServerConnection",
                ProviderName = "SqlServer",
                ConnectionString = "Server=localhost;Database=myDataBase;User Id=myUsername;Password=myPassword;"
            },
            new EntityFrameworkConnectionInfo
            {
                ConnectionName = "DefaultSqlServerCompactConnection",
                ProviderName = "SqlServerCompact",
                ConnectionString = "Data Source={PluginDir}\\Plugin.sdf;Persist Security Info=False;"
            }
        };
    }
}