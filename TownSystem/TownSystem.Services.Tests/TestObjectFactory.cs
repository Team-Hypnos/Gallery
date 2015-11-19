namespace TownSystem.Api.Tests
{
    using Services.Data.Contracts;
    using Moq;
    using Models;
    using Services.Models.Comment;
    using System.Collections.Generic;
    using System.Linq;
    using Services.Models.Town;
    using System;

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

        private static IQueryable<Post> posts = new List<Post>
        {
            new Post
            {
                Title = "Some post",
                Description = "Some description",
                Id = 1,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                UserId = "1"
            },
            new Post
            {
                Title = "Other post",
                Description = "Other description",
                Id = 2,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                UserId = "2"
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

        public static IPostsService GetPostsService()
        {
            var postsService = new Mock<IPostsService>();
            postsService.Setup(p => p.LatestPosts()).Returns(new List<Post>().AsQueryable());

            postsService.Setup(p => p.All(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Post>().AsQueryable());

            postsService.Setup(p => p.PostById(It.IsAny<int>())).Returns(posts);

            return postsService.Object;
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
