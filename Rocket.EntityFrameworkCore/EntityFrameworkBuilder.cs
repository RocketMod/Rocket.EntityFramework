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

        //todo: 
        //public IEntityFrameworkBuilder DisableAutoMigrations()
    }
}