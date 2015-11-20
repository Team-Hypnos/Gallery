namespace TownSystem.Services.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Contracts;
    using Api.Tests;
    using System.Reflection;
    using Common.Constants;
    using Controllers;
    using System.Web.Http.Results;
    using System.Collections.Generic;

    [TestClass]
    public class LikesControllerTests
    {
        private ILikesService likeService;
        private IUsersService userService;

        [TestInitialize]
        public void Init()
        {
            this.likeService = TestObjectFactory.GetLikeService();
            this.userService = TestObjectFactory.GetUserService();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
        }

        [TestMethod]
        public void LikesLikeShouldReturnOkResult()
        {
            var controller = new LikesController(this.likeService, this.userService);

            var result = controller.Like(1);
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LikesDislikeShouldReturnOkResult()
        {
            var controller = new LikesController(this.likeService, this.userService);

            var result = controller.Dislike(1);

            Assert.IsNotNull(result);
        }
    }
}