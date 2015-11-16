namespace TownSystem.Models
{
<<<<<<< HEAD
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
=======
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
>>>>>>> 9ea260a7226da8f65c356ae283295ab261aa529b

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(150)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; } 

        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
