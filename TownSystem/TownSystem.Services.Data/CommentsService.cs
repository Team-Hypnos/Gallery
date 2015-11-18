namespace TownSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using TownSystem.Data.Contracts;
    using Models;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;
        private readonly IUsersService users;

        public CommentsService(IRepository<Comment> commentsRepo, IUsersService usersRepo)
        {
            this.comments = commentsRepo;
            this.users = usersRepo;
        }

        public Comment Add(int? id, string content, string userName)
        {
            var userId = this.users.UserIdByUsername(userName);

            var comment = new Comment
            {
                TimePosted = DateTime.Now,
                PostId = id,
                Content = content,
                UserId = userId

            };

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment;
        }

        public IQueryable<Comment> All()
        {
            return this.comments
                .All()
                .OrderByDescending(c => c.TimePosted);
        }

        public IQueryable<Comment> ById(int id)
        {
            return this.comments.All().Where(c => c.Id == id && !c.IsDeleted);
        }

        public IQueryable<Comment> ByIdDeleted(int id)
        {
            return this.comments.All().Where(c => c.Id == id);
        }

        public Comment Edit(int id, string content,  string userName)
        {
            var userId = this.users.UserIdByUsername(userName);

            var comment = this.comments.All().Where(c => c.Id == id && c.UserId == userId).FirstOrDefault();

            if (comment == null)
            {
                return null;
            }

            comment.Content = content;
            this.comments.SaveChanges();

            return comment;
        }

        public Comment Delete(int id, string userName)
        {
            var userId = this.users.UserIdByUsername(userName);

            var comment = this.comments.All().Where(c => c.Id == id && c.UserId == userId).FirstOrDefault();

            if (comment == null)
            {
                return null;
            }

            comment.IsDeleted = true;
            this.comments.SaveChanges();

            return comment;
        }

        public IQueryable<Comment> PostComments(int postId)
        {
            return this.comments.All().Where(c => c.PostId == postId && !c.IsDeleted).OrderByDescending(c => c.TimePosted);
        }

        public IQueryable<Comment> UserComments(string userId)
        {
            return this.comments.All().Where(c => c.UserId == userId && !c.IsDeleted).OrderByDescending(c => c.TimePosted);
        }
    }
}
