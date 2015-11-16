namespace TownSystem.Services.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Common.Constants;
    using TownSystem.Models;

    public class CommentDetalsRequestModel
    {
        public int Id { get; set; }

        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; }
    }
}