using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkDatabaseProvider
    {
        string DriverName { get; }
        void UseFor(DbContextOptionsBuilder options, string connectionString);
    }
}