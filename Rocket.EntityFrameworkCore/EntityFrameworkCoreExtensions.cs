using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static IEntityFrameworkBuilder AddEntityFrameworkCore(this IPlugin plugin)
        {
            var service = plugin.Container.Resolve<IEntityFrameworkService>();
            service.RegisterContextsByConvention(plugin);
            return new EntityFrameworkBuilder(service, plugin);
        }

        public static T GetDbContext<T>(this IPlugin plugin) where T : PluginDbContext
        {
            return plugin.Container.Resolve<IEntityFrameworkService>().GetDbContext<T>(plugin);
        }
    }
}