namespace TownSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using TownSystem.Common.Constants;
    using TownSystem.Services.Data.Contracts;
    using TownSystem.Services.Models.Post;
    using AutoMapper.QueryableExtensions;
    using TownSystem.Data.Contracts;
    using TownSystem.Models;
    using System;
    using TownSystem.Services.Models.Comment;

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
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.posts
                .All(page, pageSize)
                .ProjectTo<PostDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        // GET(public) api/posts?town=Name

        public IHttpActionResult Get(string town)
        {
            var result = this.posts
                .GetByTownName(town)
                .ProjectTo<PostDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }
        
        // POST(authorize) api/posts
        [Authorize]
        public IHttpActionResult Post(PostDetailsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
                      
            var createdPost = this.posts.Add(
                model.Title,
                model.Description,
                DateTime.Now,
                this.User.Identity.GetUserId(),
                model.TownId,
                model.IsDeleted);

            return this.Created(string.Format("api/posts{0}", createdPost.Id ), createdPost);
        }

        // POST(authorize) api/posts/{id}/comment -> create new comment for selected post 
        
        [HttpPost]
        [Route("api/posts/{id}/comment")]
        [Authorize]
        public IHttpActionResult Post(int id, CommentDetailsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdComment = this.posts
                .AddCommnet(id, model.Content, DateTime.Now, this.User.Identity.GetUserId(), false);

            return this.Ok(createdComment);
        }

        // POST(authorize) api/post/{id}/like -> like for selected post
        //[HttpPut]
        //[Route("api/posts/{id}/like")]
        //[Authorize]

        //public IHttpActionResult Put(int id, )
    }
}
