namespace TownSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using TownSystem.Common.Constants;
    using TownSystem.Models;

    public interface IPostsService
    {
        IQueryable<Post> LatestPosts();

        IQueryable<Post> MostPopular();

        IQueryable<Post> PostById(int id);

        IQueryable<Post> LikedByUser(string userId);

        IQueryable<Post> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        IQueryable<Post> GetByTownName(string townName);

        Post AddCommnet(int postId, string content, DateTime timePosted, string userId, bool isDeleted);

        Post Add(string title, string description, DateTime dateCreated, string userId, int townId, bool isDeleted);

        Post Edit(int id, string title, string description, string userId, int townId, bool isDeleted);

        void Delete(int id);
    }
}
