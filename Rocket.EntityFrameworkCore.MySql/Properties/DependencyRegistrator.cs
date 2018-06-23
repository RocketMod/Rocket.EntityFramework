using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.MySql.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, MySqlDatabaseProvider> ("MySQL");

        }
    }
}