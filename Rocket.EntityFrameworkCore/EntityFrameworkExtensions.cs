using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public static class EntityFrameworkExtensions
    {
        public static void AddEntityFramework(this IPlugin plugin)
        {
            plugin.Container.Resolve<IEntityFrameworkService>().RegisterContextsByConvention(plugin);
        }
    }
}