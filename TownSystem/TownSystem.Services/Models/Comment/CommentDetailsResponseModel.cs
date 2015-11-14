namespace TownSystem.Services.Models.Comment
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using MissingFeatures;
    using Newtonsoft.Json;
    using TownSystem.Models;

    public class CommentDetailsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        public string PostName { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public bool isDeleted { get; set; }

        public string PostNameUrl
        {
            get
            {
                return this.PostName.ToUrl();
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            string username = null;
            configuration.CreateMap<Comment, CommentDetailsResponseModel>()
                .ForMember(c => c.Username, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}