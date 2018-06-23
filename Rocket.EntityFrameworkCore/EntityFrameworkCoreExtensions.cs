using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static void AddEntityFrameworkCore(this IPlugin plugin)
        {
            plugin.Container.Resolve<IEntityFrameworkService>().RegisterContextsByConvention(plugin);
        }

        public static T GetDbContext<T>(this IPlugin plugin) where T : PluginDbContext
        {
            return plugin.Container.Resolve<IEntityFrameworkService>().GetDbContext<T>(plugin);
        }
    }
}