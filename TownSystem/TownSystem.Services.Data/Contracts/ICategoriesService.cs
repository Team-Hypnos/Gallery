namespace TownSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;
    using Common.Constants;

    public interface ICategoriesService
    {
        IQueryable<Category> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        Category Add(string name);

        IQueryable<Category> ById(string categoryName);
    }
}
