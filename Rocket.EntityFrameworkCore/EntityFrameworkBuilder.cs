using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Rocket.API.Logging;
using Rocket.API.Plugins;
using Rocket.Core.Logging;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkBuilder : IEntityFrameworkBuilder
    {
        private readonly IEntityFrameworkService _service;
        private readonly IPlugin _plugin;
        private readonly ILogger _logger;
        private bool _wasMigrated;
        private bool _wasCreated;
        public EntityFrameworkBuilder(IEntityFrameworkService service, IPlugin plugin)
        {
            _service = service;
            _plugin = plugin;
            _logger = _plugin.Container.Resolve<ILogger>();
        }

        [Obsolete("Does not work yet.")]
        public IEntityFrameworkBuilder EnableAutoMigrations()
        {
            if (_wasCreated)
                throw new Exception("Can not use EnableAutoMigrations with EnableAutoCreation!");

            if (_wasMigrated)
                return this;

            foreach (var context in _service.GetDbContexts(_plugin))
            {
                _logger.LogDebug(
                    $"\"{_plugin.Name}\": \"{context.GetType().Name}\" migarting.");
                _service.Migrate(_plugin, context);
            }

            _wasMigrated = true;
            return this;
        }

        public IEntityFrameworkBuilder EnableAutoCreation()
        {
            if (_wasMigrated)
                throw new Exception("Can not use EnableAutoCreation with EnableAutoMigrations!");

            if (_wasCreated)
                return this;

            foreach (var context in _service.GetDbContexts(_plugin))
            {
                if (!context.Database.EnsureCreated())
                {
                    _logger.LogDebug(
                        $"\"{_plugin.Name}\": \"{context.GetType().Name}\" exists already.");
                }
                else
                {
                    _logger.LogDebug($"\"{_plugin.Name}\": \"{context.GetType().Name}\" was created.");
                }

                try
                {
                    RelationalDatabaseCreator databaseCreator =
                        (RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
                catch (Exception e)
                {
                    _logger.LogDebug($"\"{_plugin.Name}\": \"{context.GetType().Name}\" failed to create tables", e);
                }
            }

            _wasCreated = true;
            return this;
        }
    }
}