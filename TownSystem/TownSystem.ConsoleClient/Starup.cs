namespace TownSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
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
            IRepository<Category> categories = new EfGenericRepository<Category>(new TownSystemDbContext());
            IRepository<Town> towns = new EfGenericRepository<Town>(new TownSystemDbContext());

            var category = new Category
            {
                Name = "Seasight"
            };
            var town = new Town
            {
                Categories = new List<Category>() { category },
                Name = "Varna"
            };
            Console.WriteLine("Testing for adding town");
            categories.Add(category);
            towns.Add(town);
            // Deleting
            // var towns = data.All();
            // foreach (var t in towns)
            // {
            //    data.Delete(t);
            // }

            categories.SaveChanges();
        }
    }
}
