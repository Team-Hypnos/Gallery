namespace TownSystem.Services.Tests.RouteTests
{
    using System.Net.Http;
    using System.Web.Http;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Comment;
    using MyTested.WebApi;

    [TestClass]
    public class CommentsControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(WebApiConfig.Config);
        }

        [TestMethod]
        public void ControllerShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Content"": ""Test"", ""UserName"" : ""TestUser""}")
                .To<CommentsController>(c => c.Post(new CommentDetailsRequestModel
                {
                    Content = "Test",
                    UserName = "TestUser"
                }));
        }

        [TestMethod]
        public void ControllerGetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments")
                .To<CommentsController>(c => c.Get());
        }

        [TestMethod]
        public void ControllerGetWithPostIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByPost/1")
                .To<CommentsController>(c => c.GetByPostId(1));
        }

        [TestMethod]
        public void ControllerRouteIsResolvedWIthInvalidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Content"": ""Invalid Model Test""}")
                .ToInvalidModelState();
        }

    }
}
