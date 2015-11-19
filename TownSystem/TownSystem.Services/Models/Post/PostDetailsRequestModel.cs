namespace TownSystem.Services.Models.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using TownSystem.Common.Constants;
using TownSystem.Services.Models.Comment;

    public class PostDetailsRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxPostTitle)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxPostDescription)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string UserId { get; set; }

        public int TownId { get; set; }

        public ICollection<CommentDetailsRequestModel> Comment { get; set; }
    }
}