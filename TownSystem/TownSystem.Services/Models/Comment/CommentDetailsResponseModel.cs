namespace TownSystem.Services.Models.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TownSystem.Models;

    public class CommentDetailsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {

        public int? PostId { get; set; }

        public string PostName { get; set; }

        [MinLength(4, ErrorMessage = "Content must be at least 4 characters long.")]
        [MaxLength(100, ErrorMessage = "Content must be no longer than 100 characters.")]
        public string Content { get; set; }

        public string UserName { get; set; }

        public bool isDeleted { get; set; }


        public DateTime TimePosted { get; set; }

        public string ShortDateForm
        {
            get { return this.TimePosted.ToString("dd MMM yyyy"); }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentDetailsResponseModel>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}