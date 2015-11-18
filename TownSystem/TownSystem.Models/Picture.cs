namespace TownSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Picture
    {
        public Picture()
        {
            this.Towns = new HashSet<Town>();
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FilePath { get; set; }

       // [Required]
        public FileExtensionTypes FileExtension { get; set; }

       // [Required]
        //[MaxLength(100)]
        public string OriginalFileName { get; set; }

        public ICollection<Town> Towns { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
