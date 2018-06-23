using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.SqlServer
{
    public class SqlServerDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string DriverName => "SqlServer";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlServer(connectionString);
        }
    }
}