namespace TownSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required]
        public CategoryTypes Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
