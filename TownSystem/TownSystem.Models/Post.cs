namespace TownSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(150)]
        public string Description { get; set; }

        public int Likes { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Guid TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
