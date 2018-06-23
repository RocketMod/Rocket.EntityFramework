using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.SqlServer
{
    public class EntityFrameworkCoreSqlServerPlugin: Plugin
    {
        public EntityFrameworkCoreSqlServerPlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.SqlServer", container)
        {
        }
    }
}