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
    }
}