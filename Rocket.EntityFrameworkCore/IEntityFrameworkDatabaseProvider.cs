using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkDatabaseProvider
    {
        string ProviderName { get; }
        void UseFor(DbContextOptionsBuilder options, string connectionString);
    }
}