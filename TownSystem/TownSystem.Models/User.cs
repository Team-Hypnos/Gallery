namespace TownSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
