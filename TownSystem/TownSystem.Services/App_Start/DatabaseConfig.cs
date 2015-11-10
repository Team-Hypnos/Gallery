namespace TownSystem.Services
{
    using System.Data.Entity;
    using TownSystem.Data;
    using TownSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TownSystemDbContext, Configuration>());
            TownSystemDbContext.Create().Database.Initialize(true);
        }
    }
}