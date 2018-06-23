namespace Rocket.EntityFrameworkCore
{
    public interface IEntityFrameworkBuilder
    {
        IEntityFrameworkBuilder EnableAutoMigrations();
        IEntityFrameworkBuilder EnableAutoCreation();
        void AddEntityFrameworkCore();
    }
}