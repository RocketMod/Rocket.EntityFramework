using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.MySql
{
    public class MySqlDatabaseProvider: IEntityFrameworkDatabaseProvider
    {
        public string DriverName => "MySql";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseMySql(connectionString);
        }
    }
}