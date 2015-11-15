﻿namespace TownSystem.Services.Data.Contracts
{
    using System.Linq;
    using TownSystem.Common.Constants;
    using TownSystem.Models;

    public interface IPostsService
    {
        IQueryable<Post> LatestPosts();

        IQueryable<Post> MostPopular();

        IQueryable<Post> PostById(int id);

        IQueryable<Post> LikedByUser(string userId);

        IQueryable<Post> All(int page = 1, int pageSize = GlobalConstants.DefaltPageSize);

        int Add(int id, string title, string description, string userId, int townId, bool isDeleted);

        Post Edit(int id, string title, string description, string userId, int townId, bool isDeleted);

        void Delete(int id);
    }
}
