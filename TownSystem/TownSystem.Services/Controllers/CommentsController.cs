namespace TownSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models.Comment;

    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService commentsSevice)
        {
            this.comments = commentsSevice;
        }

        public IHttpActionResult Get()
        {
            var result = this.comments
                .All()
                .ProjectTo<CommentDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int postId)
        {
            var result = this.comments
                .PostComments(postId)
                .ProjectTo<CommentDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(CommentDetalsRequestModel model)
        {
            var comment = this.comments.Add(model.PostId, model.Content, model.UserName);

            var result = this.comments
                .ById(comment.Id)
                .ProjectTo<CommentDetailsResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit(CommentDetalsRequestModel model)
        {
            var comment = this.comments.Edit(model.Id, model.Content, model.UserName);

            var result = this.comments
                .ById(comment.Id)
                .ProjectTo<CommentDetailsResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(CommentDetalsRequestModel model)
        {
            var comment = this.comments.Delete(model.Id, model.UserName);
            var result = this.comments
                .ById(comment.Id)
                .ProjectTo<CommentDetailsResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}
