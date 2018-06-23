namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkConnectionDescriptor
    {
        EntityFrameworkConnectionInfo ConnectionInfo { get; }
    }
}