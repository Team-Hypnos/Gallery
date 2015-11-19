namespace TownSystem.Api.Tests
{
    using Services.Data.Contracts;
    using Moq;
    using Models;
    using Services.Models.Comment;
    using System.Collections.Generic;
    using System.Linq;

    public static class TestObjectFactory
    {
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

            return townsService.Object;
        }

        public static CommentDetalsRequestModel GetInvalidModel()
        {
            return new CommentDetalsRequestModel { Content = "invalid test model" };
        }
    }
}
