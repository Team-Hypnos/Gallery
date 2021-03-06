﻿namespace TownSystem.Services.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Contracts;
    using System.Reflection;
    using Api.Tests;
    using Common.Constants;
    using Controllers;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Models.Post;
    using MyTested.WebApi;

    [TestClass]
    public class PostsControllerTests
    {
        private IPostsService postsService;

        [TestInitialize]
        public void Init()
        {
            this.postsService = TestObjectFactory.GetPostsService();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
        }

        [TestMethod]
        public void PostsGetShouldReturnOkResult()
        {
            var controller = new PostsController(this.postsService);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<PostDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void PostsGetByIdShouldReturnOkResult()
        {
            var controller = new PostsController(this.postsService);

            var result = controller.Get(1);

            var okResult = result as OkNegotiatedContentResult<List<PostDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void PostsGetWithPageAndPageSizeShouldReturnOkResult()
        {
            var controller = new PostsController(this.postsService);

            var result = controller.Get(1, 10);

            var okResult = result as OkNegotiatedContentResult<List<PostDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void PostsGetByNameShouldReturnOkResult()
        {
            var controller = new PostsController(this.postsService);

            var result = controller.Get("Sofia");

            var okResult = result as OkNegotiatedContentResult<List<PostDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void PostsPostShouldReturnOkResult()
        {
            MyWebApi
                .Controller<PostsController>()
                .WithResolvedDependencyFor(this.postsService)
                .Calling(p => p.Post(TestObjectFactory.GetValidPostsModel()))
                .ShouldHave()
                .ValidModelState();
        }

        [TestMethod]
        public void PostsPostWithInvalidShouldReturnBadRequestResult()
        {
            MyWebApi
                .Controller<PostsController>()
                .WithResolvedDependencyFor(this.postsService)
                .Calling(p => p.Post(TestObjectFactory.GetInvalidPostsModel()))
                .ShouldHave()
                .InvalidModelState();
        }
    }
}