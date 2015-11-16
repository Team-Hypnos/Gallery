namespace TownSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    using TownSystem.Data.Contracts;

    public class TownsService : ITownsService
    {
        private readonly IRepository<Category> categories;
        private readonly IRepository<Town> towns;
        private readonly IRepository<Post> posts;

        public TownsService(
            IRepository<Town> townsRepo,
            IRepository<Category> categoriesRepo,
            IRepository<Post> postsRepo)
        {
            this.categories = categoriesRepo;
            this.towns = townsRepo;
            this.posts = postsRepo;
        }

        // TODO: problem in adding categories to the town in POST method
        public Town Add(string name, ICollection<string> category)
        {
            var currentCategories = this.categories
                .All()
                .Where(c => category
                    .Any(x => x == c.Name.ToString()))
                    .ToList();

            if (currentCategories == null)
            {
                throw new ArgumentException("Current category cannot be found!");
            }

            var newTown = new Town
            {
                Name = name,
                Categories = currentCategories
            };
            
            this.towns.Add(newTown);
            this.towns.SaveChanges();

            return newTown;
        }

        public IQueryable<Town> All(int page = 1, int pageSize = 10)
        {
            return this.towns
                .All()
                .OrderByDescending(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Town> MostTrending()
        {
            return this.towns
                .All()
                .OrderByDescending(pr => pr.Posts.Count);
        }
        
        public IQueryable<Town> ById(int id)
        {
            return this.towns
                .All()
                .Where(t => t.Id == id);
        }

        public void Delete(int id)
        {
            var town = this.towns.GetById(id);
            this.towns.Delete(id);
            this.towns.SaveChanges();
        }
    }
}
