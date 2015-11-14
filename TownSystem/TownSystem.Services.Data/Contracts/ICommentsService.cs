namespace TownSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using Models;


    public interface ICommentsService
    {
        IQueryable<Comment> ById(int id);

        IQueryable<Comment> PostComments(int? postId);

        IQueryable<Comment> UserComments(string username);

        int Add(int id, string content, string username, DateTime timePosted);

        int Edit(int id, string content, string username);

        int Delete(int id);

    }
}
