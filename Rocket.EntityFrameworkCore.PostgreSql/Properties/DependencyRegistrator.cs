using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.PostgreSql.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, PostgreSqlDatabaseProvider> ("PostgreSql");

        }
    }
}