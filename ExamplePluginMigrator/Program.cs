using ExamplePlugin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExamplePluginMigrator
{
    // To use EF Core migrations we need a dummy .exe file
    // Use command: Add-Migration Initial -Project ExamplePluginMigrator to add migrations
    public class Program
    {
        static void Main()
        {
            //dummy
        }
    }

    public class MyPluginDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();

            //Replace with what you use on your dev machine
            builder.UseMySql("SERVER=localhost; DATABASE=unturned; UID=root", 
                // Here you add the name of your migrator without ".exe"
                b => b.MigrationsAssembly("ExamplePluginMigrator"));

            return new MyDbContext(builder.Options);
        }
    }
}