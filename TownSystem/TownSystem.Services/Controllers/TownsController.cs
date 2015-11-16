namespace TownSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Data.Contracts;
    using Common.Constants;
    using Models.Town;
    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/towns")]
    public class TownsController : ApiController
    {
        private readonly ITownsService towns;

        public TownsController(ITownsService townsService)
        {
            this.towns = townsService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            var result = this.towns
                .All()
                .ProjectTo<TownDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }
        
        public IHttpActionResult Get(int id)
        {
            var result = this.towns
                .ById(id)
                .ProjectTo<TownDetailsResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.towns
                .All(page, pageSize)
                .ProjectTo<TownDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(TownDetailsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdTownId = this.towns.Add(
                model.Name,
                model.Categories);

            return this.Ok(createdTownId);
        }
    }
}