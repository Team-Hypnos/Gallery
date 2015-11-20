namespace TownSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public interface IUsersService
    {
        IQueryable<User> ByUsername(string username);

        string UserIdByUsername(string username);
    }
}