namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkConnectionDescriptor
    {
        ConnectionProviderInfo ConnectionProviderInfo { get; }
    }
}