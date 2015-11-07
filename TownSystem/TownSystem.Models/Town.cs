namespace TownSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    

    public class Town
    {
        public Town()
        {
            this.Id = Guid.NewGuid();
            this.Posts = new HashSet<Post>();
            //this.Pictures = new HashSet<Picture>();
            this.Categories = new HashSet<Category>();
        }

        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual int? PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        //public ICollection<Picture> Pictures { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
