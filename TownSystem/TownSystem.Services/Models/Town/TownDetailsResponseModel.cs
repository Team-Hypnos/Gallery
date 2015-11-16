namespace TownSystem.Services.Models.Town
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Common.Constants;
    using TownSystem.Models;
    using Infrastructure.Mapping;

    public class TownDetailsResponseModel : IMapFrom<Town>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        //public ICollection<Category> Categories { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Town, TownDetailsResponseModel>();
                //.ForMember(t => t.Categories, opts => opts.MapFrom(e => e.Categories.OrderByDescending(x => x.Name)));
        }
    }
}