﻿namespace TownSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        public bool IsDeleted { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
