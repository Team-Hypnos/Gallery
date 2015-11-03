namespace TownSystem.Data
{
    using System.Data.Entity;
    using TownSystem.Models;

    public class TownSystemDbContext : DbContext
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
    }
}
