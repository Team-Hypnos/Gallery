﻿namespace TownSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using TownSystem.Services.Data.Contracts;
    using Models.Category;
    using AutoMapper.QueryableExtensions;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categories = categoriesService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            var result = this.categories
                .All()
                .ProjectTo<CategoryDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Category name cannot be null or empty.");
            }

            var result = this.categories
                .ById(id)
                .ProjectTo<CategoryDetailsResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(CategoryDetailsResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.categories.Add(model.Name);

            return this.Ok(createdProjectId);
        }
    }
}