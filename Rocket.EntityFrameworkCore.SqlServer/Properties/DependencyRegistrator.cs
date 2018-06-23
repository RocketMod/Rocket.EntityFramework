using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.SqlServer.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, SqlServerDatabaseProvider> ("SqlServer");

        }
    }
}