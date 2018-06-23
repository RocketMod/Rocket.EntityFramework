using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.SqlServerCompact.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, SqlServerCompactDatabaseProvider> ("SqlServerCompact", "SqlServerCE");

        }
    }
}