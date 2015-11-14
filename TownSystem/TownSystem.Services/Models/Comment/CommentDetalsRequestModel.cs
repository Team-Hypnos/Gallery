namespace TownSystem.Services.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TownSystem.Models;

    public class CommentDetalsRequestModel
    {
        public int Id { get; set; }

        [MinLength(4)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}