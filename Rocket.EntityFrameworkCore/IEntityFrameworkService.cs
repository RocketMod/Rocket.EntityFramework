using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkService
    {
        void RegisterContextsByConvention(IPlugin plugin);
        T GetDbContext<T>(IPlugin plugin) where T : PluginDbContext;
    }
}