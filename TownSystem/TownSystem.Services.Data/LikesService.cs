namespace TownSystem.Services.Data
{
    using System;
    using System.Linq;
    using TownSystem.Data.Contracts;
    using TownSystem.Models;
    using TownSystem.Services.Data.Contracts;

    public class LikesService : ILikesService
    {
        private readonly IUsersService users;
        private readonly IRepository<Like> likes;

        public LikesService(IRepository<Like> likes, IUsersService users)
        {
            this.likes = likes;
            this.users = users;
        }

        public IQueryable<Like> AllLikesForPost(int postId)
        {
            return this.likes
                .All()
                .Where(l => l.PostId == postId);
        }

        public void LikePost(int postId, string username)
        {
            var userId = this.users.UserIdByUsername(username);

            //TODO: check for userId
            var like = new Like
            {
                PostId = postId,
                UserId = userId
            };

            this.likes.Add(like);
            this.likes.SaveChanges();
        }

        public void DislikePost(int postId, string username)
        {
            var userId = this.users.UserIdByUsername(username);

            //TODO: check for userId
            var like = this.likes
                .All()
                .Where(l => l.UserId == userId && l.PostId == postId)
                .FirstOrDefault();

            this.likes.Delete(like);
            this.likes.SaveChanges();
        }

        public bool PostIsLikedByUser(int postId, string username)
        {
            return this.AllLikesForPost(postId)
                .Any(l => l.User.UserName == username);
        }
    }
}
