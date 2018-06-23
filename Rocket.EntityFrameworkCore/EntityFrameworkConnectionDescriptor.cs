using System;
using System.Linq;
using Rocket.API;
using Rocket.API.Configuration;
using Rocket.Core.Configuration;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkConnectionDescriptor : IEntityFrameworkConnectionDescriptor
    {
        private readonly IRuntime _runtime;
        private readonly IConfiguration _config;
        private ConfigurationContext _context;

        public EntityFrameworkConnectionDescriptor(IRuntime runtime, IConfiguration config)
        {
            _runtime = runtime;
            _config = config;
        }

        public EntityFrameworkConnectionInfo ConnectionInfo
        {
            get
            {
                if (_context == null)
                {
                    _context = new ConfigurationContext(_runtime.WorkingDirectory, "Rocket.EntityFrameworkCore");
                    _config.Load(_context, new EntityFrameworkProvidersConfiguration());
                }
                var conf = _config.Get<EntityFrameworkProvidersConfiguration>();
                return conf.Connections.FirstOrDefault(c =>
                    c.ConnectionName.Equals(conf.DefaultConnection, StringComparison.OrdinalIgnoreCase))
                    ?? throw new Exception("Could not find connection settings for: " + conf.DefaultConnection);
            }
        }
    }
}