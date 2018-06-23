using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.InMemory
{
    public class EntityFrameworkCoreInMemoryPlugin : Plugin
    {
        public EntityFrameworkCoreInMemoryPlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.InMemory", container)
        {
        }
    }
}