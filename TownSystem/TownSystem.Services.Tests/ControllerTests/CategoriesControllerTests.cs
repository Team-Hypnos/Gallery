namespace TownSystem.Services.Tests.ControllerTests
{
    using System.Web.Http.Cors;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Controllers;
    using Api.Tests;

    [TestClass]
    public class CategoriesControllerTests
    {
        [TestMethod]
        public void GetShouldHaveCorsEnabled()
        {
            MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Get())
                .ShouldHave()
                .ActionAttributes(attr => attr.ContainingAttributeOfType<EnableCorsAttribute>());
        }

        [TestMethod]
        public void GetShouldReturnNotFoundWhenProjectIsNull()
        {
            MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .WithAuthenticatedUser()
                .Calling(c => c.GetById("Invalid"))
                .ShouldReturn()
                .NotFound();
        }

        [TestMethod]
        public void PostShouldValidateModelState()
        {
            MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Post(TestObjectFactory.GetValidCategoryModel()))
                .ShouldHave()
                .ValidModelState();
        }
        
        [TestMethod]
        public void GetShouldHaveAuthorizedAttribute()
        {
            MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Post(TestObjectFactory.GetValidCategoryModel()))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests());
        }
    }
}
