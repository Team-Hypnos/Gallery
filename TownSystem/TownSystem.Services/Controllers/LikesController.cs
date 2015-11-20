namespace TownSystem.Services.Controllers
{
    using System.Web.Http;
    using TownSystem.Services.Data.Contracts;

    public class LikesController : ApiController
    {
        private readonly ILikesService likes;

        public LikesController(ILikesService likes, IUsersService users)
        {
            this.likes = likes;
        }

        [Authorize]
        [HttpPost]
        [Route("api/like/{id}")]
        public IHttpActionResult Like(int id)
        {
            if (this.likes.PostIsLikedByUser(id, this.User.Identity.Name))
            {
                return this.BadRequest("You already have liked this project.");
            }

            this.likes.LikePost(id, this.User.Identity.Name);
            return this.Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("api/dislike/{id}")]
        public IHttpActionResult Dislike(int id)
        {
            if (!this.likes.PostIsLikedByUser(id, this.User.Identity.Name))
            {
                return this.BadRequest("You have not yet liked this project.");
            }

            this.likes.DislikePost(id, this.User.Identity.Name);
            return this.Ok();
        }
    }
}
