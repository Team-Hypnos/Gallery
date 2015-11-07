namespace TownSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;

    using Data;
    using Data.Contracts;
    using Data.Migrations;
    using Models;


    public class Starup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TownSystemDbContext, Configuration>());
            IRepository<Town> data = new EfGenericRepository<Town>(new TownSystemDbContext());

            var town = new Town
            {
                Name = "Sofia"
            };

            Console.WriteLine("Testing for adding town");
            data.Add(town);

            // Deleting
            // var towns = data.All();
            // foreach (var t in towns)
            // {
            //    data.Delete(t);
            // }

            data.SaveChanges();
        }
    }
}
