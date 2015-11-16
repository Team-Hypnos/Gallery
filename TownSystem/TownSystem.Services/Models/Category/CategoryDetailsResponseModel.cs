namespace TownSystem.Services.Models.Category
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TownSystem.Models;

    public class CategoryDetailsResponseModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryDetailsResponseModel>();
        }
    }
}