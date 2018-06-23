using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkCorePlugin : Plugin
    {
        public EntityFrameworkCorePlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore", container)
        {
        }
    }
}