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
            if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Comment content cannot be null or whitespace!");
            }

            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Comment user name cannot be null or whitespace!");
            }

            var userId = this.users.UserIdByUsername(userName);

            var comment = new Comment
            {
                TimePosted = DateTime.Now,
                PostId = null,
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

        public void Delete(int id)
        {
            var comment = this.comments.All().Where(c => c.Id == id).FirstOrDefault();
            comment.IsDeleted = true;
            this.comments.SaveChanges();
        }


        public Comment Edit(int id, string content, string userId)
        {
            var comment = this.comments.All().Where(c => c.Id == id && c.UserId == userId).FirstOrDefault();

            if (comment == null)
            {
                return null;
            }

            comment.Content = content;
            this.comments.SaveChanges();

            return comment;
        }

        //public IQueryable<Comment> PostComments(int postId)
        //{
        //    return this.comments.All().Where(c => c.PostId == postId && !c.IsDeleted).OrderByDescending(c => c.TimePosted);
        //}

        public IQueryable<Comment> UserComments(string userId)
        {
            return this.comments.All().Where(c => c.UserId == userId && !c.IsDeleted).OrderByDescending(c => c.TimePosted);
        }
    }
}
