namespace TownSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        int Add(string name);

        IQueryable<Category> ById(string categoryName);
    }
}
