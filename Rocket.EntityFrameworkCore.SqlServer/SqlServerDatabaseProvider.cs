using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.SqlServer
{
    public class SqlServerDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string ProviderName => "SqlServer";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlServer(connectionString);
        }
    }
}