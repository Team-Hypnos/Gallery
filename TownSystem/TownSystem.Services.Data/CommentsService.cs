namespace TownSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using TownSystem.Data.Contracts;
    using Models;

    class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Post> postsRepo, IRepository<Comment> commentsRepo)
        {
            this.comments = commentsRepo;
        }

        public int Add(int id, string content, string username, DateTime timePosted)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> ById(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(int id, string content, string username)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> PostComments(int? postId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> UserComments(string username)
        {
            throw new NotImplementedException();
        }
    }
}
