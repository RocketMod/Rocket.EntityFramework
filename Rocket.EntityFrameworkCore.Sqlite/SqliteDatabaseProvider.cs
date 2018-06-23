using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.Sqlite
{
    public class SqliteDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string ProviderName => "Sqlite";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlite(connectionString);
        }
    }
}