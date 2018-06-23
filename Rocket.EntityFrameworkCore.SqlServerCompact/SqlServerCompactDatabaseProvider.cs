using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.SqlServerCompact
{
    public class SqlServerCompactDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string DriverName => "SqlServer";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlCe(connectionString);
        }
    }
}