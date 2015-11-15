namespace TownSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class TownSystemDbContext : IdentityDbContext<User>, ITownSystemDbContext 
    {
        public TownSystemDbContext()
            : base("TownSystem", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Like> Likes { get; set; }

        public static TownSystemDbContext Create()
        {
            return new TownSystemDbContext();
        }
    }
}
