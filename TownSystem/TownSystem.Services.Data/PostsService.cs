namespace TownSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TownSystem.Common.Constants;
    using TownSystem.Data.Contracts;
    using TownSystem.Models;
    using TownSystem.Services.Data.Contracts;

    public class PostsService : IPostsService
    {
        private readonly IRepository<Post> posts;
        private readonly IRepository<User> users;
        private readonly IRepository<Town> towns;

        public PostsService(IRepository<Post> posts, IRepository<User> users, IRepository<Town> towns)
        {
            this.posts = posts;
            this.users = users;
            this.towns = towns;
        }

        public IQueryable<Post> LatestPosts()
        {
            return this.posts
                .All()
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.DateCreated)
                .Take(GlobalConstants.HomePagePostsCount);             
        }

        public IQueryable<Post> MostPopular()
        {
            return this.posts
                .All()
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Likes.Count)
                .ThenByDescending(p => p.Comments.Count)
                .Take(GlobalConstants.HomePagePostsCount);
        }

        public IQueryable<Post> PostById(int id)
        {
            var query = this.posts
                .All()
                .Where(p => p.Id == id && !p.IsDeleted);

            return query;
        }

        public IQueryable<Post> LikedByUser(string userId)
        {
            return this.posts
                .All()
                .Where(p => !p.IsDeleted && p.Likes.Any(l => l.UserId == userId));
        }

        public IQueryable<Post> All(int page = 1, int pageSize = GlobalConstants.DefaltPageSize)
        {
            throw new NotImplementedException();
        }

        public int Add(int id, string title, string description, string userId, int townId, bool isDeleted = false)
        {
            var newPost = new Post
            {
                Id = id,
                Title = title,
                Description = description,
                DateCreated = DateTime.Now,
                IsDeleted = isDeleted,              
                UserId = userId,
                TownId = townId
            };

            this.posts.Add(newPost);
            this.posts.SaveChanges();

            return newPost.Id;
        }

        public Post Edit(int id, string title, string description, string userId, int townId, bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var deletedPost = this.posts.All().Where(p => p.Id == id).FirstOrDefault();
            deletedPost.IsDeleted = true;
            this.posts.SaveChanges();
        }
    }
}
