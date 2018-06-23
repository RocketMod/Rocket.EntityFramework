using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.Sqlite.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, SqliteDatabaseProvider> ("Sqlite");

        }
    }
}