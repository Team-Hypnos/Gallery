namespace TownSystem.Services.Models.Post
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TownSystem.Services.Infrastructure.Mapping;
    using TownSystem.Models;
    using TownSystem.Common.Constants;
using System.Collections;
    using System.Collections.Generic;

    public class PostDetailsResponseModel : IMapFrom<Post>, IHaveCustomMappings 
    {
        public const int ShortDescriptionLength = 300;

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public string UserName { get; set; }

        public int Likes { get; set; }

        public int CommentsCount { get; set; }

        public bool IsLiked { get; set; }

        public string Picture { get; set; }

        public string Town { get; set; }

        public string ShortDate
        {
            get
            {
                return this.DateCreated.ToString(GlobalConstants.ShortDateFormat);
            }
        }

        public string ShortDescription
        {
            get
            {
                if (this.Description.Length <= ShortDescriptionLength)
                {
                    return this.Description;
                }
                else
                {
                    return this.Description.Substring(0, ShortDescriptionLength) + "...";
                }
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            string username = null;
            configuration.CreateMap<Post, PostDetailsResponseModel>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(p => p.User.UserName))
                .ForMember(p => p.Likes, opt => opt.MapFrom(p => p.Likes.Count))
                .ForMember(p => p.CommentsCount, opt => opt.MapFrom(p => p.Comments.Count))
                .ForMember(p => p.IsLiked, opt => opt.MapFrom(p => p.Likes.Any(l => l.User.UserName == username)))
                .ForMember(p => p.Picture, opt => opt.MapFrom(p => p.Town.Picture.FilePath))
                .ForMember(p => p.Town, opt => opt.MapFrom(p => p.Town.Name));
        }
    }
}