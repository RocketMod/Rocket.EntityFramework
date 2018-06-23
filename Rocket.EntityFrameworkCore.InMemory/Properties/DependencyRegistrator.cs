using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.InMemory.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkDatabaseProvider, InMemoryDatabaseProvider> ("InMemory");

        }
    }
}