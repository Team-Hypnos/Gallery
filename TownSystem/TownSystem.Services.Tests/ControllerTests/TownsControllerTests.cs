namespace TownSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Data.Contracts;
    using Services.Controllers;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Services.Models.Town;
    using Services;
    using Common.Constants;
    using System.Reflection;
    using MyTested.WebApi;

    [TestClass]
    public class TownsControllerTests
    {
        private ITownsService townService;

        [TestInitialize]
        public void Init()
        {
            this.townService = TestObjectFactory.GetTownsService();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
        }

        [TestMethod]
        public void GetShouldReturnOkResult()
        {
            var controller = new TownsController(this.townService);

            var result = controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<TownDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void GetByIdShouldReturnOkResult()
        {
            var controller = new TownsController(this.townService);

            var result = controller.Get(1);

            var okResult = result as OkNegotiatedContentResult<TownDetailsResponseModel>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void GetWithPageAndPageSizeShouldReturnOkResult()
        {
            var controller = new TownsController(this.townService);

            var result = controller.Get(1, 10);

            var okResult = result as OkNegotiatedContentResult<List<TownDetailsResponseModel>>;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void PostShouldReturnOkResult()
        {
            MyWebApi
                .Controller<TownsController>()
                .WithResolvedDependencyFor(this.townService)
                .Calling(c => c.Post(TestObjectFactory.GetValidTownModel()))
                .ShouldHave()
                .ValidModelState();
        }

        [TestMethod]
        public void PostWithInvalidShouldReturnBadRequestResult()
        {
            MyWebApi
                .Controller<TownsController>()
                .WithResolvedDependencyFor(this.townService)
                .Calling(c => c.Post(TestObjectFactory.GetInvalidTownModel()))
                .ShouldHave()
                .InvalidModelState();
        }
    }
}