namespace TownSystem.Api.Tests.ControllerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Controllers;
    using Services.Models.Comment;


    [TestClass]
    public class CommentsControllerTests
    {
        [TestMethod]
        public void CommentsShouldValidateModelState()
        {
            var controller = new CommentsController(TestObjectFactory.GetCommentsService());
            controller.Configuration = new System.Web.Http.HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }
    }
}
