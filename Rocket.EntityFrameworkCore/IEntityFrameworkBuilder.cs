namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkBuilder
    {
        IEntityFrameworkBuilder EnableAutoMigrations();
    }
}