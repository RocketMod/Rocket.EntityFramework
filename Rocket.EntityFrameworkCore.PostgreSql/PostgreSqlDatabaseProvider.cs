using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.PostgreSql
{
    public class PostgreSqlDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string ProviderName => "PostgreSql";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseNpgsql(connectionString);
        }
    }
}