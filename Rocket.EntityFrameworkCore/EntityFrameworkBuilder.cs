using Rocket.API.Plugins;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkBuilder : IEntityFrameworkBuilder
    {
        private readonly IEntityFrameworkService _service;
        private readonly IPlugin _plugin;

        public EntityFrameworkBuilder(IEntityFrameworkService service, IPlugin plugin)
        {
            _service = service;
            _plugin = plugin;
        }

        public IEntityFrameworkBuilder EnableAutoMigrations()
        {
            foreach (var context in _service.GetDbContexts(_plugin))
            {
                //_service.Migrate(_plugin, context);
                context.Database.EnsureCreated();
            }

            return this;
        }
    }
}