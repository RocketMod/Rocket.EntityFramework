using System.Collections.Generic;
using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkService
    {
        void RegisterContextsByConvention(IPlugin plugin, EntityFrameworkBuilder builder);
        T GetDbContext<T>(IPlugin plugin) where T : PluginDbContext;
        void Migrate(IPlugin plugin, PluginDbContext context);
        IEnumerable<PluginDbContext> GetDbContexts(IPlugin plugin);
    }
}