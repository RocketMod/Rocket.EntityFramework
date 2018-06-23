using Microsoft.EntityFrameworkCore;

namespace Rocket.EntityFrameworkCore.InMemory
{
    public class InMemoryDatabaseProvider : IEntityFrameworkDatabaseProvider
    {
        public string ProviderName => "InMemory";
        public void UseFor(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseInMemoryDatabase(connectionString);
        }
    }
}