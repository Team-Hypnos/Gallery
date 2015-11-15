using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TownSystem.Common.Constants;
using TownSystem.Services.Data.Contracts;
using TownSystem.Services.Models.Post;

namespace TownSystem.Services.Controllers
{
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
                .LatestPosts();

            return this.Ok(result);
        }

        // GET(public) api/posts{postId}
        public IHttpActionResult Get(int id)
        {
            return this.Ok();
        }

        // GET(public) api/posts?page=P
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaltPageSize)
        {
            return this.Ok();
        }
        

        // POST(authorize) api/posts
        [Authorize]
        public IHttpActionResult Post(PostDetailsRequestModel model)
        {
            return this.Ok();
        }

        // POST(authorize) api/posts/{postID}/comments

        
    }
}
