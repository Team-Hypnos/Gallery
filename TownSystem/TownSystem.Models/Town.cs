namespace TownSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    

    public class Town
    {
        public Town()
        {
            this.Posts = new HashSet<Post>();
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual int? PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
