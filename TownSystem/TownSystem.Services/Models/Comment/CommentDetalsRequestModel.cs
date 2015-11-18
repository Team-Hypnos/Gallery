namespace TownSystem.Services.Models.Comment
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TownSystem.Models;

    public class CommentDetalsRequestModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Content { get; set; }

        public int? PostId { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentDetailsResponseModel>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}