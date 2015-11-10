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
            IRepository<Category> data = new EfGenericRepository<Category>(new TownSystemDbContext());

            var category = new Category
            {
                Name = "Seasight"
            };

            Console.WriteLine("Testing for adding town");
            data.Add(category);

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
