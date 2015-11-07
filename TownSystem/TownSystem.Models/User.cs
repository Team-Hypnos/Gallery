namespace TownSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();           
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

        public virtual int? PictureId { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
