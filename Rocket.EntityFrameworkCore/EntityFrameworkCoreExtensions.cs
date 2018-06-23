using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static void AddEntityFrameworkCore(this IPlugin plugin)
        {
            plugin.Container.Resolve<IEntityFrameworkService>().RegisterContextsByConvention(plugin);
        }
    }
}