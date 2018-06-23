using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.Sqlite
{
    public class EntityFrameworkCoreSqlitePlugin : Plugin
    {
        public EntityFrameworkCoreSqlitePlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.Sqlite", container)
        {
        }
    }
}