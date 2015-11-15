namespace TownSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Models;
    using TownSystem.Data.Contracts;

    class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> ByUsername(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }


        public string UserIdByUsername(string username)
        {
            return this.users
                 .All()
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        //public bool UserIsAdmin(string username)
        //{
        //    return this.users
        //        .All()
        //        .Where(u => u.UserName == username)
        //        .Select(u => u.IsAdmin)
        //        .FirstOrDefault();
        //}
    }
}
