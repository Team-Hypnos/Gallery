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
                .To<CommentsController>(c => c.Post(new CommentDetalsRequestModel
                {
                    Content = "Test",
                    UserName = "TestUser"
                }));
        }
    }
}
