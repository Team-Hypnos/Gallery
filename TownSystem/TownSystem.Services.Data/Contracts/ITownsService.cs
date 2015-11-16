namespace TownSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using TownSystem.Models;

    public interface ITownsService
    {
        IQueryable<Town> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        IQueryable<Town> ById(int id);

        Town Add(string name,ICollection<string> category);

        IQueryable<Town> MostTrending();

        void Delete(int id);
    }
}
