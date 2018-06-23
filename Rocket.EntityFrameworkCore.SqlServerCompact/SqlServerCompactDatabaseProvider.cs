using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.SqlServerCompact
{
    public class SqlServerCompactDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string ProviderName => "SqlServer";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlCe(connectionString);
        }
    }
}