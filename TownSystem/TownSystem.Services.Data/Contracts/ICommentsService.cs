namespace TownSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using Models;


    public interface ICommentsService
    {
        IQueryable<Comment> All();

        IQueryable<Comment> ById(int id);

        IQueryable<Comment> PostComments(int postId);

        IQueryable<Comment> UserComments(string userId);

        Comment Add(int id, string content, string userId);

        Comment Edit(int id, string content, string userId);

        void Delete(int id);

    }
}
