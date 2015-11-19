namespace TownSystem.Services.Data
{
    using System;
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

        public IQueryable<Post> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.posts
                .All()
                .OrderByDescending(p => p.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Post> GetByTownName(string townName)
        {
            return this.posts
                .All()
                .Where(p => !p.IsDeleted && p.Town.Name == townName);
        }

        public IQueryable<IGrouping<string, Post>> GroupByTownName()
        {
            return this.posts
                .All()
                .GroupBy(p => p.Town.Name);
        }

        public Post AddCommnet(int postId, string content, DateTime timePosted, string userId, bool isDeleted)
        {
            var post = this.posts.GetById(postId);
            var newComment = new Comment
            {
                PostId = postId,
                Content = content,
                TimePosted = timePosted,
                UserId = userId,
                IsDeleted = isDeleted
            };

            post.Comments.Add(newComment);
            this.posts.SaveChanges();

            return post;
        }

        public Post Add(string title, string description, DateTime dateCreated, string userId, int townId, bool isDeleted = false)
        {
            var newPost = new Post
            {
                Title = title,
                Description = description,
                DateCreated = dateCreated,
                UserId = userId,
                TownId = townId,
                IsDeleted = isDeleted
            };

            this.posts.Add(newPost);
            this.posts.SaveChanges();

            return newPost;
        }

        public Post Edit(int id, string title, string description, string userId, int townId, bool isDeleted)
        {
            var editedPost = this.posts
                .All()
                .Where(p => p.Id == id && p.UserId == userId && p.TownId == townId)
                .FirstOrDefault();

            if (editedPost == null)
            {
                return null;
            }

            editedPost.Title = title;
            editedPost.Description = description;
            editedPost.IsDeleted = isDeleted;

            this.posts.SaveChanges();
            return editedPost;
        }

        public void Delete(int id)
        {
            var deletedPost = this.posts.All().Where(p => p.Id == id).FirstOrDefault();
            deletedPost.IsDeleted = true;
            this.posts.SaveChanges();
        }
    }
}
