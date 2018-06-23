using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace Rocket.EntityFrameworkCore.MySql
{
    public class EntityFrameworkCoreMySqlPlugin : Plugin
    {
        public EntityFrameworkCoreMySqlPlugin(IDependencyContainer container) : base("Rocket.EntityFrameworkCore.MySql", container)
        {
        }
    }
}