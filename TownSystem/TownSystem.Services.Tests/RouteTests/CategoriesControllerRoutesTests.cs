namespace TownSystem.Services.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Controllers;
    using System.Net.Http;
    using Models.Category;
    using System.Web.Http;

    [TestClass]
    public class CategoriesControllerRoutesTests
    {
        [TestInitialize]
        public void Init()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(WebApiConfig.Config);
        }

        [TestMethod]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories")
                .To<CategoriesController>(c => c.Get());
        }

        [TestMethod]
        public void GetByIdShouldMapToCorrectAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/categories/1")
                .To<CategoriesController>(c => c.GetById("1"));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"" }")
                .To<CategoriesController>(c => c.Post(new CategoryDetailsResponseModel
                {
                    Name = "Test"
                }));
        }
    }
}
