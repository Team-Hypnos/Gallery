namespace TownSystem.Models
{
    using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
            this.Towns = new HashSet<Town>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FilePath { get; set; }

        [Required]
        public FileExtensionTypes FileExtension { get; set; }

        [Required]
        [MaxLength(100)]
        public string OriginalFileName { get; set; }

        //public virtual Guid? TownId { get; set; }

        //public virtual Town Town { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
