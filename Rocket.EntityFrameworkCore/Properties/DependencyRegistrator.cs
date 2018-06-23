using Rocket.API.DependencyInjection;

namespace Rocket.EntityFrameworkCore.Properties
{
    public class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterType<IEntityFrameworkConnectionDescriptor, EntityFrameworkConnectionDescriptor>();
            container.RegisterSingletonType<IEntityFrameworkService, EntityFrameworkService>();
        }
    }
}