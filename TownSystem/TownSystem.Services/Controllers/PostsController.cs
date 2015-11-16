namespace TownSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using TownSystem.Common.Constants;
    using TownSystem.Services.Data.Contracts;
    using TownSystem.Services.Models.Post;
    using AutoMapper.QueryableExtensions;

    public class PostsController : ApiController
    {
        private readonly IPostsService posts;

        public PostsController(IPostsService posts)
        {
            this.posts = posts;
        }

        // Get(public) api/posts
        public IHttpActionResult Get()
        {
            var result = this.posts
                .LatestPosts()
                .ProjectTo<PostDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        // GET(public) api/posts{postId}
        public IHttpActionResult Get(int id)
        {
            var result = this.posts
                .PostById(id)
                .ProjectTo<PostDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        // GET(public) api/posts?page=P
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaltPageSize)
        {
            var result = this.posts
                .All(page, pageSize)
                .ProjectTo<PostDetailsResponseModel>()
                .ToList();

            return this.Ok();
        }
        
        // POST(authorize) api/posts
        [Authorize]
        public IHttpActionResult Post(PostDetailsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdPostId = this.posts.Add(
                model.Title,
                model.Description,
                model.DateCreated,
                this.User.Identity.Name,
                model.TownId,
                model.IsDeleted);

            return this.Ok();
        }

        // POST(authorize) api/posts/{postID}/comments -> create new comment for selected post

        
    }
}
