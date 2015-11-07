
namespace TownSystem.Data
{
    using System.Data.Entity;
    using TownSystem.Data.Contracts;
    using Models;

    public class TownSystemDbContext : DbContext, ITownSystemDbContext
    {
        public TownSystemDbContext()
            : base("TownSystem")
        {

        }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static TownSystemDbContext Create()
        {
            return new TownSystemDbContext();
        }
    }
}
