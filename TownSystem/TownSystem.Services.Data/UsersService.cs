namespace TownSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using Models;
    using TownSystem.Data.Contracts;

   public class UsersService : IUsersService
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
