﻿namespace TownSystem.Services.Models.Comment
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;
    using MissingFeatures;
    using Newtonsoft.Json;
    using TownSystem.Models;

    public class CommentDetailsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {

        public int? PostId { get; set; }

        public string PostName { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public bool isDeleted { get; set; }

        //public string PostNameUrl
        //{
        //    get
        //    {
        //        return this.PostName.ToUrl();
        //    }
        //}


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