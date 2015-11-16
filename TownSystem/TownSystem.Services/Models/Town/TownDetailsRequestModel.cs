namespace TownSystem.Services.Models.Town
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TownSystem.Common.Constants;
    using TownSystem.Models;
    using Infrastructure.Mapping;

    public class TownDetailsRequestModel : IMapFrom<Category>
    {
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<string> Categories { get; set; }

        public int PictureId { get; set; }
    }
}