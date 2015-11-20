namespace TownSystem.Services.Tests.RouteTests
{
    using System.Net.Http;
    using System.Web.Http;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Town;
    using MyTested.WebApi;
    using System.Collections.Generic;

    [TestClass]
    public class TownsControllerTests
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
                .ShouldMap("api/towns")
                .To<TownsController>(c => c.Get());
        }

        [TestMethod]
        public void GetByIdShouldMapToCorrectAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/towns/1")
                .To<TownsController>(c => c.Get(1));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/towns")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""Categories"": [""nature""] }")
                .To<TownsController>(c => c.Post(new TownDetailsRequestModel
                {
                    Name = "Test",
                    Categories = new List<string>()
                    {
                        "nature"
                    }
           
                }));
        }
    }
}
