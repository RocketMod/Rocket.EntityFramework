using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.PostgreSql
{
    public class EntityFrameworkCorePostgreSqlPlugin : Plugin
    {
        public EntityFrameworkCorePostgreSqlPlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.PostgreSql", container)
        {
        }
    }
}