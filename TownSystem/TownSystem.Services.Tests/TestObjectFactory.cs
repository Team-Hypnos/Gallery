namespace TownSystem.Api.Tests
{
    using Services.Data.Contracts;
    using Moq;
    using Models;
    using Services.Models.Comment;
    using System.Collections.Generic;
    using System.Linq;
    using Services.Models.Town;

    public static class TestObjectFactory
    {
        private static IQueryable<Town> towns = new List<Town>
        {
            new Town
            {
                Id = 1,
                Name = "Sofia"
            },
            new Town
            {
                Id = 2,
                Name = "pLOVEdiv"
            }
        }.AsQueryable();

        public static ICommentsService GetCommentsService()
        {
            var commentsService = new Mock<ICommentsService>();
            commentsService.Setup(c => c.Add(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new Comment() { Id = 1 });

            return commentsService.Object;
        }

        public static ITownsService GetTownsService()
        {
            var townsService = new Mock<ITownsService>();
            townsService.Setup(t => t.All(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Town>().AsQueryable());

            townsService.Setup(t => t.ById(It.IsAny<int>())).Returns(towns);

            return townsService.Object;
        }

        public static CommentDetalsRequestModel GetInvalidModel()
        {
            return new CommentDetalsRequestModel { Content = "invalid test model" };
        }

        public static TownDetailsRequestModel GetValidTownModel()
        {
            return new TownDetailsRequestModel { Name = "Invaid Sofia" };
        }

        public static TownDetailsRequestModel GetInvalidTownModel()
        {
            return new TownDetailsRequestModel { Name = "S" };
        }
    }
}
