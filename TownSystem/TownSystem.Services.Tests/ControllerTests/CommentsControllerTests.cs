namespace TownSystem.Api.Tests.ControllerTests
{
    using System;
    using System.Web.Http.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Controllers;
    using Services.Models.Comment;


    [TestClass]
    public class CommentsControllerTests
    {
        [TestMethod]
        public void CommentShouldValidateModelState()
        {
            var controller = new CommentsController(TestObjectFactory.GetCommentsService());
            controller.Configuration = new System.Web.Http.HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            var result = controller.Post(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void CommentShouldReturnBadRequestWithInvalidModel()
        {
            var controller = new CommentsController(TestObjectFactory.GetCommentsService());
            controller.Configuration = new System.Web.Http.HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            var result = controller.Post(model);

            Assert.AreEqual(typeof (InvalidModelStateResult), result.GetType());
        }
    }
}
