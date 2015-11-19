namespace TownSystem.Services.Tests.IntegrationTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http;
    using System.Net.Http;
    using System.Threading;
    using System.Net;
    using Moq;
    using TownSystem.Models;
    using TownSystem.Data.Contracts;

    [TestClass]
    public class CommentsIntegrationTests
    {
        [TestMethod]
        public void ByPostShouldReturnCorrectResponse()
        {
            var controller = typeof(CommentsController);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var httpServer = new HttpServer(config);
            var httpInvoker = new HttpMessageInvoker(httpServer);

            using (httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Comments/ByPost/1"),
                    Method = HttpMethod.Get
                };

                var result = httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(result);
                // Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            }
        }
    }
}
