namespace TownSystem.Services.Data
{
    using System;
    using System.Linq;
    using Models;
    using Contracts;
    using TownSystem.Data.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;
        private readonly IRepository<Town> towns;

        public CategoriesService(
            IRepository<Town> townsRepo,
            IRepository<Category> categoriesRepo)
        {
            this.categories = categoriesRepo;
            this.towns = townsRepo;
        }

        public int Add(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or whitespace!");
            }
            
            var newCategory = new Category
            {
                Name = name
            };
            
            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory.Id;
        }

        public IQueryable<Category> All()
        {
            return this.categories
                .All()
                .OrderByDescending(c => c.Name);
        }

        public IQueryable<Category> ById(string categoryName)
        {
            return this.categories
                .All()
                .Where(c => c.Name.ToString().ToLower() == categoryName);
        }
    }
}
