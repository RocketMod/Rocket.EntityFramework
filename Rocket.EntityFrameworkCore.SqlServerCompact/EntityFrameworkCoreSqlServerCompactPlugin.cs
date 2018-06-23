using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.SqlServerCompact
{
    public class EntityFrameworkCoreSqlServerCompactPlugin: Plugin
    {
        public EntityFrameworkCoreSqlServerCompactPlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.SqlServerCompact", container)
        {
        }
    }
}